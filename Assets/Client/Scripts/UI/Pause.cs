using UnityEngine;
using UnityEngine.UIElements;

public class Pause : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _PauseAsset;

    private VisualElement _pause;
    protected override void Initialize()
    {
        _pause = _PauseAsset.CloneTree();
    }

    public void OpenPause()
    {
        ResetContainer(_pause);

        Button continion = _container.Q<Button>("Cont");
        Button settings = _container.Q<Button>("Settings");
        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        continion.clicked += () =>
        {
            _gameMachine.ResumeGame();
        };
        //ExitToMenu.clicked += () => 
    }
}
