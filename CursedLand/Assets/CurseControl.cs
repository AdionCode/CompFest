using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseControl : MonoBehaviour
{
    [SerializeField] TimeManager TimeM;
    [SerializeField] GameObject CurseUi;
    [SerializeField] PlayerHealth HealthBuff;
    [SerializeField] PlayerMovement MovementBuff;
    [SerializeField] WeaponParent AttackBuff;
    [SerializeField] PlayerInput playerInput;

    [SerializeField] bool isChoosed = false;
    public bool isPause = false;
    private bool SPD = false;
    private bool HP = false;
    private bool ATK = false;

    [Header("Tweaking Variable")]
    [SerializeField] int HealthMaxBuff = 10;
    //[SerializeField] int HealthRestoreBuff = 10;
    //[SerializeField] float SpeedUpBuff = 0.01f;


    void Start()
    {
        CurseUi.SetActive(false);
    }

    void FixedUpdate()
    {
        //if (isPause)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}

        if (TimeM.isDay)
        {
            CurseUi.SetActive(false);
            if (isChoosed)
            {
                if (HP)
                {
                    buffHP();
                }
                else if (ATK)
                {
                    buffATK();
                }
                else
                {
                    buffSPD();
                }
                isChoosed = !isChoosed;
            }
        }
        if (TimeM.isNight)
        {
            if (!isChoosed)
            {
                CurseUi.SetActive(true);
                Debug.Log("ATAS");
                playerInput.testing();
            }
            else
            {
                CurseUi.SetActive(false);
                Debug.Log("BAWAH");
                
            }
        }

    }

    public void ChooseHealthBuff()
    {
        //HealthBuff.maxHealth += HealthMaxBuff;
        //HealthBuff.currentHealth += HealthRestoreBuff;
        curseHP();
        isChoosed = true;
        CurseUi.SetActive(false);
        playerInput.testing();
    }

    public void ChooseSpeedBuff()
    {
        //MovementBuff.speed += SpeedUpBuff;
        curseSPD();
        isChoosed = true;
        CurseUi.SetActive(false);
        playerInput.testing();
    }

    public void ChooseAttackBuff()
    {
        curseATK();
        //AttackBuff.dmg += 10;
        isChoosed = true;
        CurseUi.SetActive(false);
        playerInput.testing();
    }

    private void TogglePause()
    {
        Debug.Log("ZZ Toggle");
        isPause = !isPause;
    }

    private void curseSPD()
    {
        SPD = true;
        MovementBuff.speed /= 2;
    }

    private void buffSPD()
    {
        SPD = false;
        MovementBuff.speed *= 3;
    }

    private void curseHP()
    {
        HP = true;
        HealthBuff.maxHealth /= 2;
        if (HealthBuff.currentHealth > HealthBuff.maxHealth)
        {
            HealthBuff.currentHealth = HealthBuff.maxHealth;
        }
        
    }

    private void buffHP()
    {
        HP = false;
        HealthBuff.maxHealth += HealthMaxBuff;
        HealthBuff.currentHealth = HealthBuff.maxHealth;
        //if (HealthBuff.currentHealth > HealthBuff.maxHealth)
        //{
        //    HealthBuff.currentHealth = HealthBuff.maxHealth;
        //}
        //else
        //{
        //    HealthBuff.currentHealth += HealthRestoreBuff;
        //}
        
        
    }

    private void curseATK()
    {
        ATK = true;
        AttackBuff.dmg /= 2;
    }

    private void buffATK()
    {
        ATK = false;
        AttackBuff.dmg *= 3;
    }
}
