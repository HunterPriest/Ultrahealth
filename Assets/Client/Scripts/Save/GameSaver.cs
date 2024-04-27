using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class GameSaver 
{
    public static void SaveGame(int numberSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/savegame." + numberSave.ToString()+ ".save";
        FileStream fs = new FileStream(filePath, FileMode.Create);

        DataSave.PlayerData save = new DataSave.PlayerData();
        bf.Serialize(fs, save);
        fs.Close();
        MonoBehaviour.print("Save data: " + numberSave.ToString());
    }

    public static DataSave.PlayerData loadGameData(int numberSave)
    {
        string filePath = Application.persistentDataPath + "/savegame." + numberSave.ToString() + ".save";
        if (!File.Exists(filePath)) return null;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        DataSave.PlayerData save = bf.Deserialize(fs) as DataSave.PlayerData;

        fs.Close();
        return save;
    }
}
