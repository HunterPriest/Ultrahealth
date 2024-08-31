using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class SaveChoice : UIToolkitElementWithExitOnButton
{
    [SerializeField] private ClassChoice _classChooser;
    [SerializeField] private PlayerMenu _playerMenu;
    [SerializeField] private VisualTreeAsset _saveButtonAsset;

    private PlayerSaver _playerSaver;
    private int _indexNewSave;
    private List<DataSave.PlayerData> _playersData = new List<DataSave.PlayerData>();
    private List<VisualElement> _saveButtons = new List<VisualElement>();
    private VisualElement _savesContainer;

    [Inject]
    public void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Button plus = UIElement.Q<Button>("Plus");
        plus.clicked += () => CreateNewSave(_indexNewSave);
        _savesContainer = UIElement.Q<VisualElement>("SaveConteyner");
        InitializeSavesButtons();
        _playerSaver.OnCreatedNewSave += UpdateSavesButtons;
    }

    private void UpdateSavesButtons()
    {
        RemoveSaveButtons();
        _saveButtons.Clear();
        _playersData.Clear();
        InitializeSavesButtons();
    }

    private void InitializeSavesButtons()
    {
        int i = 1;
        while (Saver.HasSave(i.ToString()))
        {
            VisualElement saveButton = _saveButtonAsset.CloneTree();

            _saveButtons.Add(saveButton);
            _savesContainer.Add(saveButton);

            Button button = _savesContainer.Q<Button>("SaveButton");
            Label saveName = _savesContainer.Q<Label>("SaveName");

            button.name = "Save" + i.ToString();
            saveName.name = "SaveName" + i.ToString();

            _playersData.Add(_playerSaver.LoadPlayerData(i));

            saveName.text = _playersData[i - 1].name;
            button.tabIndex = i;
            i++;
            SubscribeButton(button);
        }

        _indexNewSave = i++;
    }

    private void RemoveSaveButtons()
    {
        foreach(VisualElement element in _saveButtons)
        {
            _savesContainer.Remove(element);
        }
    }

    private void SubscribeButton(Button button)
    {
        button.clicked += () => OnButtonSave(button.tabIndex);
    }

    private void OnButtonSave(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(_playersData[indexSave - 1], indexSave);
        _playerMenu.Open();
    }

    private void CreateNewSave(int index)
    {
        TextField saveTextField = _container.Q<TextField>("NewSaveName");

        if (saveTextField.value != null && saveTextField.value != "Ведите имя...")
        {
            _playerSaver.ChangeCurrentSave(index, saveTextField.value);
            saveTextField.value = "Ведите имя...";
            _classChooser.Open();
        }
    }
}
