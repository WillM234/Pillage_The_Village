using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTesting : MonoBehaviour
{
    public float health;
    public float CurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = health;
    }
    public void takeDamage(float damage)
    {
        CurrentHealth -= damage;

    }
}
