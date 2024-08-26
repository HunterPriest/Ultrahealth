using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SaveChoice : UIToolkitElementWithExitOnButton
{
    [SerializeField] private ClassChoice _classChooser;
    [SerializeField] private PlayerMenu _playerMenu;
    [SerializeField] private VisualTreeAsset _saveButtonAsset;

    private VisualElement _saveButton;
    private PlayerSaver _playerSaver;
    private int _indexNewSave;
    private List<DataSave.PlayerData> _playersData = new List<DataSave.PlayerData>();
    private Input.UIActions _UIActions;

    [Inject]
    public void Construct(InputManager inputManager, PlayerSaver playerSaver)
    {
        _UIActions = inputManager.UIActions;
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Button plus = UIElement.Q<Button>("Plus");
        plus.clicked += () => CreateNewSave(_indexNewSave);
    }

    public override void Open()
    {   
        base.Open();

        VisualElement savesConteyner = UIElement.Q<VisualElement>("SaveConteyner");

        int i = 1;
        while (Saver.HasSave(i.ToString()))
        {
            VisualElement saveButton = _saveButtonAsset.CloneTree();
            savesConteyner.Add(saveButton);
            Button button = savesConteyner.Q<Button>("SaveButton");
            Label saveName = savesConteyner.Q<Label>("SaveName");
            button.name = "Save" + i.ToString();
            saveName.name = "SaveName" + i.ToString();

            _playersData.Add(_playerSaver.LoadPlayerData(i));
            if (_playersData[i - 1].name != null)
            {
                saveName.text = _playersData[i - 1].name;
            }
            else
            {
                saveName.text = i.ToString();
            }
            button.tabIndex = i;
            i++;
            SubscribeButton(button);
        }

        _indexNewSave = i++;
    }

    private void SubscribeButton(Button button)
    {
        button.clicked += () =>
        {
            OnButtonSave(button.tabIndex);
            button.clicked -= () => { };
        };
    }

    private void OnButtonSave(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(_playersData[indexSave - 1], indexSave);
        _playerMenu.Open();
    }

    private void CreateNewSave(int index)
    {
        TextField saveName = _container.Q<TextField>("NewSaveName");

        if (saveName.value != null && saveName.value != "Ведите имя...")
        {
            _playerSaver.ChangeCurrentSave(index, saveName.value);
            _classChooser.Open();
        }
    }
}
