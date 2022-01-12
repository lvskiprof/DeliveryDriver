using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  The camera's position needs to follow the players car by being at the same position.
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject thingToFollow;
    [SerializeField]
    float cameraOffset = -10f;  // Camera needs to be offset from the object it is following to see it.

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0f, 0f, cameraOffset);
    }   // LateUpdate()
}   // class FollowCamera