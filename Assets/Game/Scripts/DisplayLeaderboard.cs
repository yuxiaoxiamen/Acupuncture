using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLeaderboard : MonoBehaviour {

    public GameObject gradeOriginObject;
    public TextMesh currentCorrectCount;
    public TextMesh currentUsingTime;
    public Vector3 interval;

    // Use this for initialization
    void Start () {
        SaveModel save = SaveModel.GetInstance();
        interval = new Vector3(0, -1.4f, 0);
        Grade currentGrade = save.GetCurrentGrade();
        currentCorrectCount.text = currentGrade.CorrectCount.ToString();
        currentUsingTime.text = currentGrade.UsingTime.ToString();
        Vector3 initPosition = gradeOriginObject.transform.position;
        save.SortGrade();
        int count = save.AllGrades.Count > 5 ? 5 : save.AllGrades.Count;
        for(int i = 0; i < count; ++i)
        {
            GameObject gradeObject = Instantiate(gradeOriginObject, initPosition + i * interval, Quaternion.identity);
            gradeObject.transform.parent = GameObject.Find("leaderboard").transform;
            SetGrade(gradeObject.transform, save.AllGrades[i], i + 1);
        }
	}

    private void SetGrade(Transform gradeObject, Grade grade, int index)
    {
        gradeObject.Find("serial_number").GetComponent<TextMesh>().text = index.ToString();
        gradeObject.Find("correct_count").GetComponent<TextMesh>().text = grade.CorrectCount.ToString();
        gradeObject.Find("using_time").GetComponent<TextMesh>().text = grade.UsingTime.ToString();
    }
}
