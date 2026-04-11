using System;
using Managers;
using Npc;
using UnityEngine;

namespace LevelStuf
{
    public class ActiveDIalogueAndEndMision : ActivateAndAssingDialogue
    {
        [SerializeField] private string[] endMisionLines;
        [SerializeField] private GameObject npc;
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out NPCMovemnt movement))
            {
                movement.enabled = false;
                if (other.TryGetComponent(out Rigidbody2D rb))
                {
                    rb.linearVelocity = Vector2.zero; 
                    rb.angularVelocity = 0f;          
                    rb.bodyType = RigidbodyType2D.Kinematic; 
                }
                base.OnTriggerEnter2D(other);
                npc.tag = "Untagged";
                npc.layer = 0;
            }


        }

        private void OnEnable()
        {
            EventManager.Instance.OnEndMission += LastDialogue;
        }

        private void LastDialogue()
        {
            dialogue.StartDialogue(endMisionLines);
            
            //Mostramos la pantalla de victoria 
        }
    }
}