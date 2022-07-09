using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction InputActions;

    void Awake()
    {
        InputActions = new PlayerInputAction();
    }
    private void OnEnable()
    {
        InputActions.Player.Damage.Enable();
    }

    private void OnDisable()
    {
        
        InputActions.Player.Damage.Disable();
    }

    private void Start()
    {
        
        InputActions.Player.Damage.performed += HandleDamage =>
        {
            Debug.Log("TEKEN");
        };
        
    }
}
