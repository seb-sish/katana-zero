using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private Animator Animator;
    public float attackSpeed;
    public int damage;

    [SerializeField] private GameObject hitbox;
    private bool elapsed = true;
    private Timer attackDelay;
    private Timer destroyDelay;
    private bool isFacingRight;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        attackDelay = new Timer(attackSpeed);
        attackDelay.Elapsed += onAttackDelay;
        attackDelay.Enabled = true;

        isFacingRight = gameObject.GetComponent<SamuraiMovement>().IsFacingRight;
    }

    private void Update()
    {
        isFacingRight = gameObject.GetComponent<SamuraiMovement>().IsFacingRight;
        if (elapsed)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                Animator.SetTrigger("Attack");
                if (isFacingRight)
                {
                    Instantiate(hitbox, new Vector3(transform.position.x + 1.3f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                }
                else
                {
                    Instantiate(hitbox, new Vector3(transform.position.x - 1.5f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                }
                elapsed = false;
            }
        }
    }

    private void onAttackDelay(object sender, ElapsedEventArgs e)
    {
        elapsed = true;
    }
}