using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEngine;

//工具类
public class Tool{

    //单例对象
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

    //在场景中显示文字
	public void DisplayText(string text, Vector3 position)
    {
        GameObject textGameObject = GameObject.FindGameObjectWithTag("Text");
        textGameObject.GetComponent<TextMesh>().text = Regex.Replace(text, @"\S{16}", "$0\r\n");
        if (!position.Equals(Vector3.zero))
        {
            textGameObject.transform.position = position;
        }
    }

    public void DestoryText()
    {
        GameObject textGameObject = GameObject.FindGameObjectWithTag("Text");
        textGameObject.GetComponent<TextMesh>().text = "";
    }

    public void DisplayPicture(string pictureName, Vector3 position)
    {
        GameObject picGameObject = GameObject.FindGameObjectWithTag("Picture");
        
        SpriteRenderer spr = picGameObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("feedback/" + pictureName);
        if (!position.Equals(Vector3.zero))
        {
            picGameObject.transform.position = position;
        }
        //DOTween.ToAlpha(() => spr.color
        //, x => spr.color = x, 0, 0.5f);
    }

    //在场景中显示提示
    public void DisplayTip(string tip, Color color)
    {
        GameObject tipOriginObject = GameObject.FindGameObjectWithTag("Tip");
        GameObject tipObject = GameObject.Instantiate(tipOriginObject);
        TextMesh textMesh = tipObject.GetComponent<TextMesh>();
        textMesh.text = tip;//设置文字
        textMesh.color = color;
        Vector3 initPosition = tipObject.transform.position;
        tipObject.transform.DOMove(initPosition + new Vector3(0, 0.2f, 0), 1f);//向上移动
        DOTween.ToAlpha(() => textMesh.color, (c) => textMesh.color = c, 0, 1.2f)//慢慢变淡
            .OnComplete(() => { GameObject.Destroy(tipObject); });//结束销毁
    }

    public void SerializeObject(string path, System.Object ob)
    {
        IFormatter formatter = new BinaryFormatter();//序列化
        FileStream stream = new FileStream(path,
            FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, ob);
        stream.Close();
    }
}
