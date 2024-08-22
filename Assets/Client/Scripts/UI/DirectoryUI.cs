using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DirectoryUI : UIToolkitElement
{
    [SerializeField] private ChooseLevelMenu _chooseLevelMenu;
    [SerializeField] private Pause _pause;
    [SerializeField] private VisualTreeAsset _directoryAsset;
    [SerializeField] private List<EnemyDirectorySO> _enemyDirectory;

    private VisualElement _directory;

    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _directory = _directoryAsset.CloneTree();
    }

    public void OpenDirectory()
    {
        ResetContainer(_directory);

        _enemyDirectory = _playerSaver.currentSave._killEnemies;

        InitializeDirectoryScroll();

        Button back = _container.Q<Button>("Back");

        back.clicked += () =>
        {
            if (_chooseLevelMenu != null)
            {
                _chooseLevelMenu.OpenChooseLevelMenu();
            }
            else if (_pause != null)
            {
                _pause.OpenPause();
            }
        };
    }

    private void InitializeDirectoryScroll()
    {
        if (_enemyDirectory == null) return;
        else
        {
            for (int i = 0; i < _enemyDirectory.Count; i++)
            {
                VisualElement currentEnemy = _container.Q<VisualElement>(_enemyDirectory[i].name.ToString());
                Button currentButton = _container.Q<Button>(_enemyDirectory[i].name.ToString());
                VisualElement ImageInScroll = currentEnemy.Q<VisualElement>("ImageInScroll");
                Label NameInScroll = currentEnemy.Q<Label>("NameInScroll");

                ImageInScroll.style.backgroundImage = _enemyDirectory[i]._enemyImage;
                NameInScroll.text = _enemyDirectory[i]._name;
                currentButton.clicked += () => OpenButton(currentButton);
            }
        }
    }

    private void OpenButton(Button button)
    {
        for (int i = 0; i < _enemyDirectory.Count; i++)
        {
            if (_enemyDirectory[i].name == button.name)
            {
                EnemyDirectorySO CurrentElement = _enemyDirectory[i];

                VisualElement image = _container.Q<VisualElement>("Image");
                Label name = _container.Q<Label>("Name");
                Label about = _container.Q<Label>("About");

                image.style.backgroundImage = CurrentElement._enemyImage;
                name.text = CurrentElement._name;
                about.text = CurrentElement._aboutEnemy;
            }
        }

        
    }
}
