using System;
using UnityEngine;

public class CharacterHealthSystem : MonoBehaviour,IDamageable
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //Logica de animacion etc etc
        }
    }
}
