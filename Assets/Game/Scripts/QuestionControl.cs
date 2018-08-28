using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public static void SetNextQuestion()
    {
        int randomIndex = Random.Range(0, TextData.GetInstance().AllAcupoints.Count);
        Status.GetInstance().CurrentQuestion = TextData.GetInstance().AllAcupoints[randomIndex];
    }
}
