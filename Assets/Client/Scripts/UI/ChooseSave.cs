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
    [SerializeField] private VisualTreeAsset _saveButtonAsset;
    [SerializeField] private Menu _menu;

    private VisualElement _chooseSaveUI;
    private VisualElement _saveButton;
    private PlayerSaver _playerSaver;
    private List<DataSave.PlayerData> _playersData = new List<DataSave.PlayerData>();

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _chooseSaveUI = _chooseSaveAsset.CloneTree();
        _saveButton = _saveButtonAsset.CloneTree();

        Button plus = _chooseSaveUI.Q<Button>("Plus");
        plus.clicked += CreateNewSave;

        Button exit = _chooseSaveUI.Q<Button>("Exit");
        exit.clicked += _menu.OpenMenu;
    }

    public void OpenSave()
    {
        ResetContainer(_chooseSaveUI);

        Button button = _saveButton.Q<Button>("Button");
        Label saveName = _saveButton.Q<Label>("SaveName");

        VisualElement savesConteyner = _chooseSaveUI.Q<VisualElement>("SaveConteyner");

        int i = 1;
        while (Saver.HasSave(i.ToString()))
        {
            button.name = "Save" + i.ToString();

            _playersData.Add(_playerSaver.LoadPlayerData(i));
            if (_playersData[i - 1].name != null)
            {
                saveName.text = _playersData[i - 1].name;
            }
            else
            {
                saveName.text = "Roflo hahahah";
            }
            button.tabIndex = i;
            i++;
            savesConteyner.Add(_saveButton);
            SubscribeButton(button);
        }
    }

    private void SubscribeButton(Button button)
    {
        button.clicked += () =>
        {
            OnButtonWithSave(button.tabIndex);
            button.clicked -= () => { };
        };
    }

    private void OnButtonWithSave(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(_playersData[indexSave - 1], indexSave);
        _classChooser.OpenChooseLevel();
    }

    private void CreateNewSave()
    {
        TextField saveName = _container.Q<TextField>("NewSaveName");

        if (saveName.value != null && saveName.value != "¬ведите им€...")
        {

        }
    }
}
