using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMenu : UIToolkitElementWithExitOnButton
{
    [SerializeField] private LevelChoice _levelChoice;
    [SerializeField] private levelUp _levelUp;
    [SerializeField] private DictionaryUI _directoryUI;
    [SerializeField] private Menu _menu;

    protected override void Initialize()
    {
        base.Initialize();

        Button levels = UIElement.Q<Button>("Levels");
        Button levelUp = UIElement.Q<Button>("LevelUp");
        Button directory = UIElement.Q<Button>("Directory");
        Button exitToMenu = UIElement.Q<Button>("ExitToMenu");

        levels.clicked += _levelChoice.Open;
        levelUp.clicked += _levelUp.Open;
        directory.clicked += _directoryUI.Open;
        exitToMenu.clicked += _menu.Open;
    }
    public override void Open()
    {
        base.Open();
    }
}