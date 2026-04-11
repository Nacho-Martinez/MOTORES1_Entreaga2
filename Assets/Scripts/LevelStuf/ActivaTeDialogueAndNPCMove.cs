using System;
using Npc;
using UnityEngine;

namespace LevelStuf
{
    public class ActivaTeDialogueAndNPCMove : ActivateAndAssingDialogue
    {
        [SerializeField] private NPCMovemnt npcMovement;
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                npcMovement.enabled = true;
            }
        }
    }
}