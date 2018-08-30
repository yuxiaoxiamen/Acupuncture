using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grade : System.IComparable<Grade>
{

    public int CorrectCount { get; set; }

    public double UsingTime { get; set; }

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