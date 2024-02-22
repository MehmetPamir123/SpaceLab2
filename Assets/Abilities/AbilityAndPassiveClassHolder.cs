using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Holder", menuName = "Abilities/AbilityClassHolder")]
[System.Serializable]
public class AbilityAndPassiveClassHolder : ScriptableObject
{
    public Passive passive;
    public Ability abilityNormal;
    public Ability abilityMaster;
    public Ability abilityPerfect;
    public SkillMastery Mastery;
    public int Level;
}

