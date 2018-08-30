using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SaveModel{

    public List<Grade> AllGrades { get; set; }

    private static SaveModel singleInstance;

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

    public Grade GetCurrentGrade()
    {
        return AllGrades[AllGrades.Count - 1];
    }

    public void SortGrade()
    {
        AllGrades.Sort();
    }

    private static SaveModel LoadSave()
    {
        string savePath = Application.persistentDataPath + "/";
        SaveModel save;
        var files = Directory.GetFiles(savePath, "*.bin");
        if (files.Length == 0)
        {
            save = new SaveModel();
        }
        else
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath + "leaderboard.bin",
                FileMode.Open);
            save = (SaveModel)formatter.Deserialize(stream);
            stream.Close();
        }
        return save;
    }

    public void SaveFile()
    {
        string savePath = Application.persistentDataPath + "/leaderboard.bin";
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(savePath,
            FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, this);
        stream.Close();
    }
}
