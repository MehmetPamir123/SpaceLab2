using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float MoveSpeed;
    public int AttackDamage;
    public int AbilityDamage;
    public float AttackSpeed;


    public float MaxHealth;
    public float CurrentHeath;
    public float MaxFuel;
    public float Fuel;
    public float MaxEnergy;
    public float Energy;
    public float Coin;

    public PlayerStats()
    {
        MoveSpeed = 20f;
        AttackDamage = 100;
        AbilityDamage = 100;

        MaxHealth = 100;
        CurrentHeath = 100;
        Fuel = 100f;
        Energy = 100f;
        Coin = 0;
    }
}
