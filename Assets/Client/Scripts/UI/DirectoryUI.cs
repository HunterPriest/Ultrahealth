using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class DictionaryUI : UIToolkitElementWithExitOnButton
{
    [SerializeField] private Pause _pause;
    private List<EnemyDirectorySO> _enemyDirectory;

    protected override void Initialize()
    {
        base.Initialize();

        _enemyDirectory = new List<EnemyDirectorySO>();
    }

    public override void Open()
    {
        base.Open();

        InitializeDirectoryScroll();
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

    public void AddEnemyDirectorySO(LevelSettings level)
    {
        List<EnemyDirectorySO> _enemies = level.GetEnemyDirectorySO();
        for(int i = 0; i<_enemies.Count; i++)
        {
            _enemyDirectory.Add(_enemies[i]);
        }
    }
}
