using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject currentPlayerBullet;
    public Transform player;
    [Space(20)]
    public GameObject[] allBullets;

    PlayerStats playerStats;
    public void NormalAttack()
    {
       
        Instantiate(currentPlayerBullet, player.position,player.localRotation);

    }
}
