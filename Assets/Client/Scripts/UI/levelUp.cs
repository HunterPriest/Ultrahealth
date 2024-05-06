using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class levelUp : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _levelUpAsset;
    [SerializeField] private ChooseLevelMenu _chooseLevelMenu;

    private VisualElement _levelUp;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.LevelUpSettings _levelUpSettings;
    private GameConfigInstaller.LevelUpSettings.Tree _currentClassTree;

    [Inject]
    private void Construct(PlayerSaver playerSaver, GameConfigInstaller.LevelUpSettings levelUpSettings)
    {   
        _playerSaver = playerSaver;
        _levelUpSettings = levelUpSettings;
    }

    protected override void Initialize()
    {
        _levelUp = _levelUpAsset.CloneTree();

    }

    public void OpenLevelUp()
    {
        ResetContainer(_levelUp);

        _currentClassTree = _levelUpSettings.GetTree(_playerSaver.currentSave.currentPlayerSave.indexClassPlayer);

        Label experience = _container.Q<Label>("Experience");
        experience.text = "Experience: " + _playerSaver.currentSave.currentPlayerSave.experience.ToString();

        Button exit = _container.Q<Button>("Exit");
        exit.clicked += _chooseLevelMenu.OpenChooseLevelMenu;
        

        Button[] levelUpButtons = new Button[_currentClassTree.skills.Length];

        for(int i = 0; i < levelUpButtons.Length; i++)
        {
            levelUpButtons[i] = _container.Q<Button>(_currentClassTree.skills[i].branchIndex.ToString() + _currentClassTree.skills[i].branchFloor.ToString());

        }
    }

    private void SubscribeSkillButton(Button button, Skill skill)
    {
        // if(_playerSaver.currentSave.currentPlayerSave.currentTree[skill.branchIndex] >= button.text.at)
        {

        }
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
        _currentClassTree = null;
    }
}