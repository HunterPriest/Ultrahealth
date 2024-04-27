using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public abstract class UIToolkitElement : MonoBehaviour
{
    private VisualElement _doc;
    protected VisualElement _container;
    protected DataSave.PlayerData save;
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
