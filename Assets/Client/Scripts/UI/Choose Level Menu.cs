using UnityEngine;
using UnityEngine.UIElements;

public class ChooseLevelMenu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseLevelsAsset;
    
    [Header ("Maps")] 
    [SerializeField] private MapsInChooseConfiguration _human1;

    private VisualElement _chooseLevel;

    protected override void Initialize()
    {
        _chooseLevel = _chooseLevelsAsset.CloneTree();
    }

    public void OpenChooseLevelMenu()
    {
        ResetContainer(_chooseLevel);

        Button human1 = _container.Q<Button>("Organizm1");

        human1.clicked += () => OpenOneofButtons(_human1);
    }

    private void OpenOneofButtons(MapsInChooseConfiguration ActiveMap)
    {
        Label bolezni = _container.Q<Label>("Bolezni");
        Label StartPoint = _container.Q<Label>("StartPoint");
        Label FinishPoint = _container.Q<Label>("Finish");
        VisualElement mapInChoose = _container.Q<VisualElement>("MapInChoose");
        VisualElement cont = _container.Q<VisualElement>("cont");
        Button Start = _container.Q<Button>("Start");

        cont.visible = false;

        for (int i = 0; i >= ActiveMap.bolezni.Length; i++)
        {
            bolezni.text += ActiveMap.bolezni[i];
        }
        StartPoint.text = ActiveMap.startPointText;
        FinishPoint.text = ActiveMap.finishPointText;
        Start.clicked += () => _gameMachine.LoadLevel(1);
        mapInChoose.style.backgroundImage = ActiveMap.texture;

        cont.visible = true;
    }
}
