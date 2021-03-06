﻿using UnityEngine;

//手柄
public abstract class Handle{

    //保存当前手柄处在的对象
    private Transform currentObject;
    private bool isInItem;
    private static bool isNowDefaultModel = true;
    public float rotationIncrease = 500f;

    public Transform CurrentObject
    {
        get
        {
            return currentObject;
        }

        set
        {
            currentObject = value;
        }
    }

    public bool IsInItem
    {
        get
        {
            return isInItem;
        }

        set
        {
            isInItem = value;
        }
    }

    //手柄进入对象时调用
    public abstract void OnHandleIn(object sender, PointerEventArgs e);
    //手柄离开对象时调用
    public abstract void OnHandleOut(object sender, PointerEventArgs e);
    //手柄点击时调用
    public abstract void OnHandleClick(object sender, ClickedEventArgs e);
    //替换手柄模型
    public void ReplaceHandleModel()
    {
        GameObject[] modelControls = GameObject.FindGameObjectsWithTag("ModelControl");
        foreach (GameObject control in modelControls)
        {
            GameObject oldRay = control.transform.Find("New Game Object").gameObject;
            oldRay.SetActive(!isNowDefaultModel);
            Transform oldModel = control.transform.Find("Model");
            oldModel.gameObject.SetActive(!isNowDefaultModel);
            Transform newModel = control.transform.Find("needle");
            newModel.gameObject.SetActive(isNowDefaultModel);
        }
        isNowDefaultModel = !isNowDefaultModel;
    }

    public void RotationModel(object sender, ClickedEventArgs e)
    {
        //Debug.Log(e.padX + " " + e.padY);
        GameObject person = GameObject.Find("person");
        if(e.padX < -0.5f&& e.padX < 0 && e.padY > -0.5f && e.padY < 0)
        {
            //Debug.Log("zuo");
            person.transform.Rotate(Vector3.up, rotationIncrease * Time.deltaTime, Space.Self);
        }
        else if(e.padX>0.5 && e.padY > -0.5 && e.padY < 0.25)
        {
           //Debug.Log("you");
            person.transform.Rotate(Vector3.up, -rotationIncrease * Time.deltaTime, Space.Self);
        }
    }
}
