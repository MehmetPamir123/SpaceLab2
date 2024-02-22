using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aSpace Bullet", menuName = "Abilities/Attack/Space Bullet")]
[System.Serializable]
public class Abl_SpaceBullet : Ability
{
    public override void Activate(GameObject triggeredObject, PlayerResourceController PRC)
    {

    }

    public override void AfterCooldown()
    {
        throw new System.NotImplementedException();
    }

    public override void AfterDectivate()
    {
        throw new System.NotImplementedException();
    }
}
