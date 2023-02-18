using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    private int damage;

    void Start()
    {
        damage = GameObject.FindWithTag("Player").GetComponent<Fighting>().damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
