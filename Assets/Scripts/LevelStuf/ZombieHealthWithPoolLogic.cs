using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.Pool;


namespace LevelStuf
{
    public class ZombieHealthWithPoolLogic : CharacterHealthSystem
    {
        
        private static readonly int Dead = Animator.StringToHash("dead");
        private ZombieAI AI;
        private EnemyAttackSystem attackSystem;
        private Rigidbody2D rb;
        private Animator anim;
        public ObjectPool<GameObject> MyPool;
        
        private void Start()
        {
            AI = GetComponent<ZombieAI>();
            attackSystem = GetComponent<EnemyAttackSystem>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        
        public override void TakeDamage(float damage)
        {
            currentHealth -= damage;
            
            if (currentHealth <= 0)
            {
                AI.enabled = false;
                attackSystem.enabled = false;
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                StartCoroutine(WaitingForDead());
            }
        }
        
        public void Die() 
        {
            if (MyPool != null)
            {
                MyPool.Release(gameObject); 
            }
            else
            {
                Destroy(gameObject); 
            }
        }
        private IEnumerator WaitingForDead()
        {
            anim.SetBool(Dead,true);
            yield return new WaitForSeconds(0.5f);
            Die();
        }
    }
}