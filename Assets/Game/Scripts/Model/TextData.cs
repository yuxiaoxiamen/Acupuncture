using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//文本数据
public class TextData{
    private static TextData singleInstance;//单例对象
    public Dictionary<string, string> AcupointureDescriptions { get; set; }//穴位描述
    public Dictionary<string, string> MassageDescriptions { get; set; }//按摩信息
    public List<string> AllAcupoints { get; set; }//所有穴位

    private TextData() {
        AcupointureDescriptions = new Dictionary<string, string>();
        MassageDescriptions = new Dictionary<string, string>();
    }

    public static TextData GetInstance()
    {
        if(singleInstance == null)
        {
            singleInstance = new TextData();
        }
        return singleInstance;
    }

    //根据穴位名字得到相应的描述
    public string GetAcipointureDescription(string name)
    {
        return AcupointureDescriptions[name];
    }

    //根据穴位名字得到相应的按摩信息
    public string GetMassageDescription(string name)
    {
        return MassageDescriptions[name];
    }
}
