using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour
{
    Vector2 flagPosition;
    Rigidbody2D rb;
    int waterCounter = 0; //Created to prevent double execution for Die()
    public GameOverController goController;
    public AudioClip waterSplashClip;
    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        flagPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        SaveManager.Instance.saveData.currentScene = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            _audioSource.PlayOneShot(waterSplashClip, 0.5f);
            waterCounter++;
            if (waterCounter == 1) //Executes it only when it touches it only one time.
            {
                Die();
            }
        }

        if (collision.CompareTag("Level2"))
        {
            SceneManager.LoadScene("Scene_two");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water")) //Reset the counter
        {
            waterCounter = 0;
        }
    }

    public void UpdateCheckpoint(Vector2 checkpointPosition)
    {
        flagPosition = checkpointPosition;
    }

    public void Die()
    {
        //Remove a heart from the health whenever it dies from touching something like water
        PStats.Instance.TakeDamage(1);

        //If there's no health remaining, then show the game over screen
        float remainingHealth = PStats.Instance.Health;
        SaveManager.Instance.saveData.playerLife = remainingHealth;
        if (remainingHealth <= 0)
        {
            goController.Show();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; //Freeze coords
        }
        else
        {
            StartCoroutine(Respawn(0.3f));
        }
    }

    public void TakeDamage()
    {
        //TakeDamage
        PStats.Instance.TakeDamage(0.5f);

        //If there's no health remaining, then show the game over screen
        float remainingHealth = PStats.Instance.Health;
        SaveManager.Instance.saveData.playerLife = remainingHealth;
        if (remainingHealth <= 0)
        {
            goController.Show();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; //Freeze coords
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = flagPosition;
    }
}