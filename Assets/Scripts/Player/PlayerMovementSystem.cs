using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovementSystem : PlayerSystem
{
    private static readonly int Running = Animator.StringToHash("running");
    
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    

    private float hInput;
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        Rotate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics2D.Raycast(transform.localPosition, Vector2.down, transform.localScale.y + 0.5f,main.filter))
            {
                
                main.Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        main.Anim.SetBool(Running,hInput != 0);
        
    }

    private void Rotate()
    {
        if (hInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (hInput < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        main.Rb.AddForce(new Vector2(hInput,0)*movementForce,ForceMode2D.Force);
    }
    
    
}
