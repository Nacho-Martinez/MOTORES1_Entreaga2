using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyMain : MonoBehaviour
    {
        [field: SerializeField] public BaseSightSense sightModulo { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Anim = GetComponent<Animator>();
            
        }
    }
}