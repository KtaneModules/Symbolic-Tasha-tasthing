using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using rnd = UnityEngine.Random;

public class symbolicTasha : MonoBehaviour
{
    public new KMAudio audio;
    public KMBombInfo bomb;
    public KMBombModule module;

    public KMSelectable[] buttons;
    public Renderer[] btnRenderers;
    public Renderer[] buttonSymbols;
    public Light[] lights;
    public Color[] materialColors;
    public Texture[] symbols;
    public Texture crackedTexture;

    private int[] flashing = new int[5];
    private stSymbol[] presentSymbols = new stSymbol[4];
    private List<stColor> solution = new List<stColor>();
    private int stage = 0;
    private int enteringStage;
    private stColor[] trueColors = new stColor[4] { stColor.pink, stColor.green, stColor.yellow, stColor.blue };
    private stColor[] buttonColors = new stColor[4] { stColor.pink, stColor.green, stColor.yellow, stColor.blue };
    private bool[] trueConditions = new bool[4] { false, false, false, true };
    private int currentTable = 0;
    private bool[] cracked = new bool[4];
    private string[] rules = new string[4] { "Stage 1 or more than 2 strikes", "At least 2 cracked buttons", "Empty Port Plate", "None of the above" };

    private string[] soundNames = new string[4] { "High", "NotAsHigh", "NotAsHighAsNotAsHigh", "NotHigh" };
    private static readonly string[] positionNames = new string[4] { "top", "right", "bottom", "left" };
    private bool anyBtnPressed;
    private bool[] flashingButtons = new bool[4];

