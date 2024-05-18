using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using System.Collections;
using System;
using ModestTree;

public class levelUp : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _levelUpAsset;
    [SerializeField] private ChooseLevelMenu _chooseLevelMenu;
    [SerializeField] private Color _skillButtonColor;
    [SerializeField] private Color _buyedSkillButtonColor;

    private VisualElement _levelUp;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.LevelUpSettings _levelUpSettings;
    private GameConfigInstaller.LevelUpSettings.Tree _currentClassTree;
    private Label _playerStats;
    private Label _notEnoughExperience;
    private Label _descriptionSkill;
    private Button _levelUpButton;
    private Button _currentSkillButton;
    private int _currentIndexSkill;

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

        _currentClassTree = _levelUpSettings.GetTree(_playerSaver.currentSave.playerSave.indexClassPlayer);
        _playerSaver.currentSave.playerSave.experience = 500000;
        _playerSaver.currentSave.playerSave.currentTree = new int[3]{0, 0, 0};
        _playerSaver.SaveCurrentSave();

        _playerStats = _container.Q<Label>("PlayerStats");
        UpdatePlayerStats();

        Button exit = _container.Q<Button>("Exit");
        exit.clicked += _chooseLevelMenu.OpenChooseLevelMenu;

        _descriptionSkill = _container.Q<Label>("Description");
        _levelUpButton = _container.Q<Button>("LevelUp");
        _levelUpButton.visible = false;

        _notEnoughExperience = _container.Q<Label>("NotEnoughExperience");

        Button[] levelUpButtons = new Button[_currentClassTree.skills.Length];

        for(int i = 0; i < levelUpButtons.Length; i++)
        {
            levelUpButtons[i] = _container.Q<Button>(_currentClassTree.skills[i].branchIndex.ToString() +
             _currentClassTree.skills[i].branchFloor.ToString());
            SubscribeSkillButton(levelUpButtons[i], _currentClassTree.skills[i].branchFloor, _currentClassTree.skills[i].branchIndex, i);
        }
      }

    private void UpdatePlayerStats()
    {
        _playerStats.text = _playerSaver.currentSave.StatsToString();
    }

    private void SubscribeSkillButton(Button button, int branchFloor, int branchIndex, int indexSkill)
    {
        if(_playerSaver.currentSave.playerSave.currentTree[branchIndex - 1] == branchFloor - 1)
        {
            button.clicked += () => OnClickSkillButton(button, indexSkill);
        }
        else
        {
            button.style.backgroundColor = _buyedSkillButtonColor;
        }
    }

    private void WithdrawDescriptionSkill(Skill skill)
    {
        _descriptionSkill.text = skill.description;
    }

    private void OnClickSkillButton(Button button, int indexSkill)
    {
        _levelUpButton.visible = true;
        _currentIndexSkill = indexSkill;
        StopCoroutine(LevelUpButtonHide());
        StartCoroutine(LevelUpButtonHide());
        WithdrawDescriptionSkill(_currentClassTree.skills[_currentIndexSkill]);
        _currentSkillButton = button;
        _levelUpButton.clicked += OnClickLevelUpButton;
    }

    private void OnClickLevelUpButton()
    {
        bool isBuyed = _currentClassTree.skills[_currentIndexSkill].TryBuy(_playerSaver);
        if(!isBuyed)
        {
            _notEnoughExperience.text = "Not enough experience";
            StopCoroutine(NotEnoughExperienceHide());
            StartCoroutine(NotEnoughExperienceHide());
        }
        else if (isBuyed)
        {
            print(_currentClassTree.skills[_currentIndexSkill]);
            for(int i = 0; i < _currentClassTree.skills[_currentIndexSkill].nextSkills.Length; i++)
            {
                Button button = _container.Q<Button>(_currentClassTree.skills[_currentIndexSkill].nextSkills[i].branchIndex.ToString() + 
                _currentClassTree.skills[_currentIndexSkill].nextSkills[i].branchFloor.ToString());
                button.style.backgroundColor = _skillButtonColor;
                SubscribeSkillButton(button, _currentClassTree.skills[_currentIndexSkill].nextSkills[i].branchFloor, 
                _currentClassTree.skills[_currentIndexSkill].nextSkills[i].branchIndex, _currentClassTree.skills[_currentIndexSkill].nextSkills[i].id);
            }
            _currentSkillButton.style.backgroundColor = _buyedSkillButtonColor;
            _currentSkillButton.clickable.activators.Clear();
            UpdatePlayerStats();
        }   
        StopCoroutine(LevelUpButtonHide());
        _levelUpButton.visible = false;
        _currentIndexSkill = 0;
        _levelUpButton.clicked -= OnClickLevelUpButton;
    }

    private IEnumerator NotEnoughExperienceHide()
    {
        yield return new WaitForSeconds(3);
        _notEnoughExperience.visible = false;
        _levelUpButton.clickable.activators.Clear();
    }

    private IEnumerator LevelUpButtonHide()
    {
        yield return new WaitForSeconds(3);
        _currentIndexSkill = 0;
        _levelUpButton.visible = false;
        _descriptionSkill.text = " ";
        _levelUpButton.clicked -= OnClickLevelUpButton;
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
        _currentClassTree = null;
    }
}