using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public enum TipType { RIGHTANSWER, ERRORANSWER}

public class Tool{

    private static Tool singleInstace;

    private Tool() { }

    public static Tool GetInstance()
    {
        if(singleInstace == null)
        {
            singleInstace = new Tool();
        }
        return singleInstace;
    }

	public void DisplayText(string text)
    {
        GameObject textGameObject = GameObject.FindGameObjectWithTag("Text");
        textGameObject.GetComponent<TextMesh>().text = Regex.Replace(text, @"\S{16}", "$0\r\n"); ;
    }

    public void DisplayTip(string tip, TipType type)
    {
        GameObject tipOriginObject = GameObject.FindGameObjectWithTag("Tip");
        GameObject tipObject = GameObject.Instantiate(tipOriginObject);
        TextMesh textMesh = tipObject.GetComponent<TextMesh>();
        textMesh.text = tip;
        switch (type)
        {
            case TipType.RIGHTANSWER:
                textMesh.color = new Color(0, 1, 0);
                break;
            case TipType.ERRORANSWER:
                textMesh.color = new Color(1, 0, 0);
                break;
        }
        Vector3 initPosition = tipObject.transform.position;
        tipObject.transform.DOMove(initPosition + new Vector3(0, 0.2f, 0), 1f);
        DOTween.ToAlpha(() => textMesh.color, (color) => textMesh.color = color, 0, 1.2f)
            .OnComplete(() => { GameObject.Destroy(tipObject); });
    }
}
