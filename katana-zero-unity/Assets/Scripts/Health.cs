using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    private bool isInBlock = false;

    void Update()
    {
        while (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isInBlock = true;
        }
    }

    void Attacked(int health) {
        if (isInBlock)
        {
            healthPoints -= health / 2;
            return;
        }
        healthPoints -= health;
    }
}
