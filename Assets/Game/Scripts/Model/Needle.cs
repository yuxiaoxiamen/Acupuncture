using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//针
public class Needle : Handle
{

    public override void OnHandleClick(object sender, ClickedEventArgs e)
    {

    }

    public override void OnHandleIn(object sender, PointerEventArgs e)//在进入对象时，记录对象
    {
        CurrentObject = e.target;
        IsInItem = true;
    }

    public override void OnHandleOut(object sender, PointerEventArgs e)
    {
        IsInItem = false;
        if (e.target.tag.Equals("Body") && !Status.GetInstance().IsVirtual)
        {
            ReplaceHandleModel();
        }
    }
}