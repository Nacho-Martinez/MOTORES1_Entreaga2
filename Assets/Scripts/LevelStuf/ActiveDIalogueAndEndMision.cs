using System;
using Managers;
using Menu;
using Npc;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;

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
            SceneManager.LoadScene("MainMenu");
            MenuManager.Instance.ShowLoseMenu();
            
            //Mostramos la pantalla de victoria 
        }
    }
}