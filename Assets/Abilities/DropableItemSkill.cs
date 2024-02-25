using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragableItemSkill : DropableItem
{
    public Ability ability;
    public override void SetStats()
    {
        if (MouseAbilityData.ability == null) { base.SetStats(); return;  }
        ability = MouseAbilityData.ability;
        GetComponent<Image>().sprite = ability.abilityImage;
        base.SetStats();
    }
}
