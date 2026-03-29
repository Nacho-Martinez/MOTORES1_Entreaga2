using UnityEngine;

namespace Player
{
    public class PlayerHealthSystem : CharacterHealthSystem
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            //Para la barra de vida de luego 
        }
    }
}