using UnityEngine;

public static class PlayerPrefs
{
    public static int coins = 0;
    public static int keys = 0;
    public static bool isAndroidBuild = false;
    public static void AddCoin() {
        coins+=5;
    }
    public static void AddKey() {
        keys++;
    }
    public static void SubtractKey() {
        keys--;
    }
}
