using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status{

    private static Status singleInstance;
    public int DifficultyDegree { get; set; }
    public bool IsAssess { get; set; }
    public string CurrentQuestion { get; set; }
    public string CurrentAnswer { get; set; }

    private Status() { }

    public static Status GetInstance()
    {
        if(singleInstance == null)
        {
            singleInstance = new Status();
        }
        return singleInstance;
    } 
}
