using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//显示排行榜上的成绩，和当前成绩
public class DisplayLeaderboard : MonoBehaviour {

    //场景中预先设置好的排行榜成绩对象，通过拖动传值，作为模板动态创建排行榜上的成绩
    public GameObject gradeOriginObject;
    //当前成绩的正确个数，通过拖动传值
    public TextMesh currentCorrectCount;
    //当前成绩的所用时间，通过拖动传值
    public TextMesh currentUsingTime;
    //排行榜上每个成绩之间的间隔
    public Vector3 interval;

    void Start () {
        SaveModel save = SaveModel.GetInstance();
        interval = new Vector3(0, -1.4f, 0);
        Grade currentGrade = save.GetCurrentGrade();
        currentCorrectCount.text = currentGrade.CorrectCount.ToString();
        currentUsingTime.text = currentGrade.UsingTime.ToString();
        SaveModel.GetInstance().SortGrade();
        Vector3 initPosition = gradeOriginObject.transform.position;
        int count = save.AllGrades.Count > 5 ? 5 : save.AllGrades.Count;//排行榜上成绩最多5个
        for(int i = 0; i < count; ++i)//循环显示所有成绩
        {
            GameObject gradeObject = Instantiate(gradeOriginObject, initPosition + i * interval, Quaternion.identity);
            gradeObject.transform.parent = GameObject.Find("leaderboard").transform;
            SetGrade(gradeObject.transform, save.AllGrades[i], i + 1);
        }
	}

    private void OnDestroy()
    {
        SaveModel.GetInstance().SaveFile();//存储成绩
    }

    private void SetGrade(Transform gradeObject, Grade grade, int index)//显示成绩
    {
        gradeObject.Find("serial_number").GetComponent<TextMesh>().text = index.ToString();
        gradeObject.Find("correct_count").GetComponent<TextMesh>().text = grade.CorrectCount.ToString();
        gradeObject.Find("using_time").GetComponent<TextMesh>().text = grade.UsingTime.ToString();
    }
}
