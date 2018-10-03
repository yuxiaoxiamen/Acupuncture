using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollision : MonoBehaviour {

    Transform vertex;

    private void Start()
    {
       vertex = transform.Find("vertex");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Acupoint"))
        {
            
        }
    }

    
}