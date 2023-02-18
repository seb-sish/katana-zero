using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoints;

    void Update()
    {
        if (healthPoints <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
    }
}
