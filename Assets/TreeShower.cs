using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShower : MonoBehaviour
{
    public GameObject[] SkillTreeTypes = new GameObject[3];

    public void ShowThisType(int type) //for buttons
    {
        for (int i = 0; i < SkillTreeTypes.Length; i++)
        {
            SkillTreeTypes[i].SetActive(false);
        }
        SkillTreeTypes[type].SetActive(true);
    }
}