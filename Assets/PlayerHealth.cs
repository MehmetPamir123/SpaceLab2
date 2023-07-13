using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float MaxHealth;
    public float currentHealth;
    PlayerStats stats=new PlayerStats();

    private void Start()
    {
        MaxHealth = stats.MaxHealth;
        currentHealth = stats.CurrentHeath;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = currentHealth;
    }
    public void PlayerTakeDamage(float amount) //if you want to heal just -(negative) it.
    {
        currentHealth -= amount;
        if(currentHealth < 0) { PlayerDied(); }
        if(currentHealth > MaxHealth) { currentHealth = MaxHealth; }

        healthSlider.value = currentHealth;

        stats.CurrentHeath = currentHealth;
    }
    public void PlayerMaxHealthDamage(float amount)
    {
        MaxHealth -= amount;
        if(currentHealth >= MaxHealth) { currentHealth = MaxHealth; }
        if(MaxHealth < 0) { PlayerDied(); }

        stats.MaxHealth = MaxHealth;
    }
    public void PlayerDied()
    {
        Debug.LogError("PlayerDied");
    }
}
