using UnityEngine.SceneManagement;
using UnityEngine;
using Tools;

public class ScenesManager : MonoBehaviour, ILoadGameGameListner, IInitializeGameListener
{
    void ILoadGameGameListner.OnLoadGame()
    {
        SceneManager.LoadScene("TEST");
    }   

    void IInitializeGameListener.OnInitialize()
    {
        SceneManager.LoadScene("Menu");
    }
}