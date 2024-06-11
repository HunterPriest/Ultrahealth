using UnityEngine;
using Zenject;

public class SettingsSaver
{
    const string _SAVE_SETTINGS_NAME = "settings";
    public DataSave.SettingsData currentSave { get; private set; }

    public SettingsSaver(GameConfigInstaller.StandartSettings standartSettings)
    {   
        if(!Saver.HasSave(_SAVE_SETTINGS_NAME))
        {
            CreateNewSettingsSave(standartSettings);
        }

        currentSave = LoadSave();
    }

    public void SaveCurrentSave()
    {
        SaveSettingsData(currentSave);
    }

    public void CreateNewSettingsSave(GameConfigInstaller.StandartSettings standartSettings)
    {
        DataSave.SettingsData settingsData = new();
        settingsData.sens = standartSettings.sens;
        SaveSettingsData(settingsData);
    }

    private DataSave.SettingsData LoadSave()
    {
        return Saver.Load<DataSave.SettingsData>(_SAVE_SETTINGS_NAME);
    }

    public void SaveSettingsData(DataSave.SettingsData settingsData)
    {
        Saver.Save<DataSave.SettingsData>(_SAVE_SETTINGS_NAME, settingsData);
    }   
}