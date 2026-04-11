using System;
using System.Collections;
using UnityEngine;

public class ActivateAndAssingDialogue : MonoBehaviour
{
    [SerializeField] protected Dialogue dialogue;
    [SerializeField] private string[] npcLines;
    [SerializeField] private GameObject[] zombies;
    private bool hasBennActive = false;

    protected virtual void  OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBennActive && other.CompareTag("Player"))
        {
            hasBennActive = true;
            dialogue.StartDialogue(npcLines);
            if (((ICollection)zombies).Count > 0)
            {
              foreach (var zombie in zombies)
              {
                zombie.SetActive(true);
              } 
                
            }
        }
    }
}
