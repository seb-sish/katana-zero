using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChasing : MonoBehaviour
{
    public Transform player;

    private void Update()
     {
        Vector3 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = pointerPosition - transform.position;

        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
