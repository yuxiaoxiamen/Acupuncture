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
            case "start_practice"://如果是练习，就使穴位有效
                EnableAcupoint();
                break;
            case "start_assess"://如果使考核，则使身体也有效，并且开始答题
                EnableAcupoint();
                EnableBody();
                GameObject.FindGameObjectWithTag("GameController").
                    GetComponent<QuestionControl>().enabled = true;
                break;
        }
        GameObject.Destroy(GameObject.Find(name));
    }

    //使穴位对象的碰撞体有效
    private void EnableAcupoint()
    {
        GameObject[] acupointObjects = GameObject.FindGameObjectsWithTag("Acupoint");
        foreach(GameObject o in acupointObjects)
        {
            SphereCollider collider = o.GetComponent<SphereCollider>();
            collider.enabled = true;
        }
    }

    //使身体对象的碰撞体有效
    private void EnableBody()
    {
        GameObject.FindGameObjectWithTag("Body").GetComponent<MeshCollider>().enabled = true;
    }
}