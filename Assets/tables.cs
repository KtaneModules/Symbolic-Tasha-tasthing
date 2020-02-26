public static class Tables
{
    // 1 = Hook
    // 2 = Wand
    // 3 = Yankee
    // 4 = Lightning
    // 5 = India
    // 6 = Angle
    // 7 = Kilo
    // 8 = Flag w/ Hole
    // 9 = Foxtrot
    // 10 = Antenna
    // 11 = Compass
    // 12 = Half-Fire
    // 13 = Left Triangle
    // 14 = Circle
    // 15 = Shelf
    // 16 = Curve
    // 17 = Lollipop
    // 18 = Flag w/o Hole
    // -x = Cracked variant of x
    public static readonly int[][][] symbolColumns = new int[4][][]
    {
        new int[12][]
        {
            new int[] { 1, 9 },
            new int[] { 2, -3 },
            new int[] { -2, -5 },
            new int[] { 3, -10 },
            new int[] { -4, -11 },
            new int[] { 5, 10 },
            new int[] { -6, -12 },
            new int[] { 7, 13 },
            new int[] { -1, -9 },
            new int[] { -7, -13 },
            new int[] { -8, 6 },
            new int[] { 4, 11 }
        },
        new int[12][]
        {
            new int[] { -12, 9 },
            new int[] { 2, -3 },
            new int[] { -11, -5 },
            new int[] { 3, 1 },
            new int[] { -4, -14 },
            new int[] { 6, 4 },
            new int[] { 14, 15 },
            new int[] { -13, -9 },
            new int[] { -1, 13 },
            new int[] { 12, 7 },
            new int[] { -8, 16 },
            new int[] { 8, 11 }
        },
        new int[12][]
        {
            new int[] { 17, 6 },
            new int[] { -1, -5 },
            new int[] { 9, -18 },
            new int[] { 18, 8 },
            new int[] { 4, 2 },
            new int[] { -6, 14 },
            new int[] { 11, -3 },
            new int[] { -16, 5 },
            new int[] { -17, -2 },
            new int[] { -15, 10 },
            new int[] { 1, -14 },
            new int[] { 16, -8 }
        },
        new int[12][]
        {
            new int[] { 11, -5 },
            new int[] { 5, -12 },
            new int[] { -2, -16 },
            new int[] { 16, 14 },
            new int[] { -4, 15 },
            new int[] { -10, 3 },
            new int[] { -6, -17 },
            new int[] { 10, 17 },
            new int[] { -1, -3 },
            new int[] { -7, -15 },
            new int[] { 12, 6 },
            new int[] { -13, 11 }
        },
    };
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // 0 = Pink
    // 1 = Green
    // 2 = Yellow
    // 3 = Blue
    public static readonly int[][][] colorRows = new int[4][][]
    {
        new int[4][]
        {
            new int[12] { 1, 0, 1, 1, 0, 3, 3, 1, 0, 0, 2, 1 },
            new int[12] { 0, 1, 3, 2, 1, 1, 0, 3, 1, 3, 1, 3 },
            new int[12] { 2, 3, 2, 0, 2, 2, 2, 0, 2, 1, 0, 2 },
            new int[12] { 3, 2, 0, 3, 3, 0, 1, 2, 3, 2, 3, 0 }
        },
        new int[4][]
        {
            new int[12] { 1, 0, 2, 2, 0, 3, 0, 3, 1, 0, 1, 1 },
            new int[12] { 2, 3, 0, 1, 1, 0, 2, 1, 0, 3, 3, 2 },
            new int[12] { 3, 2, 3, 0, 2, 2, 1, 0, 3, 1, 0, 3 },
            new int[12] { 0, 1, 1, 3, 3, 1, 3, 2, 2, 2, 2, 0 }
        },
        new int[4][]
        {
            new int[12] { 3, 3, 1, 3, 0, 1, 2, 2, 1, 2, 0, 3 },
            new int[12] { 1, 0, 0, 1, 2, 0, 3, 0, 2, 0, 1, 1 },
            new int[12] { 0, 2, 3, 0, 3, 3, 1, 1, 3, 1, 2, 0 },
            new int[12] { 2, 1, 2, 2, 1, 2, 0, 3, 0, 3, 3, 2 }
        },
        new int[4][]
        {
            new int[12] { 2, 0, 3, 3, 3, 1, 0, 0, 3, 2, 1, 0 },
            new int[12] { 1, 2, 2, 0, 1, 0, 1, 3, 1, 0, 2, 3 },
            new int[12] { 3, 3, 0, 1, 0, 3, 2, 2, 2, 3, 0, 1 },
            new int[12] { 0, 1, 1, 2, 2, 2, 3, 1, 0, 1, 3, 2 }
        }
    };
}
