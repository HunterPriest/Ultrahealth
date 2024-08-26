using UnityEngine;
using UnityEngine.UIElements;

public abstract class UIToolkitBasicElement : MonoBehaviour
{
    private VisualElement _doc;

    protected VisualElement _container;

    protected virtual void Initialize() {   }

    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;
        _container = _doc.Q<VisualElement>("Container");
        Initialize();
    }

    protected virtual void ResetContainer(VisualElement element)
    {
        _container.Clear();
        _container.Add(element);
    }

    public virtual void Open() {   }
}
