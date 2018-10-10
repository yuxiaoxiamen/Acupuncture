using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//穴位对象
public class AcupointItem
{

    //单例对象
    private static AcupointItem singleInstance;

    private AcupointItem() { }

    public static AcupointItem GetInstance()
    {
        if (singleInstance == null)
        {
            singleInstance = new AcupointItem();
        }
        return singleInstance;
    }

    public void Dispose(GameObject gob, float angle, float depth)
    {
        //如果是考核，记录当前穴位名字作为答案，并开启下一题
        if (Status.GetInstance().IsAssess)
        {
            Status.GetInstance().CurrentAnswer = gob.name;
            QuestionControl.GetInstance().SetNextQuestion();
        }
        else//如果是练习，就显示穴位的信息
        {
            string name = gob.name.Split('-')[0];
            List<AcupointureSkill> skills = TextData.GetInstance().AcupointSkills[name];
            string text = "当前针与皮肤的夹角为" + angle + "度" + "深度为" + GetLnch(depth) + "寸";
            text += name + "：\r\n";
            foreach (var skill in skills)
            {
                if (skill.Angle - 10 < angle && angle < skill.Angle + 10)
                {
                    if(skill.MinDepth < GetLnch(depth) && GetLnch(depth) < skill.MaxDepth)
                    {
                        Debug.Log("aaaa");
                        string[] feelings = skill.Feeling.Split();
                        for(int i = 0; i < feelings.Length; ++i)
                        {
                            Tool.GetInstance().DisplayPicture(feelings[i], gob.transform.position + (i + 1) * new Vector3(-7f, -3f, 1.5f));
                        }
                    }
                }
                text += "正确扎法为：" + skill + "\r\n";
            }
            Tool.GetInstance().DisplayText(text, gob.transform.position + new Vector3(-7f, -3f, 1.5f));
        }
    }

    float GetLnch(float number)
    {
        return (float)System.Math.Round(number / 66, 2);
    }
    //public void DisplayFeeling(float depth, float min, float max)
    //{
    //    if(depth)
    //}
}
