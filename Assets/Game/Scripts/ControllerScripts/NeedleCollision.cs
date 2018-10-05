using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollision : MonoBehaviour {

    bool isTrigger = false;
    Vector3 needleDirectionVector;
    float depth;
    private SteamVR_Controller.Device hand;
    private Transform handTransform;
    public bool isLeft;
    Vector3 origin;

    private void Start()
    {
        int handIndex;
        if (isLeft)
        {
            handIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);  //获得left手柄
        }
        else
        {
            handIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);  //获得right手柄
        }
        
        hand = SteamVR_Controller.Input(handIndex);
        handTransform = transform.parent;
        origin = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Acupoint"))
        {
            var vertexPosition = transform.Find("vertex").position;
            var contactPoint = transform.position;
            needleDirectionVector = vertexPosition - contactPoint;
            //Debug.Log(needleDirectionVector);
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    private void Update()
    {

        if (isTrigger)
        {
            transform.parent.position = handTransform.position;
            //float distance = Vector3.Dot(hand.velocity, needleDirectionVector) / needleDirectionVector.magnitude;
            //Debug.Log(distance);
            //var rig = GetComponent<Rigidbody>();
            //rig.isKinematic = true;
            //rig.velocity = Vector3.zero;
            //Debug.Log(hand.velocity);
        }
    }
}