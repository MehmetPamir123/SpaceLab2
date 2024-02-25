using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropableItemPassive : DropableItem
{
    public Passive passive;

    public override void SetStats()
    {
        if(MouseAbilityData.passive == null) { base.SetStats(); return; }
        passive = MouseAbilityData.passive;

        Debug.Log(passive.abilityName);
        GetComponent<Image>().sprite = passive.abilityImage;
        base.SetStats();
    }
    
}
