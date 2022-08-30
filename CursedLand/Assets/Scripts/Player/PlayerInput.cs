using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction InputActions;

    private Vector2 pointerInput;

    private WeaponParent weaponParent;
    private PlayerMovement playerMovement;
    //private TimeManager timeManager;

    public bool isPause = false;

    [SerializeField]
    InputActionReference attack;

    void Awake()
    {
        InputActions = new PlayerInputAction();
        weaponParent = GetComponentInChildren<WeaponParent>();
        playerMovement = GetComponentInChildren<PlayerMovement>();
    }
    private void OnEnable()
    {
        InputActions.Player.Damage.Enable();
        InputActions.Player.PointerPosition.Enable();
        InputActions.Player.Fire.Enable();

        InputActions.Player.Debug2.Enable();
        InputActions.Player.Debug3.Enable();
        InputActions.Player.Debug1.Enable();
    }

    private void OnDisable()
    {
        
        InputActions.Player.Damage.Disable();
        InputActions.Player.PointerPosition.Disable();
        InputActions.Player.Fire.Disable();

        InputActions.Player.Debug1.Disable();
        InputActions.Player.Debug2.Disable();
        InputActions.Player.Debug3.Disable();
    }

   

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        //if (TimeManager.GetInstance().isNight)
        //{
        //   TogglePause();
        //}
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = InputActions.Player.PointerPosition.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void Start()
    {
        
        InputActions.Player.Damage.performed += HandleDamage =>
        {
            Debug.Log("TEKEN");
            Time.timeScale = 1;
        };

        InputActions.Player.Debug1.performed += HandleDebug1 =>
        {
            Debug.Log("NAH Debug 1, POWER");
            weaponParent.dmg = 50;
        };

        InputActions.Player.Debug2.performed += HandleDebug2 =>
        {
            Debug.Log("NIH DEBUG 2, AGILITY");
            playerMovement.speed /= 2;
            StartCoroutine(GetBuffSpd());
        };

        InputActions.Player.Debug3.performed += HandleDebug3 =>
        {
            Debug.Log("Pause Pencet");
            //isPause = !isPause;
            TogglePause();
        };

        InputActions.Player.Fire.performed += HandleAttack =>
        {
            weaponParent.Attack();
        };

    }

    private void TogglePause()
    {
        Debug.Log("Masuk Toggle");
        isPause = !isPause;
    }

    private IEnumerator GetBuffSpd()
    {
        yield return new WaitForSeconds(5f);
        playerMovement.speed *= 3;
    }
}
