using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSystem : PlayerSystem
{
    private static readonly int Running = Animator.StringToHash("running");
    
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    private Vector2 moveInput;
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        main.Controls.Player.Move.performed +=  OnMove;
        main.Controls.Player.Move.canceled +=  OnStopMove;
        main.Controls.Player.Jump.performed += Jump;
        
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
         moveInput = Vector2.zero;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
         moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        main.Controls.Player.Move.performed -=  OnMove;
        main.Controls.Player.Move.canceled -=  OnStopMove;
        main.Controls.Player.Jump.performed -= Jump;
        
    }

    void Update()
    {
        Rotate();
        main.Anim.SetBool(Running, moveInput.x != 0);
        
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(Physics2D.Raycast(transform.localPosition, Vector2.down, transform.localScale.y + 0.5f,main.filter))
        {
                
            main.Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Rotate()
    {
        if (moveInput.x> 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (moveInput.x < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        main.Rb.AddForce(new Vector2(moveInput.x,0)*movementForce,ForceMode2D.Force);
    }
    
    
}
