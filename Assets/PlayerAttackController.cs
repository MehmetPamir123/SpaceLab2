using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackController : MonoBehaviour,IDataPersistance
{
    public GameObject currentPlayerBullet;
    public GameObject defaultBullet;
    public GameObject[] allBullets;

    public Transform player;
    

    [Space(20)]
    [SerializeField]bool alreadyAttacked;
    float attackSpeed;
    public PlayerResourceController PRC;
    public Image imageGrayed;
         
    public void SetCurrentBullet(ItemObject bullet)
    {
        foreach (var item in allBullets)
        {
            if (item.name == bullet.data.Name)
            {
                currentPlayerBullet = item;
            }
        }
    }
    public void SetBulletDefault()
    {
        currentPlayerBullet = defaultBullet;
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
            StartCoroutine(Cooldown(100 / attackSpeed));
        }
    }
    public void SaveData(ref GameData data)
    {
        data.AttackSpeed = attackSpeed;
    }

    IEnumerator Cooldown(float time)
    {

        float maxCooldown = time;
        for (; time >= 0.02f; time -= 0.02f)
        {
            imageGrayed.fillAmount = time / maxCooldown;
            yield return new WaitForSeconds(0.02f);


        }
        alreadyAttacked = false;
        if (imageGrayed != null)
        {
            imageGrayed.fillAmount = 0;
        }


    }
}
