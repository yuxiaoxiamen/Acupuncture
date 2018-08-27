﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//针
public class Needle : Handle
{
    public override void OnHandleClick(object sender, ClickedEventArgs e)
    {
        if (IsInItem)
        {
            Item item = null;
            switch (CurrentObject.tag)
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
            }
            item.Dispose(CurrentObject.name);
        }
    }

    public override void OnHandleIn(object sender, PointerEventArgs e)
    {
        CurrentObject = e.target;
        IsInItem = true;
    }

    public override void OnHandleOut(object sender, PointerEventArgs e)
    {
        IsInItem = false;
    }
}