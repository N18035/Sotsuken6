using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationScripts : MonoBehaviour
{
    [SerializeField] Text text;

    void Update()
    {
        text.text=Music.Just.ToString();
    }
}
