using UnityEngine;
using Models;
using System;

public class Saver 
{
    private const string saveString = "save_address";
    private const string loadFlag = "is_load";

    public static string SAVE_STRING => saveString;

    public static string LOAD_FLAG => loadFlag;

    public static void Save(Game gameData)
    {
        string saveDataString = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString(SAVE_STRING, saveDataString);
    }

    public static Game Load()
    {
        return JsonUtility.FromJson<Game>(PlayerPrefs.GetString(SAVE_STRING));
    }
}
