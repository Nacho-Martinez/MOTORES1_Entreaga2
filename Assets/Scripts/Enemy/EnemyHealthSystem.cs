using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealthSystem : CharacterHealthSystem
    {
        [SerializeField]private AudioClip dieSound;
        private static readonly int Dead = Animator.StringToHash("dead");
        private ZombieAI AI;
        private EnemyAttackSystem attackSystem;
        private Rigidbody2D rb;
        private Animator anim;
        
        
        
        private void Start()
        {
            AI = GetComponent<ZombieAI>();
            attackSystem = GetComponent<EnemyAttackSystem>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            
            if (currentHealth <= 0)
            {
                AI.enabled = false;
                attackSystem.enabled = false;
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                StartCoroutine(WaitingForDead());
            }
        }
        
        private IEnumerator WaitingForDead()
        {
            AudioManager.AudioInstance.PlaySoud(dieSound);
            anim.SetBool(Dead,true);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}