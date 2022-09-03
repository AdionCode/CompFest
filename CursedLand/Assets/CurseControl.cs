using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseControl : MonoBehaviour
{
    [SerializeField] TimeManager Time;
    [SerializeField] GameObject CurseUi;
    [SerializeField] PlayerHealth HealthBuff;
    [SerializeField] PlayerMovement MovementBuff;
    [SerializeField] WeaponParent AttackBuff;

    [SerializeField] bool isChoosed = false;

    [Header("Tweaking Variable")]
    [SerializeField] int HealthMaxBuff = 10;
    [SerializeField] int HealthRestoreBuff = 10;
    [SerializeField] float SpeedUpBuff = 0.01f;


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
        HealthBuff.maxHealth += HealthMaxBuff;
        HealthBuff.currentHealth += HealthRestoreBuff;
        isChoosed = true;
        CurseUi.SetActive(false);
    }

    public void ChooseSpeedBuff()
    {
        MovementBuff.speed += SpeedUpBuff;
        isChoosed = true;
        CurseUi.SetActive(false);
    }

    public void ChooseAttackBuff()
    {
        AttackBuff.dmg += 10;
        isChoosed = true;
        CurseUi.SetActive(false);
    }
}
