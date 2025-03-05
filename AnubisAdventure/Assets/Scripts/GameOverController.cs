using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        //Hide the screen
        gameObject.SetActive(false);
        SceneManager.LoadScene("Scene_one");
    }
}
    