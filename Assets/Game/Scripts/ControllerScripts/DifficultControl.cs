using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//考核场景控制难度
public class DifficultControl : MonoBehaviour {

	void Start () {
        //如果是进阶，就将穴位设为透明
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
