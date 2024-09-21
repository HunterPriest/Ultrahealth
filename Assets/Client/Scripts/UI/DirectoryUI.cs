using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
public class DictionaryUI : UIToolkitElementWithExitOnButton
{
    [SerializeField] private List<WeaponInDirectory> _weaponInDirectory;
    private List<EnemyDirectorySO> _enemyDirectory;

    private PlayerSaver _playerSaver;

    private VisualElement _image;
    private Label _name;
    private Label _about;

    [Inject]
    public void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _image = UIElement.Q<VisualElement>("Image");
        _name = UIElement.Q<Label>("Name");
        _about = UIElement.Q<Label>("About");

        InitializeWeapon();

        _enemyDirectory = new List<EnemyDirectorySO>();
        
    }

    public override void Open()
    {
        base.Open();

        _enemyDirectory = _playerSaver.currentSave.playerSave.killEnemies;

        InitializeEnemyInDirectoryScroll();
    }

    private void InitializeEnemyInDirectoryScroll()
    {
        if (_enemyDirectory != null)
        { 
            for (int i = 0; i < _enemyDirectory.Count; i++)
            {
                VisualElement currentEnemy = _container.Q<VisualElement>(_enemyDirectory[i].name.ToString());
                Button currentButton = _container.Q<Button>(_enemyDirectory[i].name.ToString());
                VisualElement ImageInScroll = currentEnemy.Q<VisualElement>("ImageInScroll");
                Label NameInScroll = currentEnemy.Q<Label>("NameInScroll");

                ImageInScroll.style.backgroundImage = _enemyDirectory[i]._enemyImage;
                NameInScroll.text = _enemyDirectory[i]._name;
                currentButton.clicked += () => OpenButtonEnemy(currentButton);
            }
        }
    }

    private void InitializeWeapon()
    {
        if (_weaponInDirectory != null)
        {
            for (int i = 0; i < _weaponInDirectory.Count; i++)
            {
                VisualElement currentWeapon = UIElement.Q<VisualElement>(_weaponInDirectory[i].name.ToString());
                Button currentButton = UIElement.Q<Button>(_weaponInDirectory[i].name.ToString());
                VisualElement ImageInScroll = currentWeapon.Q<VisualElement>("ImageInScroll");
                Label NameInScroll = currentWeapon.Q<Label>("NameInScroll");

                ImageInScroll.style.backgroundImage = _weaponInDirectory[i]._weaponImage;
                NameInScroll.text = _weaponInDirectory[i]._name;
                currentButton.clicked += () => OpenButtoWeapon(currentButton);
            }
        }
    }

    private void OpenButtonEnemy(Button button)
    {
        for (int i = 0; i < _enemyDirectory.Count; i++)
        {
            if (_enemyDirectory[i].name == button.name)
            {
                EnemyDirectorySO CurrentElement = _enemyDirectory[i];

                _image.style.backgroundImage = CurrentElement._enemyImage;
                _name.text = CurrentElement._name;
                _about.text = CurrentElement._aboutEnemy;
            }
        }
    }

    private void OpenButtoWeapon(Button button)
    {
        for (int i = 0; i < _weaponInDirectory.Count; i++)
        {
            if (_weaponInDirectory[i].name == button.name)
            {
                WeaponInDirectory CurrentElement = _weaponInDirectory[i];

                _image.style.backgroundImage = CurrentElement._weaponImage;
                _name.text = CurrentElement._name;
                _about.text = CurrentElement._aboutWeapon;
            }
        }
    }
}
