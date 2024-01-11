using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour,IDamagableFriend
{
    PlayerResourceController PRC;
    private void Awake()
    {
        PRC = GameObject.FindWithTag("PlayerResourceController").GetComponent<PlayerResourceController>();
    }
    public int MyCurrentHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        PRC.HealthAdd(-damage);
    }

}
