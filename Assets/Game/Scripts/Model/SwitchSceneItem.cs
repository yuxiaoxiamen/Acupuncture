using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//切换场景的对象
public class SwitchSceneItem : Item{

    //单例对象
    private static SwitchSceneItem singleInstance;

    private SwitchSceneItem() { }

    public static SwitchSceneItem GetInstance()
    {
        if (singleInstance == null)
        {
            singleInstance = new SwitchSceneItem();
        }
        return singleInstance;
    }

    public void Dispose(string name)
    {
        string[] nameSplit = name.Split('_');
        //取出要返回的场景名
        string sceneName = nameSplit[1];
        //如果是跳转到考核场景，记录考核场景的难度系数，是否处在考核场景
        if(sceneName.Equals("AcuAssess"))
        {
            Status.GetInstance().DifficultyDegree = int.Parse(nameSplit[2]);
            Status.GetInstance().IsAssess = true;
        }
        if (sceneName.Equals("AcuPractice"))
        {
            Status.GetInstance().IsAssess = false;
        }
        SceneManager.LoadScene(sceneName);//跳转场景
    }
}
