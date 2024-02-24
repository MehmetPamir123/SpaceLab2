using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour,IDataPersistance
{
    public GameObject currentPlayerBullet;
    public Transform player;
    [Space(20)]
    [SerializeField]bool alreadyAttacked;
    float attackSpeed;
    PlayerResourceController PRC;

    private void Start()
    {
        PRC=GetComponent<PlayerResourceController>();
    }
    public void LoadData(GameData data)
    {
        attackSpeed = data.AttackSpeed;
    }

    public void NormalAttack()
    {
        int costEnergyAmount = currentPlayerBullet.GetComponent<PlayerBullet>().bulletStats.CostEnergyAmount;



        if (!alreadyAttacked && PRC.GetEnergy() >= costEnergyAmount)
        {
            
            Debug.Log("ATTTACK!");

            GameObject bullet = Instantiate(currentPlayerBullet, player.position, player.localRotation);
            bullet.tag = "Bullet_Friend";

            PRC.EnergyAdd(-costEnergyAmount);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 100/attackSpeed);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void SaveData(ref GameData data)
    {
        data.AttackSpeed = attackSpeed;
    }
}
