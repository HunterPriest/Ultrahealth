using UnityEngine.SceneManagement;
using UnityEngine;
using Tools;

public class ScenesManager : MonoBehaviour, ILoadGameGameListner
{
    void ILoadGameGameListner.OnLoadGame()
    {
        SceneManager.LoadScene("TEST");
    }
}