using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passive : MonoBehaviour
{
    public string abilityName;
    public Image abilityImage;
    public string abilityDescription;

    public virtual void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {

    }
    public virtual void Deactivate(GameObject triggeredObject, PlayerResourceController PRC)
    {

    }

}
