using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//成绩对像，需要排序，需要序列化
[System.Serializable]
public class Grade : System.IComparable<Grade>
{
    //正确的个数
    public int CorrectCount { get; set; }

    //所用时间
    public double UsingTime { get; set; }

    //先按正确个数降序，再按所用时间升序
    public int CompareTo(Grade other)
    {
        if(other.CorrectCount > CorrectCount)
        {
            return 1;
        }
        else if(other.CorrectCount < CorrectCount)
        {
            return -1;
        }
        else
        {
            if(other.UsingTime > UsingTime)
            {
                return -1;
            }
            else if(other.UsingTime < UsingTime)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}