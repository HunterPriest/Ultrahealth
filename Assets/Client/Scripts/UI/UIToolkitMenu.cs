using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class UIToolkitMenu : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _settingsAsset;

    [Inject] private GameMachine _gameMachine;

    private VisualElement _menu;
    private VisualElement _settings;

    private VisualElement _doc;
    private VisualElement _container;

    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;

        _container = _doc.Q<VisualElement>("Container");
        _menu = _container.Q<VisualElement>("Menu");
        _settings = _settingsAsset.CloneTree();

        ResetContainer(_menu);
        OpenMenu();
    }

    private void OpenMenu()
    {
        Button start = _container.Q<Button>("Play");
        Button settings = _container.Q<Button>("Settings");
        Button exit = _container.Q<Button>("Exit");

        start.clicked += () => _gameMachine.LoadGame();
        exit.clicked += () => Application.Quit();
    }

    private void ResetContainer(VisualElement nextElement)
    {
        _container.Clear();
        _container.Add(nextElement);
    }
}
