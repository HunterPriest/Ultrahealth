using UnityEngine;

public static class Saver
{
    public static void Save<T>(string name, T saveData)
    {
        string jsonDataName = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(name, jsonDataName);
    }

    public static T Load<T>(string name) where T: new()
    {
        if (PlayerPrefs.HasKey(name))
        {
            string jsonDataName = PlayerPrefs.GetString(name);
            return JsonUtility.FromJson<T>(jsonDataName);
        }
        else
        {
            return new T();
        }
    }

    public static bool HasSave(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}