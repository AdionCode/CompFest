using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputAction playerInput;
    private Rigidbody2D rb;
    private Vector3 position;
    private Vector3 velocity;

    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField]
    //private InputActionReference movement, attack, pointerPosition;
    public float speed = 6f;
    
    

    
    

    void Awake()
    {
        playerInput = new PlayerInputAction();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    
    void FixedUpdate()
    {
        //if(DialogueManager.GetInstance().dialogueIsPlaying)
        //{
        //    return;
        //}

        //Vector2 mousePosition = GetPointerInput();
        Vector2 moveInput = playerInput.Player.Move.ReadValue<Vector2>();

        horizontal = moveInput.x;

        rb.velocity = moveInput * speed;

        //Debug.Log(speed);
        //if (!isFacingRight && horizontal > 0f)
        //{
        //    flip();
        //}
        //else if(isFacingRight && horizontal < 0f)
        //{
        //    flip();
        //}

        //if(attack.action.IsPressed)

    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        
        
    }

    //private Vector2 GetPointerInput()
    //{
    //    Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
    //    mousePos.z = Camera.main.nearClipPlane;
    //    return Camera.main.ScreenToWorldPoint(mousePos);
    //}
   

}
