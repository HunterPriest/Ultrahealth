using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenLevel(int numberOfLevel)
    {
        SceneManager.LoadScene("Level" + numberOfLevel);
    }
}