using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IEnemyAttack
{
    public GameObject myBullet;
    public void Attack()
    {
        GameObject bullet = Instantiate(myBullet, transform.position, transform.localRotation);
        bullet.tag = "Bullet_Enemy";
    }
}
