using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    [SerializeField] AudioSource _audioSource;

    public void Show()
    {
        gameObject.SetActive(true);

        _audioSource = GetComponent<AudioSource>();
        AudioListener.pause = true;
        _audioSource.ignoreListenerPause = true;
        _audioSource.Play();

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        AudioListener.pause = false;
        //Hide the screen
        gameObject.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }
}
    