using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyRect
{
    private RectTransform transform;

    public Vector3 Positon{
        get{
            return transform.position;
        }
    }

    public Vector3 End{
        get{
            return this.Positon + Vector3.right * this.transform.sizeDelta.x / 2.0f;
        }
    }

    public Vector3 Start{
        get{
            return this.Positon + Vector3.left * this.transform.sizeDelta.x / 2.0f;
        }
    }

    public MyRect(RectTransform transform)
    {
        this.transform = transform;
    }
    public override string ToString()
    {
        return Start + "," + End;
    }
}
