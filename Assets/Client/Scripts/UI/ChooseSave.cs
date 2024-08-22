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

        Button[] buttonsSaves = new Button[_savesSettings.amountSaves];
        int[] buttonsIndexes = new int[_savesSettings.amountSaves];

        for (int i = 0; i < _savesSettings.amountSaves; i++)
        {
            buttonsIndexes[i] = i;
            buttonsSaves[i] = _save.Q<Button>("Save" + (i + 1).ToString());
            SubscribeButton(buttonsSaves[i]);
        }

        Button exit = _save.Q<Button>("Exit");
        exit.clicked += _menu.OpenMenu;
    }

    public void OpenSave()
    {
        ResetContainer(_save);
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
            button.clicked += () => NewSave(button.tabIndex);
        }
    }

    private void OnButtonWithSave(int indexSave)
    {
        DataSave.PlayerData playerData = _playerSaver.LoadPlayerData(indexSave);
        _playerSaver.ChangeCurrentSave(playerData, indexSave);
        _classChooser.OpenChooseLevel();
    }

    private void NewSave(int indexSave)
    {
        _container.Add(_panelNewSave);

        Button yes = _container.Q<Button>("Yes");
        Button no = _container.Q<Button>("No");

        yes.clicked += () =>
        {
            OnClickYes(indexSave);
            yes.clicked -= () => { };
        };
        no.clicked += () =>
        {
            OpenSave();
            no.clicked -= () => { };
        };
    }

    private void OnClickYes(int indexSave)
    {
        _playerSaver.ChangeCurrentSave(indexSave);
        _classChooser.OpenClassChooser();
    }
}
