using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public float attackSpeed;

    private bool isAttacking = false;
    private bool elapsed = true;
    private Timer attackDelay;

    private void Start()
    {
        isAttacking = false;
        attackDelay = new Timer(attackSpeed);
        attackDelay.Elapsed += onTimedEvent;
        attackDelay.Enabled = true;
    }

    private void Update()
    {
        if (elapsed)
        {
            while (Input.GetAxis("Fire1") != 0)
            {
                elapsed = false;
                isAttacking = true;
            }
        }
    }

    private void onTimedEvent(object sender, ElapsedEventArgs e)
    {
        elapsed = true;
    }
}