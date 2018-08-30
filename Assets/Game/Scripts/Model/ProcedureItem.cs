using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制程序流程的对象
public class ProcedureItem : Item
{
    //单例对象
    private static ProcedureItem singleInstance;

    private ProcedureItem() { }

    public static ProcedureItem GetInstance()
    {
        if (singleInstance == null)
        {
            singleInstance = new ProcedureItem();
        }
        return singleInstance;
    }

    public void Dispose(string name)
    {
        switch (name)
        {
            case "start_practice":
                EnableAcupoint();
                break;
            case "start_assess":
                EnableAcupoint();
                EnableBody();
                GameObject.FindGameObjectWithTag("GameController").
                    GetComponent<QuestionControl>().enabled = true;
                break;
        }
        GameObject.Destroy(GameObject.Find(name));
    }

    private void EnableAcupoint()
    {
        GameObject[] acupointObjects = GameObject.FindGameObjectsWithTag("Acupoint");
        foreach(GameObject o in acupointObjects)
        {
            SphereCollider collider = o.GetComponent<SphereCollider>();
            collider.enabled = true;
        }
    }

    private void EnableBody()
    {
        GameObject.FindGameObjectWithTag("Body").GetComponent<MeshCollider>().enabled = true;
    }
}