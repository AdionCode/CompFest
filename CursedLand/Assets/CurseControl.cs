using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseControl : MonoBehaviour
{
    [SerializeField] TimeManager Time;
    [SerializeField] GameObject CurseUi;
    [SerializeField] PlayerHealth HealthBuff;
    [SerializeField] PlayerMovement MovementBuff;

    [SerializeField] bool isChoosed = false;

    void Start()
    {

    }

    void Update()
    {

        if (Time.isDay)
        {
            CurseUi.SetActive(false);
            if (isChoosed)
            {
                isChoosed = !isChoosed;
            }
        }
        else if (Time.isNight)
        {
            if (!isChoosed)
            {
                CurseUi.SetActive(true);
            }
            else
            {
                CurseUi.SetActive(false);
            }
        }

    }

    public void ChooseHealthBuff()
    {
        HealthBuff.maxHealth += 10;
        isChoosed = true;
        CurseUi.SetActive(false);
    }

    public void ChooseSpeedBuff()
    {
        MovementBuff.speed += 10;
        isChoosed = true;
        CurseUi.SetActive(false);
    }

    public void ChooseCoinBuff()
    {

    }
}
