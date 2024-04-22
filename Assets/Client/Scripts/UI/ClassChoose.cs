using UnityEngine;
using UnityEngine.UIElements;

public class ClassChoose : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseClassAsset;
    [SerializeField] private ChooseLevelMenu _chooseLevel;

    private VisualElement _chooseClass;

    protected override void Initialize()
    {
        _chooseClass = _chooseClassAsset.CloneTree();
    }

    public void OpenClassChooser()
    {
        ResetContainer(_chooseClass);

        Button bacterial = _container.Q<Button>("Bacterial");

        bacterial.clicked += () =>
        {
            OnButton(0);
        };
    }
    private void OnButton(int index)
    {
        DataSave.PlayerCurrentData save = new();
        save.indexClassPlayer = index;
        _chooseLevel.OpenChooseLevelMenu();
    }
}
