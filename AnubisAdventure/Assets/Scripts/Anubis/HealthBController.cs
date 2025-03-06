using UnityEngine;
using UnityEngine.UI;

public class HealthBController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;

    private void Start()
    {
        // Should I use lists? Maybe :)
        heartContainers = new GameObject[(int)PStats.Instance.MaxTotalHealth];
        heartFills = new Image[(int)PStats.Instance.MaxTotalHealth];

        PStats.Instance.onHealthChangedCallback += UpdateHeartsHUD;
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < PStats.Instance.MaxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < PStats.Instance.Health)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (PStats.Instance.Health % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(PStats.Instance.Health);
            heartFills[lastPos].fillAmount = PStats.Instance.Health % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < PStats.Instance.MaxTotalHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }
}
