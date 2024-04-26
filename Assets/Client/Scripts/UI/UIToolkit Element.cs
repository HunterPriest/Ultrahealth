using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public abstract class UIToolkitElement : MonoBehaviour
{
    [Inject] protected GameMachine gameMachine;

    private VisualElement _doc;
    protected VisualElement _container;
    protected DataSave.PlayerCurrentData save;
    protected abstract void Initialize();

    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;
        _container = _doc.Q<VisualElement>("Container");
        save = new();
        Initialize();
    }

    protected virtual void ResetContainer(VisualElement element)
    {
        _container.Clear();
        _container.Add(element);
    }
}
