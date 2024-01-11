using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Enemy")]
public class Enemies : ScriptableObject
{
    [SerializeField] private string displayName;

    [SerializeField] private int maxHealth;
    [SerializeField] private int startHealth;

    [SerializeField] private float moveSpeed;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int abilityDamage;

    [SerializeField] private float sightRadius;
    [SerializeField] private float walkPointRange;
    [SerializeField] private float attackRange;

    [SerializeField] private bool hostile;
    [Space(30)]
    [Header("Health , Fuel , Energy , Coin , GDuration , GTime")]
    [SerializeField] private int[] treasure = new int[] {0,0,0,0,0,0}; //health,fuel,energy,coin


    public string DisplayName => displayName;
    public int MaxHealth => maxHealth;
    public int StartHealth => startHealth;
    public float MoveSpeed => moveSpeed;
    public int AttackDamage => attackDamage;
    public int AbilityDamage => abilityDamage;
    public float AttackSpeed => attackSpeed;
    public float SightRadius => sightRadius;
    public bool Hostile => hostile;
    public float WalkPointRange => walkPointRange;
    public float AttackRange => attackRange;
    public int[] Treasure => treasure;

    public Enemies(string displayName, int maxHealth, int startHealth, float moveSpeed, int attackDamage, float attackSpeed, int abilityDamage, float sightRadius, float walkPointRange, float attackRange, bool hostile, int[] treasure)
    {
        this.displayName = displayName;
        this.maxHealth = maxHealth;
        this.startHealth = startHealth;
        this.moveSpeed = moveSpeed;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
        this.abilityDamage = abilityDamage;
        this.sightRadius = sightRadius;
        this.walkPointRange = walkPointRange;
        this.attackRange = attackRange;
        this.hostile = hostile;
        this.treasure = treasure;
    }
}
public interface IDamagableEnemy
{
    int MyCurrentHealth { get; set; }
    public void TakeDamage(int damage);
    public void Death();
}
public interface IDamagableFriend
{
    int MyCurrentHealth { get; set; }
    public void TakeDamage(int damage);
    public void Death();
}

