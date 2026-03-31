using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttackSystem : EnemySystem
    {
        private static readonly int Attack1 = Animator.StringToHash("attack");

        [Header("Attack Stats")] 
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed = 1.5f;
        private float attackCoolDown;

        private void Start()
        {
            
        }

        private void Update()
        {
            if (attackCoolDown > 0)
            {
                attackCoolDown -= Time.deltaTime;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                if (attackCoolDown <= 0 && main.sightModulo.DectectObjetive() != null)
                {
                    Attack(other.gameObject);
                }
            }
        }

        private void Attack(GameObject victim)
        {
            main.Anim.SetTrigger(Attack1);
            PlayerHealthSystem enemy = victim.GetComponent<PlayerHealthSystem>();
            if (enemy != null)
            { 
                Debug.Log($"Ha atacado con {damage}");
                enemy.TakeDamage(damage);
            }
            attackCoolDown = attackSpeed;
        }
    }
}