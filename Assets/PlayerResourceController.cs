using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResourceController : MonoBehaviour,IDataPersistance
{
    public Slider healthSlider;
    [SerializeField] int MaxHealth;
    [SerializeField] int currentHealth;
    [Space(20)]
    public Slider fuelSlider;
    [SerializeField] int MaxFuel;
    [SerializeField] float currentFuel;
    [Space(20)]
    public Slider energySlider;
    [SerializeField] int MaxEnergy;
    [SerializeField] float currentEnergy;


    public void HealthAdd(int amount)
    {
        currentHealth += amount;
        if (currentHealth < 0) { PlayerDied(); }
        if (currentHealth > MaxHealth) { currentHealth = MaxHealth; }

        healthSlider.value = currentHealth;
    }
    public void MaxHealthAdd(int amount)
    {
        MaxHealth += amount;
        if (currentHealth >= MaxHealth) { currentHealth = MaxHealth; }
        if (MaxHealth < 0) { PlayerDied(); }
        healthSlider.maxValue = MaxHealth;
    }


    public void FuelAdd(float amount)
    {
        currentFuel += amount;
        if (currentFuel < 0) { PlayerDied(); }
        if (currentFuel > MaxFuel) { currentFuel = MaxFuel; }

        fuelSlider.value = currentFuel;
    }
    public void MaxFuelAdd(int amount)
    {
        MaxFuel+= amount;
        if (currentFuel >= MaxFuel) { currentFuel = MaxFuel; }
        if (MaxFuel < 0) { PlayerDied(); }
        fuelSlider.maxValue = MaxFuel;
    }


    public void EnergyAdd(float amount)
    {
        currentEnergy += amount;
        if (currentEnergy > MaxEnergy) { currentEnergy = MaxEnergy; }

        energySlider.value = currentEnergy;
    }
    public void MaxEnergyAdd(int amount)
    {
        MaxEnergy += amount;
        if (currentEnergy >= MaxEnergy) { currentEnergy = MaxEnergy; }
        energySlider.maxValue = MaxEnergy;
    }


    public float GetEnergy() { return currentEnergy; }

    public void PlayerDied()
    {
        Debug.LogError("PlayerDied");
    }

    public void LoadData(GameData data)
    {
        MaxHealth = data.MaxHealth;
        currentHealth = data.CurrentHeath;
        MaxFuel = data.MaxFuel;
        currentFuel = data.Fuel;
        MaxEnergy = data.MaxEnergy;
        currentEnergy = data.Energy;

        healthSlider.maxValue = MaxHealth;
        healthSlider.value = currentHealth;
        fuelSlider.maxValue = MaxFuel ;
        fuelSlider.value = currentFuel;
        energySlider.maxValue = MaxEnergy;
        energySlider.value = currentEnergy;
    }

    public void SaveData(ref GameData data)
    {
        data.MaxHealth = MaxHealth;
        data.CurrentHeath = currentHealth;
        data.MaxFuel = MaxFuel;
        data.Fuel = currentFuel;
        data.MaxEnergy = MaxEnergy;
        data.Energy = currentEnergy;
    }


    public bool InventoryNumber = false; //false=inner   true=outher
    public Image Butt_Switch;
    public GameObject InnerInventory;
    public GameObject OuterInventory;
    public Sprite spriteInner;
    public Sprite spriteOuter;

    public void SwitchInventory()
    {
        if (InventoryNumber)
        {
            InnerInventory.SetActive(true);
            OuterInventory.SetActive(false);
            InventoryNumber = false;
            Butt_Switch.sprite = spriteInner;
        }
        else
        {
            InnerInventory.SetActive(false);
            OuterInventory.SetActive(true);
            InventoryNumber = true;
            Butt_Switch.sprite = spriteOuter;
        }



    }
}
