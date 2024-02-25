using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aDashMaster", menuName = "Abilities/Flexible/Dash_Master")]
public class Abl_DashMaster : Abl_Dash
{
    public override void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {
        if (!usable) { return; }
        usable = false;
        if (energyCost > PRC.GetEnergy()) { return; }
        rb = triggeredObject.GetComponent<Rigidbody2D>();
        PRC.EnergyAdd(-energyCost);
        triggeredObject.GetComponent<MonoBehaviour>().StartCoroutine(this.DashMasterCoroutine(triggeredObject));
    }
    public IEnumerator DashMasterCoroutine(GameObject triggeredObject)
    {

        TrailRenderer tr = triggeredObject.GetComponent<TrailRenderer>();
        tr.emitting = true;
        tr.startColor = Color.magenta;
        for (int i = 0; i < 2; i++)
        {
            Vector2 dashVector = triggeredObject.GetComponent<Transform>().up * dashVelocity;
            rb.velocity += dashVector;
            yield return new WaitForSeconds(0.1f);
            rb.velocity -= dashVector;


        }
        tr.emitting = false;
        StartCooldown(triggeredObject.GetComponent<MonoBehaviour>());
    }

}
