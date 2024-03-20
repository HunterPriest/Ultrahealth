using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public abstract class UIToolkitManager : MonoBehaviour
{
    private VisualElement _doc;
    protected VisualElement _container;
    protected abstract void Initialize();

    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;
        _container = _doc.Q<VisualElement>("Container");
        FindObjectOfType<MenuManager>().Initialize();
        FindObjectOfType<MenuManager>().OpenMenu();
    }

    protected virtual void ResetContainer(VisualElement element)
    {
        _container.Clear();
        _container.Add(element);
    }
}
