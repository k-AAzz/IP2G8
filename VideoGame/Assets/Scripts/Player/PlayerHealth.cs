using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private bool isDead;

    public static event Action OnPlayerDamaged;

    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // checks if player is dead
        if (health <= 0 && !isDead)
        {
            isDead = true;

            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        OnPlayerDamaged?.Invoke();
    }

    public void maxHealthIncrease()
    {
        maxHealth = maxHealth + 4;
    }
}
