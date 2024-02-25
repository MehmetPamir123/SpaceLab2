using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityController : MonoBehaviour
{
    public List<Ability> AllAbilities;

    public Ability Skill1Ability;
    public Ability Skill2Ability;
    public Ability Skill3Ability;

    public GameObject player;
    PlayerResourceController PRC;
    private void Start()
    {
        PRC = GameObject.FindGameObjectWithTag("PlayerResourceController").GetComponent<PlayerResourceController>();
    }
    public void SkillUse(int abilityNummer)
    {
        switch (abilityNummer)
        {
            default:
                break;

            case 1:
                Skill1Ability.Activate(player, PRC);
                break;

            case 2:
                Skill2Ability.Activate(player, PRC);
                break;

            case 3:
                Skill3Ability.Activate(player, PRC);
                break;
        }
    }
}
