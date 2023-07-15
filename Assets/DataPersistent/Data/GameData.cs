using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float MoveSpeed;
    public int AttackDamage;
    public int AbilityDamage;
    public float AttackSpeed;


    public int MaxHealth;
    public int CurrentHeath;
    public int MaxFuel;
    public int Fuel;
    public int MaxEnergy;
    public int Energy;
    public int Coin;

    public int LifeSaverHeart;

    public GameData()
    {
        this.MoveSpeed = 20f;
        this.AttackDamage = 100;
        this.AbilityDamage = 100;
        this.AttackSpeed = 0.2f;

        this.MaxHealth = 100;
        this.CurrentHeath = 70;
        this.MaxFuel = 100;
        this.Fuel = 60;
        this.MaxEnergy = 50;
        this.Energy = 25;
        this.Coin = 0;

        this.LifeSaverHeart = 1;
    }


}
