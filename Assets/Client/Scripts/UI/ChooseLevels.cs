using UnityEngine;
using Zenject;

public class ChooseLevels : MonoBehaviour
{
    [SerializeField] private UIToolkitMenu _menu;

    [Inject] private GameMachine _gameMachine;

    public void ChooseLevel(int indexOfLevel)
    {
       _gameMachine.LoadLevel(indexOfLevel);
    }

    public void Exit()
    {
        _menu.gameObject.SetActive(true);  
        gameObject.SetActive(false);
    }
}