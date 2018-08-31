using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//持久化数据对象
[System.Serializable]
public class SaveModel{

    public List<Grade> AllGrades { get; set; }//所有成绩，用于排行

    private static SaveModel singleInstance;//单例对象

    private SaveModel() {
        AllGrades = new List<Grade>();
    }

    public static SaveModel GetInstance()
    {
        if(singleInstance == null)
        {
            singleInstance = LoadSave();
        }
        return singleInstance;
    }

    public void AddGrade(Grade grade)
    {
        AllGrades.Add(grade);
    }

    public Grade GetCurrentGrade()//当前成绩在list末尾
    {
        return AllGrades[AllGrades.Count - 1];
    }

    public void SortGrade()//排序
    {
        AllGrades.Sort();
    }

    private static SaveModel LoadSave()//加载存储文件
    {
        string savePath = Application.persistentDataPath + "/";
        SaveModel save;
        var files = Directory.GetFiles(savePath, "*.bin");
        if (files.Length == 0)
        {
            save = new SaveModel();
        }
        else//反序列化
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath + "leaderboard.bin",
                FileMode.Open);
            save = (SaveModel)formatter.Deserialize(stream);
            save.AllGrades = save.AllGrades.GetRange(0, 5);//只取前5个数据
            stream.Close();
        }
        return save;
    }



    //存储对象为文件
    public void SaveFile()
    {
        string savePath = Application.persistentDataPath + "/leaderboard.bin";
        IFormatter formatter = new BinaryFormatter();//序列化
        FileStream stream = new FileStream(savePath,
            FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, this);
        stream.Close();
    }
}
