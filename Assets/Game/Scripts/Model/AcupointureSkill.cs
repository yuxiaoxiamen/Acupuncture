using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcupointureSkill{

	public float Angle { get; set; }
    public float MinDepth { get; set; }
    public float MaxDepth { get; set; }
    public string Feeling { get; set; }

    public AcupointureSkill(float angle, float minDepth, float maxDepth, string feeling)
    {
        Angle = angle;
        MinDepth = minDepth;
        MaxDepth = maxDepth;
        Feeling = feeling;
    }

    public override string ToString()
    {
        return "与皮肤夹角为"+Angle+"度，深度约在" + MinDepth + "寸-" + MaxDepth + "寸";
    }
}