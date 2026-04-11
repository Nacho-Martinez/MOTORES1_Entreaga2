using System;
using Npc;
using UnityEngine;

namespace LevelStuf
{
    public class ActiveZombieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawner;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out NPCHealthSystem _))
            {
                spawner.SetActive(true);
            }
        }
    }
}