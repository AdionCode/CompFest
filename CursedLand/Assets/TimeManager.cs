using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Time UI")]
    [SerializeField] private GameObject DayPanel;
    [SerializeField] private GameObject NightPanel;

    public bool isDay, isNight;
    // Start is called before the first frame update
    private static TimeManager instance;
    //private PlayerInput playerInput;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Time Manager in the scene");
        }
        instance = this;
    }

    public static TimeManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        isDay = true;
        StartCoroutine(StartNight());
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay)
        {
            DayPanel.SetActive(true);
            NightPanel.SetActive(false);
        }
        else
        {
            NightPanel.SetActive(true);
            DayPanel.SetActive(false);
        }
    }

    private IEnumerator StartDay()
    {
        yield return new WaitForSeconds(5f);
        isNight = false;
        isDay = true;
        Debug.Log("Sekarang Siang");
        StartCoroutine(StartNight());
        //NightPanel.SetActive(false);
        //DayPanel.SetActive(true);


    }

    private IEnumerator StartNight()
    {
        yield return new WaitForSeconds(5f);
        isDay = false;
        isNight = true;
        Debug.Log("Sekarang Malam");
        StartCoroutine(StartDay());
        //NightPanel.SetActive(true);
        //DayPanel.SetActive(false);
    }
}
