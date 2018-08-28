using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Status.GetInstance().DifficultyDegree == 2)
        {
            GameObject[] acupointObjects = GameObject.FindGameObjectsWithTag("Acupoint");
            foreach (GameObject o in acupointObjects)
            {
                o.GetComponent<MeshRenderer>().material = Resources.Load<Material>("materials/transparent");
            }
        }
	}
}
