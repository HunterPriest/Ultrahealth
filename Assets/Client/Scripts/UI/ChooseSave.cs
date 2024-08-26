using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChooseSave : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseSaveAsset;
    [SerializeField] private ClassChoose _classChooser;
    [SerializeField] private VisualTreeAsset _newSaveAsset;
    [SerializeField] private VisualTreeAsset _saveUIAsset;
    [SerializeField] private Menu _menu;

    private VisualElement _chooseSaveUI;
    private VisualElement _newSaveUI; 
    private GameConfigInstaller.SavesSettings _savesSettings;
    private PlayerSaver _playerSaver;
    private List<DataSave.PlayerData> _playersData = new List<DataSave.PlayerData>();
    private List<VisualElement> _savesUI = new List<VisualElement>();

    [Inject]
    private void Construct(PlayerSaver playerSaver, GameConfigInstaller.SavesSettings savesSettings)
    {
        _playerSaver = playerSaver;
        _savesSettings = savesSettings;
    }

    protected override void Initialize()
    {
        _chooseSaveUI = _chooseSaveAsset.CloneTree();
        _newSaveUI = _newSaveAsset.CloneTree();


        ScrollView saves = _chooseSaveUI.Q<ScrollView>("Saves");
        saves.Add(_newSaveUI);              

        int i = 1;
        while(Saver.HasSave(i.ToString()))
        {
            VisualElement saveUI = _saveUIAsset.CloneTree();
            _savesUI.Add(saveUI);
            saves.Add(saveUI);
            _playersData.Add(_playerSaver.LoadPlayerData(i));
            Button playerSave = saves.Q<Button>("SaveButton");
            playerSave.name = "Save" + i.ToString();
            if(_playersData[i - 1].name != null)
            {
                playerSave.text = _playersData[i - 1].name;
            }
            else
            {
                playerSave.text = "Roflo hahahah";
            }
            playerSave.tabIndex = i;
            i++;
        }

        saves.Add(_newSaveUI);          

        Button exit = _chooseSaveUI.Q<Button>("Exit");
        exit.clicked += _menu.OpenMenu;
    }

    private void UpdateSavesButtons()
    {
        int i = 1;
        while(Saver.HasSave(i.ToString()))
        {
            VisualElement saveUI = _saveUIAsset.CloneTree();
            _savesUI.Add(saveUI);
            saves.Add(saveUI);
            _playersData.Add(_playerSaver.LoadPlayerData(i));
            Button playerSave = saves.Q<Button>("SaveButton");
            playerSave.name = "Save" + i.ToString();
            if(_playersData[i - 1].name != null)
            {
                playerSave.text = _playersData[i - 1].name;
            }
            else
            {
                playerSave.text = "Roflo hahahah";
            }
            playerSave.tabIndex = i;
            i++;
        }

        saves.Add(_newSaveUI);
    }

    public void OpenSave()
    {
        ResetContainer(_chooseSaveUI);
    }

    private void SubscribeButton(Button button)
    {
        if(Saver.HasSave(button.tabIndex.ToString()))
        {
            button.clicked += () => OnButtonWithSave(button.tabIndex);
        }
        else
        {
            button.clicked += () => NewSave(button.tabIndex);
        }
    }

    private void OnButtonWithSave(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(_playersData[indexSave - 1], indexSave);
        _classChooser.OpenChooseLevel();
    }

    private void OnClickYes(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(indexSave);
        _classChooser.OpenClassChooser();
    }
}
