using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.CodeDom.Compiler;
using System.Collections;

public class ChooseSave : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseSaveAsset;
    [SerializeField] private ClassChoose _classChooser;
    [SerializeField] private VisualTreeAsset _panelForSaveCreateAsset;
    [SerializeField] private Menu _menu;

    private VisualElement _save;
    private VisualElement _panelNewSave;
    private GameConfigInstaller.SavesSettings _savesSettings;
    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(PlayerSaver playerSaver, GameConfigInstaller.SavesSettings savesSettings)
    {
        _playerSaver = playerSaver;
        _savesSettings = savesSettings;
    }

    protected override void Initialize()
    {
        _save = _chooseSaveAsset.CloneTree();
        _panelNewSave = _panelForSaveCreateAsset.CloneTree();
    }

    public void OpenSave()
    {
        ResetContainer(_save);

        Button[] buttonsSaves = new Button[_savesSettings.amountSaves];
        int[] buttonsIndexes = new int[_savesSettings.amountSaves];

        for(int i = 1; i < _savesSettings.amountSaves + 1; i++)
        {
            buttonsIndexes[i - 1] = i;
            buttonsSaves[i - 1] = _container.Q<Button>("Save" + i.ToString());
            SubscribeButton(buttonsSaves[i - 1]);
        }

        Button exit = _container.Q<Button>("Exit");
        exit.clicked += _menu.OpenMenu;
    }

    private void SubscribeButton(Button button)
    {
        if(Saver.HasSave(button.tabIndex.ToString()))
        {
            button.text = "Сохранение " + button.tabIndex.ToString();
            button.clicked += () => OnButtonWithSave(button.tabIndex);
        }
        else
        {
            button.clicked += () => OnButtonWithoutSave(button.tabIndex);
        }
    }

    private void OnButtonWithSave(int indexSave)
    {
        DataSave.PlayerData playerData = _playerSaver.LoadPlayerData(indexSave);
        _playerSaver.ChangeCurrentSave(playerData, indexSave);
        _classChooser.OpenChooseLevel();
    }

    private void OnButtonWithoutSave(int indexSave)
    {
        _save.Add(_panelNewSave);
        NewSave(indexSave);
    }

    private void NewSave(int indexSave)
    {
        Button yes = _container.Q<Button>("Yes");
        Button no = _container.Q<Button>("No");

        yes.clicked += () => OnClickYes(indexSave);
        no.clicked += () => _save.Remove(_panelNewSave);
    }

    private void OnClickYes(int indexSave)
    {
        _save.Remove(_panelNewSave);
        _playerSaver.ChangeCurrentSave(indexSave);
        _classChooser.OpenClassChooser();
    }
}
