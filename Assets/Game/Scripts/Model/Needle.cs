using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//针
public class Needle : Handle
{

    public override void OnHandleClick(object sender, ClickedEventArgs e)
    {
        Item item = null;
        if (IsInItem)
        {
            switch (CurrentObject.tag)//根据对象的标签，来实例化对应的对象
            {
                case "SwitchScene":
                    item =  SwitchSceneItem.GetInstance();
                    break;
                case "Acupoint":
                    item = AcupointItem.GetInstance();
                    break;
                case "Procedure":
                    item = ProcedureItem.GetInstance();
                    break;
                case "Body":
                    item = BodyItem.GetInstance();
                    break;
            }
            if(item != null)
            {
                item.Dispose(CurrentObject.name);
            }
        }
    }

    public override void OnHandleIn(object sender, PointerEventArgs e)//在进入对象时，记录对象
    {
        CurrentObject = e.target;
        IsInItem = true;
    }

    public override void OnHandleOut(object sender, PointerEventArgs e)
    {
        IsInItem = false;
    }
}