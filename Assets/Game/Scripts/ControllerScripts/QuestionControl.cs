using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionControl : MonoBehaviour {

    public int totalCount = 10;//总题数
    public int totalTime = 10;//倒计时时长
    private int currentIndex = 0;//当前题数
    private int correctCount = 0;//正确个数
    private int leaveSeconds;//剩余时间
    private Stopwatch sw = new Stopwatch();//记录总共用时
    private static QuestionControl singleInstance;//单例对象
    public TextMesh countDownText;//显示剩余时间的数字

    void Start () {
        leaveSeconds = totalTime;
        singleInstance = this;
        sw.Start();//开始计时
        SetNextQuestion();//第一题
	}

    private void Update()
    {
        countDownText.text = leaveSeconds.ToString();
    }

    public void SetNextQuestion()
    {
        if(currentIndex >= totalCount)//答完所有题
        {
            StopTest();
        }
        else
        {
            if (currentIndex > 0)//第一题不用设置答案
            {
                SetAnswer();
            }
            StopAllCoroutines();//结束倒计时
            int randomIndex = Random.Range(0, TextData.GetInstance().AllAcupoints.Count);//随机挑选穴位
            Status.GetInstance().CurrentQuestion = TextData.GetInstance().AllAcupoints[randomIndex];
            ++currentIndex;
            Tool.GetInstance().DisplayText("第" + currentIndex + "题：" + Status.GetInstance().CurrentQuestion);//显示题目
            leaveSeconds = totalTime;//重新计时
            StartCoroutine(DoCountDown());
        }
    }

    //结束考核时调用
    private void StopTest()
    {
        sw.Stop();//停止计时
        Grade grade = new Grade//记录成绩
        {
            CorrectCount = correctCount,
            UsingTime = sw.ElapsedMilliseconds / 1000.0
        };
        SaveModel.GetInstance().AddGrade(grade);
        SceneManager.LoadScene("Result");
    }

    //设置答案
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

    //倒计时，每隔一秒剩余时间就减一
    IEnumerator DoCountDown()
    {
        while (leaveSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            leaveSeconds--;
        }
        if(leaveSeconds <= 0)//如果时间到了，就下一题
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