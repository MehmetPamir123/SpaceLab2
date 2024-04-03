using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullets/Bullet")]
public class Bullets : ItemObject
{
    [Space(20)]
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float durability;
    [SerializeField] private int costEnergyAmount;
    [TextArea][SerializeField] private string specialAbilities;
    public int Damage => damage;
    public float Speed => speed;
    public float Durability => durability;
    public int CostEnergyAmount => costEnergyAmount;
    public string SpecialAbilities => specialAbilities;

}
