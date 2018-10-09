using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVirtualNeedle : MonoBehaviour {

    private float depth;
    private SteamVR_Controller.Device hand;
    private Transform handTransform;
    public bool isLeft;
    public float coefficient = 2f;
    private Vector3 displacement;
    public GameObject needle;
    private Vector3 startPosition;
    public float degree = 0.7f;
    private float currentDepth;

    // Use this for initialization
    void Start () {
        //int handIndex;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("ModelControl");
        if (isLeft)
        {
            //handIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);  //获得left手柄
            foreach(GameObject gb in objects)
            {
                if (gb.name.Contains("left"))
                {
                    handTransform = gb.transform;
                }
            }
            
        }
        else
        {
            //handIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);  //获得right手柄
            foreach (GameObject gb in objects)
            {
                if (gb.name.Contains("right"))
                {
                    handTransform = gb.transform;
                }
            }
        }

        //hand = SteamVR_Controller.Input(handIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        startPosition = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Status.GetInstance().IsVirtual)
        {
            displacement = handTransform.position - Status.GetInstance().HandleStartPosition;
            Vector3 vector = Status.GetInstance().EndPosition - Status.GetInstance().StartPosition;
            float distance = Vector3.Dot(displacement, vector) / vector.magnitude * coefficient;
            transform.position = vector.normalized * (distance * degree + vector.magnitude) +
                Status.GetInstance().StartPosition * 2 - Status.GetInstance().EndPosition;
            currentDepth = (transform.position - startPosition).magnitude;
            AcupointItem.GetInstance().Dispose(other.gameObject, 1, currentDepth);
            if (currentDepth > depth)
            {
                depth = currentDepth;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Acupoint"))
        { 
            Status.GetInstance().IsVirtual = false;
            needle.GetComponent<NeedleCollision>().enabled = true;
            needle.GetComponent<MeshRenderer>().enabled = true;
            gameObject.SetActive(false);
            Tool.GetInstance().DestoryText();
            //Debug.Log(depth);
            depth = 0;
        }
        
    }
}
