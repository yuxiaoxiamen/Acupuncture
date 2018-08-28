using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        LoadAcupointDetail("acupuncture_description", TextData.GetInstance().AcupointureDescriptions);
        LoadAcupointDetail("massage_description", TextData.GetInstance().MassageDescriptions);
    }

    void LoadAcupointDetail(string fileName, Dictionary<string, string> pairs)
    {
        List<string> acupoints = LoadAllLineToList("acupoint_name");
        List<string> details = LoadAllLineToList(fileName);
        for(int i = 0; i < acupoints.Count; ++i)
        {
            pairs.Add(acupoints[i], details[i]);
        }
    }

    List<string> LoadAllLineToList(string fileName)
    {
        List<string> list = new List<string>();
        string texts = Resources.Load("texts/"+fileName).ToString();
        using (System.IO.StringReader reader = new System.IO.StringReader(texts))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
        }
        return list;
    }

}
