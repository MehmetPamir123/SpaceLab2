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
        Debug.Log(PRC.GetEnergy());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Skill1Ability.Activate(player,PRC);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Skill2Ability.Activate(player,PRC);
        }
    }
}
