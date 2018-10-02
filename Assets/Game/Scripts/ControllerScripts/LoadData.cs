using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	void Awake () {

        //只加载一次
        if(TextData.GetInstance().AllAcupoints == null)
        {
            LoadAllAcupoints();//加载所有穴位名
            LoadAcupointDetail("acupuncture_description", TextData.GetInstance().AcupointureDescriptions);//加载穴位的描述
            LoadAcupointDetail("massage_description", TextData.GetInstance().MassageDescriptions);//加载按摩信息
        }
    }

    void LoadAllAcupoints()
    {
        TextData.GetInstance().AllAcupoints = LoadAllLineToList("acupoint_name");
    }

    void LoadAcupointDetail(string fileName, Dictionary<string, string> pairs)
    {
        List<string> acupoints = TextData.GetInstance().AllAcupoints;
        List<string> details = LoadAllLineToList(fileName);
        for(int i = 0; i < acupoints.Count; ++i)
        {
            pairs.Add(acupoints[i], details[i]);//穴位名为键，信息为值
        }
    }

    //将文件一行一行的读出，并返回所有行的list
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
