using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "aDash", menuName = "Abilities/Flexible/Dash/Dash_Normal")]
[System.Serializable]
public class Abl_Dash : Ability
{ 
    protected Rigidbody2D rb;
    public int dashVelocity;
    public override void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {
        if (!usable) { return; }
        usable = false;
        if (energyCost > PRC.GetEnergy()) { return; }
        rb = triggeredObject.GetComponent<Rigidbody2D>();
        PRC.EnergyAdd(-energyCost);

        triggeredObject.GetComponent<MonoBehaviour>().StartCoroutine(this.DashCoroutine(triggeredObject));
        StartCooldown(triggeredObject.GetComponent<MonoBehaviour>());
    }
    private IEnumerator DashCoroutine(GameObject triggeredObject)
    {
        TrailRenderer tr = triggeredObject.GetComponent<TrailRenderer>();
        tr.emitting = true;
        tr.startColor = Color.white;
        Vector2 dashVector = triggeredObject.GetComponent<Transform>().up * dashVelocity;
        rb.velocity += dashVector;
        yield return new WaitForSeconds(0.1f);
        rb.velocity -= dashVector;
        tr.emitting = false;
    }
    public override void AfterCooldown()
    {
        usable = true;
    }
    public override void AfterDectivate()
    {
        throw new NotImplementedException();
    }
}



