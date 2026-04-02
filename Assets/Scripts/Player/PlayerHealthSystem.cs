using System.Collections;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerHealthSystem : CharacterHealthSystem
    {
        private static readonly int Dead = Animator.StringToHash("Dead");
        private PlayerMovementSystem movement;
        private PlayerAttackSystem attack;
        private Animator anim;

        private void Start()
        {
            movement = GetComponent<PlayerMovementSystem>();
            attack = GetComponent<PlayerAttackSystem>();
            anim = GetComponent<Animator>();
        }
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            EventManager.Instance.PlayerDamage(currentHealth,maxHealth);
            
            if (currentHealth <= 0)
            {
                movement.enabled = false;
                attack.enabled = false;
                StartCoroutine(WaitingForDead());
            }
        }
        
        private IEnumerator WaitingForDead()
        {
            anim.SetBool(Dead,true);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}