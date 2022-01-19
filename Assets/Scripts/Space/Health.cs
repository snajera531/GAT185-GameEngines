using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathPrefab;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float maxHealth = 100;

    public float health { get; set; }

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(deathPrefab != null) Instantiate(deathPrefab, transform.position, transform.rotation);

            if (destroyOnDeath) Destroy(gameObject);
        }
    }
}
