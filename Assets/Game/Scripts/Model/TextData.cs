using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData{
    private static TextData singleInstance;
    public Dictionary<string, string> AcupointureDescriptions { get; set; }
    public Dictionary<string, string> MassageDescriptions { get; set; }
    public List<string> AllAcupoints { get; set; }

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

    public string GetAcipointureDescription(string name)
    {
        return AcupointureDescriptions[name];
    }

    public string GetMassageDescription(string name)
    {
        return MassageDescriptions[name];
    }
}
