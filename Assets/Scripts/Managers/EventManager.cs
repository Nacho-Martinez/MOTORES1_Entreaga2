using System;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }
        //Preparo el evento para que cuando se lance, lance dos floats
        public event Action <float,float> OnPlayerDamage; 
   
   
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayerDamage(float currentHealth, float maxHealth)
        {
            OnPlayerDamage?.Invoke(currentHealth,maxHealth);
        }
    }
}