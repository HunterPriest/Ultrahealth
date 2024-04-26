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

        DataSave.PlayerCurrentData save = new DataSave.PlayerCurrentData();
        bf.Serialize(fs, save);
        fs.Close();
    }

    public static DataSave.PlayerCurrentData loadGameData(int numberSave)
    {
        string filePath = Application.persistentDataPath + "/savegame." + numberSave.ToString() + ".save";
        if (!File.Exists(filePath)) return null;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        DataSave.PlayerCurrentData save = bf.Deserialize(fs) as DataSave.PlayerCurrentData;

        fs.Close();
        return save;
    }
}
