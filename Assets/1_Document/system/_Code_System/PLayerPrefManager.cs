using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PLayerPrefManager 
{
    public const string level = "HIGH_LEVEL";
    public const string score = "HIGH_SCORE";

    public const string sound = "Sound";
    public const string music = "Music";

    public static int HighLevel
    {
        get => PlayerPrefs.GetInt(level,0);
        set => PlayerPrefs.SetInt(level, value);
    }

    public static int HighScore
    {
        get => PlayerPrefs.GetInt(score,0);
        set => PlayerPrefs.SetInt(score, value);    
    }

    public static bool Sound
    {
        get => PlayerPrefs.GetInt(sound,1) == 1 ? true : false; 
        set => PlayerPrefs.SetInt(sound, value == true ? 1 : 0) ;
    }

    public static bool Music
    {
        get => PlayerPrefs.GetInt( music, 1) == 1 ? true : false;
        set => PlayerPrefs.SetInt(music, value == true ? 1 : 0);
    }
}
