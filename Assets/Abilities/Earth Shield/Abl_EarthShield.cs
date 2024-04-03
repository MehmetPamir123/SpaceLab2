using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "aEarth Shield", menuName = "Abilities/Defence/Earth Shield/Earth Shield_Normal")]
[System.Serializable]
public class Abl_EarthShield : Ability
{
    
    public GameObject EarthShield;
    public int ShieldHP;
    public override void AfterDectivate()
    {
        throw new System.NotImplementedException();
    }

    public override void Activate(GameObject triggeredObject,PlayerResourceController PRC)
    {
        if(!usable) { return; }
        usable = false;
        PRC = GameObject.FindGameObjectWithTag("PlayerResourceController").GetComponent<PlayerResourceController>();
        if (PRC.GetEnergy() < energyCost) { return; }
        PRC.EnergyAdd(-energyCost);

        GameObject instE = Instantiate(EarthShield);
        instE.GetComponent<EarthShield>().HP = ShieldHP;

       triggeredObject.GetComponent<MonoBehaviour>().StartCoroutine(ShieldTime(instE));
        StartCooldown(triggeredObject.GetComponent<MonoBehaviour>());
    }
    IEnumerator ShieldTime(GameObject instE)
    {
        yield return new WaitForSeconds(activeTime);
        Destroy(instE);
    }

    public override void AfterCooldown()
    {
        usable = true;
    }
}
