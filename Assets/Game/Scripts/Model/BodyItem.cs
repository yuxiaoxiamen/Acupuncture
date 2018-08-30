using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Status.GetInstance().IsAssess)
        {
            Status.GetInstance().CurrentAnswer = name;
            QuestionControl.GetInstance().SetNextQuestion();
        }
    }
}
