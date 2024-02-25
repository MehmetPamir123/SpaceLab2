using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passive : ScriptableObject
{
    public string abilityName;
    public Sprite abilityImage;
    public string abilityDescription;

    public virtual void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {

    }
    public virtual void Deactivate(GameObject triggeredObject, PlayerResourceController PRC)
    {

    }

}
