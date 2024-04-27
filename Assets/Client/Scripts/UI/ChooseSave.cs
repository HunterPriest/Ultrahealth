using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.CodeDom.Compiler;

public class ChooseSave : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseSaveAsset;
    [SerializeField] private ClassChoose _classChooser;

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
        _panelNewSave = _save.Q<VisualElement>("PanelForNewSave");
        _panelNewSave.visible = false;
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
    }

    private void SubscribeButton(Button button)
    {
        if(Saver.HasSave(button.tabIndex))
        {
            button.text = "Save " + button.tabIndex.ToString();
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
        _playerSaver.ChangeCurrentPlayerData(playerData);
        _classChooser.OpenChooseLevel();
    }

    private void OnButtonWithoutSave(int indexSave)
    {
        _panelNewSave.visible = true;
        NewSave(indexSave);
    }

    private void NewSave(int indexSave)
    {
        Button yes = _container.Q<Button>("Yes");
        Button no = _container.Q<Button>("No");

        yes.clicked += () => OnClickYes(indexSave);
        no.clicked += () => _panelNewSave.visible = false;
    }

    private void OnClickYes(int indexSave)
    {
        _playerSaver.ChangeCurrentPlayerData(indexSave);
        _classChooser.OpenClassChooser();
    }
    
}
