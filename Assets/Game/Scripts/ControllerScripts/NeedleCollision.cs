using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollision : MonoBehaviour {

    public GameObject needleVirtual;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Acupoint") && !Status.GetInstance().IsVirtual)
        {
            Status.GetInstance().EndPosition = transform.Find("vertex").position;
            Status.GetInstance().StartPosition = transform.position;
            Status.GetInstance().HandleStartPosition = transform.parent.position;
            needleVirtual.SetActive(true);
            needleVirtual.transform.position = transform.position;
            needleVirtual.transform.rotation = transform.rotation;
            needleVirtual.GetComponent<MeshRenderer>().enabled = true;
            GetComponent<NeedleCollision>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Status.GetInstance().IsVirtual = true;
        }
    }
}