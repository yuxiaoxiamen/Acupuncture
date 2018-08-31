using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//身体对象
public class BodyItem : Item {

    //单例对象
    private static BodyItem singleInstance;

    private BodyItem() { }

    public static BodyItem GetInstance()
    {
        if (singleInstance == null)
        {
            singleInstance = new BodyItem();
        }
        return singleInstance;
    }

    public void Dispose(string name)
    {
        if (Status.GetInstance().IsAssess)//针扎身体，开启下一题
        {
            Status.GetInstance().CurrentAnswer = name;
            QuestionControl.GetInstance().SetNextQuestion();
        }
    }
}
