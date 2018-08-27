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

        }
    }
}
