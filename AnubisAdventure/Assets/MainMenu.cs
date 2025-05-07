using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Scene_one");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
