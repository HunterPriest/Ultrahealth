using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using System.Collections;
using System;
using ModestTree;

public class levelUp : UIToolkitElement
{
    [SerializeField] private ChooseLevelMenu _chooseLevelMenu;
    [SerializeField] private Color _skillButtonColor;
    [SerializeField] private Color _buyedSkillButtonColor;

    [Header("Branches Assets")]
    [SerializeField] private VisualTreeAsset _BacteriaLevelUpAsset;
    [SerializeField] private VisualTreeAsset _NanoRobotLevelUpAsset;
    [SerializeField] private VisualTreeAsset _SinglecellLevelUpAsset;

    private VisualElement _bacteriaLevelUp;
    private VisualElement _nanoRobotLevelUp;
    private VisualElement _singlecellLevelUp;

    private PlayerSaver _playerSaver;
    private GameConfigInstaller.LevelUpSettings _levelUpSettings;
    private GameConfigInstaller.LevelUpSettings.Tree _currentClassTree;

    private Label _playerStats;
    private Label _notEnoughExperience;
    private Label _descriptionSkill;

    private Button _levelUpButton;
    private Button _currentSkillButton;
    Button[] _levelUpButtons;


    private int _currentIndexSkill;

    [Inject]
    private void Construct(PlayerSaver playerSaver, GameConfigInstaller.LevelUpSettings levelUpSettings)
    {   
        _playerSaver = playerSaver;
        _levelUpSettings = levelUpSettings;
    }

    protected override void Initialize()
    {
        _bacteriaLevelUp = _BacteriaLevelUpAsset.CloneTree();
        _nanoRobotLevelUp = _NanoRobotLevelUpAsset.CloneTree();
        _singlecellLevelUp = _SinglecellLevelUpAsset.CloneTree();
    }

    public void OpenLevelUp()
    {
        _currentClassTree = _levelUpSettings.GetTree(_playerSaver.currentSave.playerSave.indexClassPlayer);

        StartOpen(_playerSaver.currentSave.playerSave.indexClassPlayer);

        _playerStats = _container.Q<Label>("PlayerStats");
        UpdatePlayerStats();

        Button exit = _container.Q<Button>("Exit");
        exit.clicked += () => 
        {
            exit.clicked -= () => { };
            _levelUpButton.clicked -= () => { };
            foreach (Button button in _levelUpButtons)
            {
                button.clicked -= () => { };
            }
            _chooseLevelMenu.OpenChooseLevelMenu();
        };

        _descriptionSkill = _container.Q<Label>("Description");
        _levelUpButton = _container.Q<Button>("LevelUp");
        _levelUpButton.visible = false;

        _notEnoughExperience = _container.Q<Label>("NotEnoughExperience");

        _levelUpButtons = new Button[_currentClassTree.skills.Length];

        for(int i = 0; i < _levelUpButtons.Length; i++)
        {
            _levelUpButtons[i] = _container.Q<Button>(_currentClassTree.skills[i].branchIndex.ToString() +
             _currentClassTree.skills[i].branchFloor.ToString());
            SubscribeSkillButton(_levelUpButtons[i], _currentClassTree.skills[i].branchFloor, _currentClassTree.skills[i].branchIndex, i);
        }
    }

    private void StartOpen(int index)
    {
        switch (index)
        {
            case 1:
                {
                    ResetContainer(_bacteriaLevelUp);
                    break;
                }
            case 2:
                {
                    ResetContainer(_nanoRobotLevelUp);
                    break;
                }
            case 3:
                {
                    ResetContainer(_singlecellLevelUp);
                    break;
                }
        }
    }

    private void UpdatePlayerStats()
    {
        _playerStats.text = _playerSaver.currentSave.StatsToString();
    }

    private void SubscribeSkillButton(Button button, int branchFloor, int branchIndex, int indexSkill)
    {
        if(_playerSaver.currentSave.playerSave.tree[branchIndex - 1] == branchFloor - 1)
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