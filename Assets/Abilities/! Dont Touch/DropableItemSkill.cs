using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropableItemSkill : DropableItem
{
    public int skillPlace;
    Ability ability;
    public override void SetStats()
    {
        if (MouseAbilityData.ability == null) { base.SetStats(); return;  }
        ability = MouseAbilityData.ability;

        PAC.AddSkillToSkillSlot(ability, skillPlace, this.gameObject.GetComponent<Image>());
    }
}