    private static int moduleIdCounter = 1;
    private int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in buttons)
            button.OnInteract += delegate () { ButtonPress(button); return false; };
    }

    void Start()
    {
        float scalar = transform.lossyScale.x;
        for (int i = 0; i < 4; i++)
        {
            lights[i].range *= scalar;
            lights[i].enabled = false;
        }
        buttonColors = buttonColors.Shuffle().ToArray();
        soundNames = soundNames.Shuffle().ToArray();
        for (int i = 0; i < 4; i++)
        {
            btnRenderers[i].material.color = materialColors[(int) buttonColors[i]];
            lights[i].color = materialColors[(int) buttonColors[i]];
            presentSymbols[i] = (stSymbol) rnd.Range(1, 19);
            buttonSymbols[i].material.mainTexture = symbols[(int) presentSymbols[i] - 1];
            Debug.LogFormat("[Symbolic Tasha #{0}] The {1} button is {2}, with the symbol titled '{3}'.", moduleId, positionNames[i], buttonColors[i], presentSymbols[i]);
        }
        string[] ordinals = new string[5] { "First", "Second", "Third", "Fourth", "Fifth" };
        for (int i = 0; i < 5; i++)
        {
            flashing[i] = rnd.Range(0, 4);
        }
        Debug.LogFormat("[Symbolic Tasha #{0}] Flashing Colors: {1}: {2} | {3}: {4} | {5}: {6} | {7}: {8} | {9}: {10}", moduleId, ordinals[0], buttonColors[flashing[0]], ordinals[1], buttonColors[flashing[1]], ordinals[2], buttonColors[flashing[2]], ordinals[3], buttonColors[flashing[3]], ordinals[4], buttonColors[flashing[4]]);
        solution.Add(CalculateStage());
        Debug.LogFormat("[Symbolic Tasha #{0}] The first color to press is {1}.", moduleId, solution[0]);
        StartCoroutine(SequenceFlash());
    }

    void ButtonPress(KMSelectable button)
    {
        anyBtnPressed = true;
        var ix = Array.IndexOf(buttons, button);
        button.AddInteractionPunch(2);
        audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
        audio.PlaySoundAtTransform(soundNames[ix], button.transform);
        if (!cracked[ix])
        {
            cracked[ix] = true;
            presentSymbols[ix] = (stSymbol) (-(int) presentSymbols[ix]);
            btnRenderers[ix].material.mainTexture = crackedTexture;
            buttonSymbols[ix].gameObject.SetActive(false);
            audio.PlaySoundAtTransform("shatter", button.transform);
            if (!moduleSolved)
                Debug.LogFormat("[Symbolic Tasha #{0}] The {1} button cracked!", moduleId, buttonColors[ix]);
        }
        if (moduleSolved)
            return;
        if (enteringStage == 0)
        {
            StopAllCoroutines();
            foreach (Light l in lights)
                l.enabled = false;
        }
        StartCoroutine(SingleFlash(ix));
        if (buttonColors[ix] != solution[enteringStage])
        {
            enteringStage = 0;
            Debug.LogFormat("[Symbolic Tasha #{0}] You pressed the {1} button. That was incorrect. Strike!", moduleId, buttonColors[ix]);
            module.HandleStrike();
            StartCoroutine(SequenceFlash());
        }
        else
            enteringStage++;
        if (enteringStage > stage)
        {
            enteringStage = 0;
            AdvanceStage();
        }
    }

    void AdvanceStage()
    {
        stage++;
        if (bomb.GetStrikes() >= 2 && !trueConditions[0])
        {
            trueConditions[0] = true;
            Debug.LogFormat("[Symbolic Tasha #{0}] The number of strikes has reached 2 or more. The first condition is now true.", moduleId);
        }
        if (cracked.Count(b => b) >= 2 && !trueConditions[1])
        {
            trueConditions[1] = true;
            Debug.LogFormat("[Symbolic Tasha #{0}] The number of cracked buttons has reached 2 or more. The second condition is now true.", moduleId);
        }
        if (bomb.GetPortPlates().Any(x => x.Length == 0))
            trueConditions[2] = true;
        currentTable = Array.IndexOf(trueConditions, true);
        if (stage == 5)
        {
            module.HandlePass();
            moduleSolved = true;
            Debug.LogFormat("[Symbolic Tasha #{0}] Module solved!", moduleId);
        }
        else
        {
            solution.Add(CalculateStage());
            StartCoroutine(SequenceFlash());
            Debug.LogFormat("[Symbolic Tasha #{0}] {1} was added to the sequence of colors to press.", moduleId, solution[stage]);
        }
    }

    IEnumerator SingleFlash(int ix)
    {
        flashingButtons[ix] = true;
        lights[ix].enabled = true;
        yield return new WaitForSeconds(.5f);
        lights[ix].enabled = false;
        flashingButtons[ix] = false;
    }

    IEnumerator SequenceFlash()
    {
        while (flashingButtons.Contains(true))
            yield return null;
        yield return new WaitForSeconds(1.75f);
        sequenceReset:
        for (int i = 0; i <= stage; i++)
        {
            int ix = flashing[i];
            lights[ix].enabled = true;
            if (anyBtnPressed)
                audio.PlaySoundAtTransform(soundNames[ix], buttons[ix].transform);
            yield return new WaitForSeconds(.8f);
            lights[ix].enabled = false;
            yield return new WaitForSeconds(.4f);
        }
        yield return new WaitForSeconds(3.5f);
        goto sequenceReset;
    }

    stColor CalculateStage()
    {
        Debug.LogFormat("[Symbolic Tasha #{0}] Rule being applied for Stage {1}: {2} ", moduleId, stage+1, rules[currentTable]);
        stSymbol usingSymbol = presentSymbols[flashing[stage]];

        for (var i = 0; i < 12; i++)
        {
            if (Tables.symbolColumns[currentTable][i].Contains(usingSymbol))
            {
                return Tables.colorRows[currentTable][Array.IndexOf(trueColors, buttonColors[flashing[stage]])][i];
            }
        }
        return stColor.pink;
    }

    void Update()
    {

    }

    // Twitch Plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = "Use !{0} press [pink/blue/green/yellow] to press buttons. You can also use the first letters, or positions.";
    #pragma warning disable 414
    IEnumerator ProcessTwitchCommand(string cmd)
    {
        string[] acceptableWords = { "top", "right", "bottom", "left", "pink", "green", "yellow", "blue", "p", "g", "y", "b" };
        if (cmd.ToLowerInvariant().StartsWith("press "))
        {
            string btns = cmd.Substring(6).ToLowerInvariant();
            string[] btnSequence = btns.Split(' ');

            if (btnSequence.Length > 5)
            {
                yield return "sendtochaterror That's more than 5 buttons :/";
                yield break;
            }
            for (int i = 0; i < btnSequence.Length; i++)
            {
                if (!acceptableWords.Contains(btnSequence[i]))
                {
                    yield return "sendtochaterror One of those buttons isn't a valid button...";
                    yield break;
                }
            }
            yield return null;
            for (int i = 0; i < btnSequence.Length; i++)
            {
                if (btnSequence[i].Equals("top"))
                    buttons[0].OnInteract();
                else if (btnSequence[i].Equals("right"))
                    buttons[1].OnInteract();
                else if (btnSequence[i].Equals("bottom"))
                    buttons[2].OnInteract();
                else if (btnSequence[i].Equals("left"))
                    buttons[3].OnInteract();
                else if (btnSequence[i].Equals("pink") || btnSequence[i].Equals("p"))
                    buttons[Array.IndexOf(buttonColors, 0)].OnInteract();
                else if (btnSequence[i].Equals("green") || btnSequence[i].Equals("g"))
                    buttons[Array.IndexOf(buttonColors, 1)].OnInteract();
                else if (btnSequence[i].Equals("yellow") || btnSequence[i].Equals("y"))
                    buttons[Array.IndexOf(buttonColors, 2)].OnInteract();
                else if (btnSequence[i].Equals("blue") || btnSequence[i].Equals("b"))
                    buttons[Array.IndexOf(buttonColors, 3)].OnInteract();
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
            yield break;
    }
}
