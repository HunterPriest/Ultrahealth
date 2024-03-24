using UnityEngine;
using UnityEngine.UIElements;

public class ChooseLevelMenu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseLevelsAsset;
    
    [Header ("Maps")] 
    [SerializeField] private Texture2D _human1;

    private VisualElement _chooseLevel;

    protected override void Initialize()
    {
        _chooseLevel = _chooseLevelsAsset.CloneTree();
    }

    public void OpenChooseLevelMenu()
    {
        ResetContainer(_chooseLevel);

        Label bolezni = _container.Q<Label>("Bolezni");
        Label StartPoint = _container.Q<Label>("StartPoint");
        Label FinishPoint = _container.Q<Label>("Finish");
        VisualElement mapInChoose = _container.Q<VisualElement>("MapInChoose");
        VisualElement cont = _container.Q<VisualElement>("cont");
        Button Start = _container.Q<Button>("Start");
        Button human1 = _container.Q<Button>("Organizm1");

        cont.visible = false;

        human1.clicked += (() =>
        {
            bolezni.text = "1) Ультракил головного мозга  " +
            "2) мама пропала " +
            "3) Артем из подвала не выпустил " +
            "4) Был рядом с Шешуковым и теперь страдает публиками";
            StartPoint.text = "Ротовая полость";
            FinishPoint.text = "Легкие";
            mapInChoose.style.backgroundImage = _human1;
            Start.clicked += () => _gameMachine.LoadLevel(1);
            cont.visible = true;
        }); // its a plan for bind button Human
    }

    private void OpenOrganMap()
    {
        
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
