using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShower : MonoBehaviour
{
    public Skills[] skills;
    List<GameObject> AllShowedSkillTrees = new List<GameObject>();

    private void Start()
    {
        
    }
    public void ShowAttack()
    {
        DeleteShowedSkills();

        foreach (Skills item in skills)
        {
            if(item.Type == SkillType.Attack)
            {
                AllShowedSkillTrees.Add(item.SkillTree);
                SkillTree skillTree = Instantiate(item.SkillTree, this.transform).GetComponent<SkillTree>();
            }
        }
    }

    public void DeleteShowedSkills()
    {
        foreach (GameObject item in AllShowedSkillTrees)
        {
            Destroy(item);
        }
    }
}

[System.Serializable]
public class Skills
{
    public string Name;
    public SkillType Type;
    public GameObject SkillTree;
}


