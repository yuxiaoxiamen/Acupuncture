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
        if (Status.GetInstance().IsAssess)
        {
            Status.GetInstance().CurrentAnswer = name;
            QuestionControl.GetInstance().SetNextQuestion();
        }
        else
        {
            Tool.GetInstance().DisplayText(GetAcupointText(name));
        }
    }

    private string GetAcupointText(string name)
    {
        string text = name + "：\r\n";
        return text + TextData.GetInstance().GetAcipointureDescription(name);
    }
}
