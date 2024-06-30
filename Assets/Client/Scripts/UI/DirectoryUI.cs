using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DirectoryUI : UIToolkitElement
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Pause _pause;
    [SerializeField] private VisualTreeAsset _directoryAsset;
    [SerializeField] private List<EnemyDirectorySO> _enemyDirectory;

    private VisualElement _directory;

    protected override void Initialize()
    {
        _directory = _directoryAsset.CloneTree();
    }

    public void OpenDirectory()
    {
        ResetContainer(_directory);

        InitializeDirectoryScroll();

        Button back = _container.Q<Button>("Back");

        back.clicked += () =>
        {
            if (_menu != null)
            {
                _menu.OpenMenu();
            }
            else if (_pause != null)
            {
                _pause.OpenPause();
            }
        };
    }

    private void InitializeDirectoryScroll()
    {
        for(int i = 0; i < _enemyDirectory.Count; i++)
        {
            VisualElement currentEnemy = _container.Q<VisualElement>(_enemyDirectory[i].name.ToString());
            VisualElement ImageInScroll = currentEnemy.Q<VisualElement>("ImageInScroll");
            Label NameInScroll = currentEnemy.Q<Label>("NameInScroll");

            ImageInScroll.style.backgroundImage = _enemyDirectory[i]._enemyImage;
            NameInScroll.text = _enemyDirectory[i]._name;
        }
    }
}
