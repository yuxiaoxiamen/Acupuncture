using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radial : Handle
{
    public override void OnHandleClick(object sender, ClickedEventArgs e)
    {
        Item item = null;
        if (IsInItem)
        {
            switch (CurrentObject.tag)//根据对象的标签，来实例化对应的对象
            {
                case "SwitchScene":
                    item = SwitchSceneItem.GetInstance();
                    break;
                case "Procedure":
                    item = ProcedureItem.GetInstance();
                    break;
            }
            if (item != null)
            {
                item.Dispose(CurrentObject.name);
            }
        }
    }

    public override void OnHandleIn(object sender, PointerEventArgs e)//在进入对象时，记录对象
    {
        CurrentObject = e.target;
        IsInItem = true;
        if (CurrentObject.tag.Equals("Body") || CurrentObject.tag.Equals("Acupoint"))
        {
            ReplaceHandleModel();
        }
    }

    public override void OnHandleOut(object sender, PointerEventArgs e)
    {
        IsInItem = false;
    }
}
