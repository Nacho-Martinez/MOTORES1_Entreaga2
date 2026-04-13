using System;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [Header("SFX")]
    [field: SerializeField] public AudioClip JumpSound { get; private set; }
    [field: SerializeField] public AudioClip ShootSound { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    [field: SerializeField] public LayerMask filter { get; private set; }
    public MyInputActions Controls { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        if (Controls == null)
        {
            Controls = new MyInputActions();
            Controls.Enable();
        }
    }
    
    private void OnDestroy()
    {
        if (Controls != null)
        {
            Controls.Disable();
            Controls = null; 
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
