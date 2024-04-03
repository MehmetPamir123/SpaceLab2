using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowingObject;
    private void Update()
    {
        transform.position = new Vector3(FollowingObject.position.x,FollowingObject.position.y,transform.position.z);
    }
}
