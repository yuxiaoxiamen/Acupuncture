using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//记录一些状态或着场景之间要传递的数据
public class Status{

    private static Status singleInstance;//单例对象
    public int DifficultyDegree { get; set; }//考核难度
    public bool IsAssess { get; set; }//是否在考核场景
    public string CurrentQuestion { get; set; }//当前问题
    public string CurrentAnswer { get; set; }//当前答案
    public bool IsVirtual { get; set; }
    public Vector3 StartPosition { get; set; }
    public Vector3 EndPosition { get; set; }
    public Vector3 HandleStartPosition { get; set; }

    private Status() {
        IsVirtual = false;
    }

    public static Status GetInstance()
    {
        if(singleInstance == null)
        {
            singleInstance = new Status();
        }
        return singleInstance;
    } 
}
