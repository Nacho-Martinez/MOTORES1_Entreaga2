using Managers;
using UnityEngine;

namespace Npc
{
    public class NPCHealthSystem : CharacterHealthSystem
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            if (currentHealth <= 0)
            {
                EventManager.Instance.NpcDie();
                Destroy(gameObject);
            }
        }
    }
}