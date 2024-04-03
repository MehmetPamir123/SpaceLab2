using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aDashPerfect", menuName = "Abilities/Flexible/Dash/Dash_Perfect")]
public class Abl_Perfect : Abl_Dash
{
    protected GameObject Bullet;
    public override void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {
        if (!usable) { return; }
        usable = false;
        if (energyCost > PRC.GetEnergy()) { return; }
        rb = triggeredObject.GetComponent<Rigidbody2D>();
        PRC.EnergyAdd(-energyCost);
        triggeredObject.GetComponent<MonoBehaviour>().StartCoroutine(this.DashPerfectCoroutine(triggeredObject));

    }
    public IEnumerator DashPerfectCoroutine(GameObject triggeredObject)
    {
        TrailRenderer tr = triggeredObject.GetComponent<TrailRenderer>();
        tr.emitting = true;
        tr.startColor = Color.red;
        for (int i = 0; i < 4; i++)
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

