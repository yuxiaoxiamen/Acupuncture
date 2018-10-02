using UnityEngine;

//手柄
public abstract class Handle{

    //保存当前手柄处在的对象
    private Transform currentObject;
    private bool isInItem;
    private static bool isNowDefaultModel = true;

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
}
