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
        //如果是返回对象，则取出要返回的场景名，否则就直接切换到对象名对应的场景
        if (name.StartsWith("return"))
        {
            string sceneName = name.Split('_')[1];
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
}
