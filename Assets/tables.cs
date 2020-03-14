public enum stSymbol
{
    hook = 1,
    wand = 2,
    yankee = 3,
    lightning = 4,
    india = 5,
    angle = 6,
    kilo = 7,
    flagHole = 8,
    foxtrot = 9,
    antenna = 10,
    compass = 11,
    fire = 12,
    triangle = 13,
    circle = 14,
    shelf = 15,
    curve = 16,
    lollipop = 17,
    flag = 18,

    hookCracked = -1,
    wandCracked = -2,
    yankeeCracked = -3,
    lightningCracked = -4,
    indiaCracked = -5,
    angleCracked = -6,
    kiloCracked = -7,
    flagHoleCracked = -8,
    foxtrotCracked = -9,
    antennaCracked = -10,
    compassCracked = -11,
    fireCracked = -12,
    triangleCracked = -13,
    circleCracked = -14,
    shelfCracked = -15,
    curveCracked = -16,
    lollipopCracked = -17,
    flagCracked = -18,
}

public enum stColor
{
    pink,
    green,
    yellow,
    blue
}

public static class Tables
{
    public static readonly stSymbol[][][] symbolColumns = new stSymbol[4][][]
    {
        new stSymbol[12][]
        {
            new stSymbol[] { stSymbol.hook, stSymbol.foxtrot },
            new stSymbol[] { stSymbol.wand, stSymbol.yankeeCracked },
            new stSymbol[] { stSymbol.wandCracked, stSymbol.indiaCracked },
            new stSymbol[] { stSymbol.yankee, stSymbol.antennaCracked },
            new stSymbol[] { stSymbol.lightningCracked, stSymbol.compassCracked },
            new stSymbol[] { stSymbol.india, stSymbol.antenna },
            new stSymbol[] { stSymbol.angleCracked, stSymbol.fireCracked },
            new stSymbol[] { stSymbol.kilo, stSymbol.triangle },
            new stSymbol[] { stSymbol.hookCracked, stSymbol.foxtrotCracked },
            new stSymbol[] { stSymbol.kiloCracked, stSymbol.triangleCracked },
            new stSymbol[] { stSymbol.flagHoleCracked, stSymbol.angle },
            new stSymbol[] { stSymbol.lightning, stSymbol.compass }
        },
        new stSymbol[12][]
        {
            new stSymbol[] { stSymbol.fireCracked, stSymbol.foxtrot },
            new stSymbol[] { stSymbol.wand, stSymbol.yankeeCracked },
            new stSymbol[] { stSymbol.compassCracked, stSymbol.indiaCracked },
            new stSymbol[] { stSymbol.yankee, stSymbol.hook },
            new stSymbol[] { stSymbol.lightningCracked, stSymbol.circleCracked },
            new stSymbol[] { stSymbol.angle, stSymbol.lightning },
            new stSymbol[] { stSymbol.circle, stSymbol.shelf },
            new stSymbol[] { stSymbol.triangleCracked, stSymbol.foxtrotCracked },
            new stSymbol[] { stSymbol.hookCracked, stSymbol.triangle },
            new stSymbol[] { stSymbol.fire, stSymbol.kilo },
            new stSymbol[] { stSymbol.flagHoleCracked, stSymbol.curve },
            new stSymbol[] { stSymbol.flagHole, stSymbol.compass }
        },
        new stSymbol[12][]
        {
            new stSymbol[] { stSymbol.lollipop, stSymbol.angle },
            new stSymbol[] { stSymbol.hookCracked, stSymbol.indiaCracked },
            new stSymbol[] { stSymbol.foxtrot, stSymbol.flagCracked },
            new stSymbol[] { stSymbol.flag, stSymbol.flagHole },
            new stSymbol[] { stSymbol.lightning, stSymbol.wand },
            new stSymbol[] { stSymbol.angleCracked, stSymbol.circle },
            new stSymbol[] { stSymbol.compass, stSymbol.yankeeCracked },
            new stSymbol[] { stSymbol.curveCracked, stSymbol.india },
            new stSymbol[] { stSymbol.lollipopCracked, stSymbol.wandCracked },
            new stSymbol[] { stSymbol.shelfCracked, stSymbol.antenna },
            new stSymbol[] { stSymbol.hook, stSymbol.circleCracked },
            new stSymbol[] { stSymbol.curve, stSymbol.flagHoleCracked }
        },
        new stSymbol[12][]
        {
            new stSymbol[] { stSymbol.compass, stSymbol.indiaCracked },
            new stSymbol[] { stSymbol.india, stSymbol.fireCracked },
            new stSymbol[] { stSymbol.wandCracked, stSymbol.curveCracked },
            new stSymbol[] { stSymbol.curve, stSymbol.circle },
            new stSymbol[] { stSymbol.lightningCracked, stSymbol.shelf },
            new stSymbol[] { stSymbol.antennaCracked, stSymbol.yankee },
            new stSymbol[] { stSymbol.angleCracked, stSymbol.lollipopCracked },
            new stSymbol[] { stSymbol.antenna, stSymbol.lollipop },
            new stSymbol[] { stSymbol.hookCracked, stSymbol.yankeeCracked },
            new stSymbol[] { stSymbol.kiloCracked, stSymbol.shelfCracked },
            new stSymbol[] { stSymbol.fire, stSymbol.angle },
            new stSymbol[] { stSymbol.triangleCracked, stSymbol.compassCracked }
        },
    };
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    public static readonly stColor[][][] colorRows = new stColor[4][][]
    {
        new stColor[4][]
        {
            new stColor[12] { stColor.green, stColor.pink, stColor.green, stColor.green, stColor.pink, stColor.blue, stColor.blue, stColor.green, stColor.pink, stColor.pink, stColor.yellow, stColor.green },
            new stColor[12] { stColor.pink, stColor.green, stColor.blue, stColor.yellow, stColor.green, stColor.green, stColor.pink, stColor.blue, stColor.green, stColor.blue, stColor.green, stColor.blue },
            new stColor[12] { stColor.yellow, stColor.blue, stColor.yellow, stColor.pink, stColor.yellow, stColor.yellow, stColor.yellow, stColor.pink, stColor.yellow, stColor.green, stColor.pink, stColor.yellow },
            new stColor[12] { stColor.blue, stColor.yellow, stColor.pink, stColor.blue, stColor.blue, stColor.pink, stColor.green, stColor.yellow, stColor.blue, stColor.yellow, stColor.blue, stColor.pink }
        },
        new stColor[4][]
        {
            new stColor[12] { stColor.green, stColor.pink, stColor.yellow, stColor.yellow, stColor.pink, stColor.blue, stColor.pink, stColor.blue, stColor.green, stColor.pink, stColor.green, stColor.green },
            new stColor[12] { stColor.yellow, stColor.blue, stColor.pink, stColor.green, stColor.green, stColor.pink, stColor.yellow, stColor.green, stColor.pink, stColor.blue, stColor.blue, stColor.yellow },
            new stColor[12] { stColor.blue, stColor.yellow, stColor.blue, stColor.pink, stColor.yellow, stColor.yellow, stColor.green, stColor.pink, stColor.blue, stColor.green, stColor.pink, stColor.blue },
            new stColor[12] { stColor.pink, stColor.green, stColor.green, stColor.blue, stColor.blue, stColor.green, stColor.blue, stColor.yellow, stColor.yellow, stColor.yellow, stColor.yellow, stColor.pink }
        },
        new stColor[4][]
        {
            new stColor[12] { stColor.blue, stColor.blue, stColor.green, stColor.blue, stColor.pink, stColor.green, stColor.yellow, stColor.yellow, stColor.green, stColor.yellow, stColor.pink, stColor.blue },
            new stColor[12] { stColor.green, stColor.pink, stColor.pink, stColor.green, stColor.yellow, stColor.pink, stColor.blue, stColor.pink, stColor.yellow, stColor.pink, stColor.green, stColor.green },
            new stColor[12] { stColor.pink, stColor.yellow, stColor.blue, stColor.pink, stColor.blue, stColor.blue, stColor.green, stColor.green, stColor.blue, stColor.green, stColor.yellow, stColor.pink },
            new stColor[12] { stColor.yellow, stColor.green, stColor.yellow, stColor.yellow, stColor.green, stColor.yellow, stColor.pink, stColor.blue, stColor.pink, stColor.blue, stColor.blue, stColor.yellow }
        },
        new stColor[4][]
        {
            new stColor[12] { stColor.yellow, stColor.pink, stColor.blue, stColor.blue, stColor.blue, stColor.green, stColor.pink, stColor.pink, stColor.blue, stColor.yellow, stColor.green, stColor.pink },
            new stColor[12] { stColor.green, stColor.yellow, stColor.yellow, stColor.pink, stColor.green, stColor.pink, stColor.green, stColor.blue, stColor.green, stColor.pink, stColor.yellow, stColor.blue },
            new stColor[12] { stColor.blue, stColor.blue, stColor.pink, stColor.green, stColor.pink, stColor.blue, stColor.yellow, stColor.yellow, stColor.yellow, stColor.blue, stColor.pink, stColor.green },
            new stColor[12] { stColor.pink, stColor.green, stColor.green, stColor.yellow, stColor.yellow, stColor.yellow, stColor.blue, stColor.green, stColor.pink, stColor.green, stColor.blue, stColor.yellow }
        }
    };
}
