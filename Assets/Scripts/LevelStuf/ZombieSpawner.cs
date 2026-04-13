using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.Pool;

namespace LevelStuf
{
    public class ZombieSpawner : MonoBehaviour
    {
        [Header("Config")] 
        
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float spawnInterval = 6f;
        
        private float timer = 0f;
        private int activeSpawnPoints = 1;

        private bool end = false;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private void Update()
        {
            if (end)
                return;
            if (timer < 180)
            {
                timer += Time.deltaTime;

                if (timer > 120f)
                {
                    spawnInterval = 15f;
                    activeSpawnPoints = 3;
                }
                else if (timer > 60f)
                {
                    spawnInterval = 10f;
                    activeSpawnPoints = 2;
                    
                } 
                else activeSpawnPoints = 1;
            }
            else
            {
                EventManager.Instance.EndMission();
            }
        }

        private IEnumerator SpawnRoutine()
        {
            yield return null;

            while (true)
            {
                for(int i =0;i<activeSpawnPoints;i++)
                {
                    GameObject zombie = PoolManager.Instance.MyZombiePool.Get();
                    zombie.transform.position = spawnPoints[i].position;

                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}