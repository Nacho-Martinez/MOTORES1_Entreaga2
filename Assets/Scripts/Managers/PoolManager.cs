using System;
using LevelStuf;
using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance { get; private set; }
        [SerializeField] private GameObject zombiePrefab;
        public ObjectPool<GameObject> MyZombiePool;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                MyZombiePool = new ObjectPool<GameObject>(CreateZombie, OnGet, OnRelease, OnDestroyZombie);

            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroyZombie(GameObject obj)
        {
            Destroy(obj);
        }

        private void OnRelease(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void OnGet(GameObject obj)
        {
            obj.SetActive(true);
        }

        private GameObject CreateZombie()
        {
            GameObject zombie = Instantiate(zombiePrefab);
            if (zombie.TryGetComponent(out ZombieHealthWithPoolLogic health))
            {
                health.MyPool = MyZombiePool;
            }

            return zombie;
        }
    }
}