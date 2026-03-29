using System;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    [field: SerializeField] public LayerMask filter { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
