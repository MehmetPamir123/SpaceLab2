using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public int currentSkillLevel;
    public Image abilityImage;
    public string abilityDescription;


    public int energyCost;
    public float activeTime;
    public float cooldown;
    [Space(20)]
    public bool usable = true;
    
    public abstract void Activate(GameObject triggeredObject, PlayerResourceController PRC);
    public abstract void AfterDectivate();

    public virtual void StartCooldown(MonoBehaviour Mono)
    {
        Mono.StartCoroutine(Cooldown());
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        AfterCooldown();
    }
    public abstract void AfterCooldown();
}
public interface IAbility 
{
    void Activate();
};

public enum SkillMastery
{
    Locked,
    Passive,
    Normal,
    Master,
    Perfect,
}