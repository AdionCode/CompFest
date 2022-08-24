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

        StartCoroutine(StartNight());
        //NightPanel.SetActive(false);
        //DayPanel.SetActive(true);


    }

    private IEnumerator StartNight()
    {
        yield return new WaitForSeconds(5f);
        isDay = false;
        isNight = true;

        StartCoroutine(StartDay());
        //NightPanel.SetActive(true);
        //DayPanel.SetActive(false);
    }
}
