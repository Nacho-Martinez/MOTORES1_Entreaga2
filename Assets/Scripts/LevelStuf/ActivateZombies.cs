using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelStuf
{
    public class ActivateZombies : MonoBehaviour
    {
        [SerializeField] private List<GameObject> zombies = new();
        private bool hasBeenActivated = false;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || hasBeenActivated)
            {
                return;
            }

            hasBeenActivated = true;
            foreach (var zombie in zombies)
            {
                zombie.SetActive(true);
            }
        }
    }
}