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
    public float Fuel;
    public int MaxEnergy;
    public float Energy;
    public int Coin;

    public int LifeSaverHeart;

    public GameData()
    {
        this.MoveSpeed = 20f;
        this.AttackDamage = 100;
        this.AbilityDamage = 100;
        this.AttackSpeed = 50f;

        this.MaxHealth = 10;
        this.CurrentHeath = 10;

        this.MaxFuel = 200;
        this.Fuel = 200;

        this.MaxEnergy = 20;
        this.Energy = 20;

        this.Coin = 0;

        this.LifeSaverHeart = 1;
    }


}
