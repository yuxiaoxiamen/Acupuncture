using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

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
}
