using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Replace this with whatever data you actually want to save.
[System.Serializable]
public class MySaveData
{
    public float playerLife;
    public string currentScene;
    public float snorkelTimeLeft;
}

//Singleton for "database" on JSON format.
public class SaveManager : MonoBehaviour
{
    private const string FileName = "gamedata.json";
    private static SaveManager _instance;
    public static SaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject(nameof(SaveManager));
                _instance = go.AddComponent<SaveManager>();
            }
            return _instance;
        }
    }

    public MySaveData saveData = new MySaveData();

    private string FullPath => Path.Combine(Application.persistentDataPath, FileName);

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        LoadFromDisk();
    }

    private void Start()
    {
        //Autosave every 60 seconds
        StartCoroutine(AutoSaveRoutine());
    }

    private IEnumerator AutoSaveRoutine()
    {
        var wait = new WaitForSeconds(60f);
        while (true)
        {
            yield return wait;
            SaveToDisk();
        }
    }

    public void SaveToDisk()
    {
        try
        {
            string json = JsonUtility.ToJson(saveData, prettyPrint: true);
            File.WriteAllText(FullPath, json);
            Debug.Log($"[SaveManager] Saved data to {FullPath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[SaveManager] Failed to save data: {e}");
        }
    }

    public void LoadFromDisk()
    {
        try
        {
            if (File.Exists(FullPath))
            {
                string json = File.ReadAllText(FullPath);
                saveData = JsonUtility.FromJson<MySaveData>(json);
                Debug.Log($"[SaveManager] Loaded data from {FullPath}");
                SceneManager.LoadScene(saveData.currentScene);
            }
            else
            {
                Debug.Log($"[SaveManager] No save file found at {FullPath}, starting new.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[SaveManager] Failed to load data: {e}");
        }
    }

    private void OnApplicationQuit()
    {
        //last save on quit
        SaveToDisk();
    }
}
