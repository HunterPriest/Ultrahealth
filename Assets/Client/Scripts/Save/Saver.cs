using UnityEngine;

public static class Saver
{
    public static void Save<T>(int indexSave, T saveData)
    {
        string jsonDataName = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(indexSave.ToString(), jsonDataName);
    }

    public static T Load<T>(int indexSave) where T: new()
    {
        if (PlayerPrefs.HasKey(indexSave.ToString()))
        {
            string jsonDataName = PlayerPrefs.GetString(indexSave.ToString());
            return JsonUtility.FromJson<T>(jsonDataName);
        }
        else
        {
            return new T();
        }
    }

    public static bool HasSave(int indexSave)
    {
        if (PlayerPrefs.HasKey(indexSave.ToString()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}