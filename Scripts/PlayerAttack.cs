using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCD = 0.3f;

    public Collider2D attackTrigger;

    private Animator ani;

    private void Awake()
    {
        ani = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;

            attackTrigger.enabled = true;
        }

        if(attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        ani.SetBool("Attack", attacking);
    }
}
