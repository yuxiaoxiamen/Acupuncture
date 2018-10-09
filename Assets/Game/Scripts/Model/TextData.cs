using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//文本数据
public class TextData{
    private static TextData singleInstance;//单例对象
    public Dictionary<string, string> AcupointureDescriptions { get; set; }//穴位描述
    public Dictionary<string, string> MassageDescriptions { get; set; }//按摩信息
    public List<string> AllAcupoints { get; set; }//所有穴位
    public List<Vector3> NormalVector3s { get; set; }
    public Dictionary<string, List<AcupointureSkill>> AcupointSkills;

    private TextData() {
        AcupointureDescriptions = new Dictionary<string, string>();
        MassageDescriptions = new Dictionary<string, string>();
        NormalVector3s = new List<Vector3>();
        AcupointSkills = new Dictionary<string, List<AcupointureSkill>>();
        ObtainNormalVectors();
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

    private void ObtainNormalVectors()
    {
        string savePath = "Assets/Game/Resources/";
        var files = Directory.GetFiles(savePath, "normalVectors.bin");
        if (files.Length == 0)
        {
            Debug.Log("没有生成法向量文件");
        }
        else//反序列化
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath + "normalVectors.bin",
                FileMode.Open);
            List<Vector3Serializer> vectors = (List<Vector3Serializer>)formatter.Deserialize(stream);
            foreach(Vector3Serializer v in vectors)
            {
                NormalVector3s.Add(v.V3);
            }
            stream.Close();
        }
    }

    public void PrintSkills()
    {
        foreach(var pair in AcupointSkills)
        {
            Debug.Log(pair.Key);
            foreach(var item in pair.Value)
            {
                Debug.Log(item);
            }
        }
    }
}
