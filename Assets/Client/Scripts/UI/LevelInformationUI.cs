using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class LevelInformationUI : UIToolkitElementWithExitOnButton
{
    private Label _level;
    private Label _name;
    private Label _bolezni;
    private Label _StartPoint;
    private Label _FinishPoint;
    private VisualElement _mapInChoose;
    private Button _start;

    private GameMachine _gameMashine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMashine = gameMachine;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _level = UIElement.Q<Label>("Level");
        _name = UIElement.Q<Label>("Organizm");
        _bolezni = UIElement.Q<Label>("Bolezni");
        _StartPoint = UIElement.Q<Label>("StartPoint");
        _FinishPoint = UIElement.Q<Label>("Finish");
        _mapInChoose = UIElement.Q<VisualElement>("MapInChoose");

        _start = UIElement.Q<Button>("Start");
    }

    public void OpenLevelInfornmation(MapsInChooseConfiguration map)
    {
        _level.text = "Уровень " + map.level.ToString();
        _name.text = map.organizmName;
        _bolezni.text = map.bolezni;
        _StartPoint.text = map.startPointText;
        _FinishPoint.text = map.finishPointText;
        _mapInChoose.style.backgroundImage = map.texture;

        _start.clicked += () =>
        {
            _start.clicked += () => { };
            _gameMashine.LoadLevel(map.level);
        };

        base.Open();
    }
}
