using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_A102 : PlayerBullet
{
    GameObject followingEnemy;
    public LayerMask whatIsEnemy;
    public override void Move()
    {
        if (followingEnemy == null)
        {
            base.Move();
            if(Physics2D.OverlapCircle(transform.position, 2, whatIsEnemy) != null)
            followingEnemy = Physics2D.OverlapCircle(transform.position, 2, whatIsEnemy).gameObject;
        }
        else
        {
            base.Move();
            transform.up = followingEnemy.transform.position - transform.position;

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
