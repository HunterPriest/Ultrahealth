using UnityEngine.UIElements;
using UnityEngine;

public class ChooseSave : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseSaveAsset;
    [SerializeField] private ClassChoose _classChooser;

    private VisualElement _save;
    private VisualElement _panelNewSave;

    protected override void Initialize()
    {
        _save = _chooseSaveAsset.CloneTree();
        _panelNewSave = _save.Q<VisualElement>("PanelForNewSave");
        _panelNewSave.visible = false;
    }

    public void OpenSave()
    {
        ResetContainer(_save);

        Button save1 = _container.Q<Button>("Save1");
        Button save2 = _container.Q<Button>("Save2");
        Button save3 = _container.Q<Button>("Save3");
        Button save4 = _container.Q<Button>("Save4");

        save1.clicked += () => OnSaveButton(1);
        save2.clicked += () => OnSaveButton(2);
        save3.clicked += () => OnSaveButton(3);
        save4.clicked += () => OnSaveButton(4);
    }

    private void OnSaveButton(int index)
    {
        if (GameSaver.loadGameData(index) == null)
        {
            _panelNewSave.visible = true;
            NewSave();
        }
    }

    private void NewSave()
    {
        Button yes = _container.Q<Button>("Yes");
        Button no = _container.Q<Button>("No");

        yes.clicked += () => _classChooser.OpenClassChooser();
        no.clicked += () => _panelNewSave.visible = false;
    }
}
