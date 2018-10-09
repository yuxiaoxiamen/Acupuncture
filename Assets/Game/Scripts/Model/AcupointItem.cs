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
            List<AcupointureSkill> skills = TextData.GetInstance().AcupointSkills[gob.name];
            string text = "当前针与皮肤的夹角为" + angle + "度" + "深度为" + depth + "寸";
            text += gob.name + "：\r\n";
            foreach (var skill in skills)
            {
                if (skill.Angle - 10 < angle && angle < skill.Angle + 10)
                {
                    if(skill.MinDepth < depth && depth < skill.MaxDepth)
                    {
                        Tool.GetInstance().DisplayPicture(skill.Feeling, gob.transform.position + new Vector3(0, 1, -1));
                    }
                }
                text += "正确扎法为：" + skill + "\r\n";
            }
            Tool.GetInstance().DisplayText(text, gob.transform.position + new Vector3(0, 1, 1));
        }
    }

    //public void DisplayFeeling(float depth, float min, float max)
    //{
    //    if(depth)
    //}
}
