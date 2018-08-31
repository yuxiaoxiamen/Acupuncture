using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//穴位对象
public class AcupointItem : Item {

    //单例对象
    private static AcupointItem singleInstance;

    private AcupointItem() { }

    public static AcupointItem GetInstance()
    {
        if(singleInstance == null)
        {
            singleInstance = new AcupointItem();
        }
        return singleInstance;
    }

    public void Dispose(string name)
    {
        //如果是考核，记录当前穴位名字作为答案，并开启下一题
        if (Status.GetInstance().IsAssess)
        {
            Status.GetInstance().CurrentAnswer = name;
            QuestionControl.GetInstance().SetNextQuestion();
        }
        else//如果是练习，就显示穴位的信息
        {
            Tool.GetInstance().DisplayText(GetAcupointText(name));
        }
    }

    //格式化信息
    private string GetAcupointText(string name)
    {
        string text = name + "：\r\n";
        return text + TextData.GetInstance().GetAcipointureDescription(name);
    }
}
