using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionControl : MonoBehaviour {

    public int totalCount = 10;
    public int totalTime = 10;
    private int currentIndex = 0;
    private int correctCount = 0;
    private int leaveSeconds;
    private Stopwatch sw = new Stopwatch();
    private static QuestionControl singleInstance;
    public TextMesh countDownText;

    // Use this for initialization
    void Start () {
        leaveSeconds = totalTime;
        singleInstance = this;
        sw.Start();
        SetNextQuestion();
	}

    private void Update()
    {
        countDownText.text = leaveSeconds.ToString();
    }

    private void OnDestroy()
    {
        SaveModel.GetInstance().SaveFile();
    }

    public void SetNextQuestion()
    {
        if(currentIndex >= totalCount)
        {
            StopTest();
        }
        else
        {
            if (currentIndex > 0)
            {
                SetAnswer();
            }
            StopAllCoroutines();
            int randomIndex = Random.Range(0, TextData.GetInstance().AllAcupoints.Count);
            Status.GetInstance().CurrentQuestion = TextData.GetInstance().AllAcupoints[randomIndex];
            ++currentIndex;
            Tool.GetInstance().DisplayText("第" + currentIndex + "题：" + Status.GetInstance().CurrentQuestion);
            leaveSeconds = totalTime;
            StartCoroutine(DoCountDown());
        }
    }

    private void StopTest()
    {
        sw.Stop();
        Grade grade = new Grade();
        grade.CorrectCount = correctCount;
        grade.UsingTime = sw.ElapsedMilliseconds/1000.0;
        SaveModel.GetInstance().AddGrade(grade);
        SceneManager.LoadScene("Result");
    }

    private void SetAnswer()
    {
        if (Status.GetInstance().CurrentAnswer.
            Equals(Status.GetInstance().CurrentQuestion))
        {
            Tool.GetInstance().DisplayTip("正确", TipType.RIGHTANSWER);
            ++correctCount;
        }
        else
        {
            Tool.GetInstance().DisplayTip("错误", TipType.ERRORANSWER);
        }
    }

    IEnumerator DoCountDown()
    {
        while (leaveSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            leaveSeconds--;
        }
        if(leaveSeconds <= 0)
        {
            Status.GetInstance().CurrentAnswer = "";
            SetNextQuestion();
        }
    }

    public static QuestionControl GetInstance()
    {
        return singleInstance;
    }
}