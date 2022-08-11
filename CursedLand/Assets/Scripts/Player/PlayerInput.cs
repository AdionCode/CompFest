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

    [SerializeField]
    InputActionReference attack;

    void Awake()
    {
        InputActions = new PlayerInputAction();
        weaponParent = GetComponentInChildren<WeaponParent>();
    }
    private void OnEnable()
    {
        InputActions.Player.Damage.Enable();
        InputActions.Player.PointerPosition.Enable();
        InputActions.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        
        InputActions.Player.Damage.Disable();
        InputActions.Player.PointerPosition.Disable();
        InputActions.Player.Fire.Disable();
    }

   

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
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
        };

        InputActions.Player.Fire.performed += HandleAttack =>
        {
            weaponParent.Attack();
        };

    }
}
