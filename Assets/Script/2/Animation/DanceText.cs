using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceText : MonoBehaviour
{
    [SerializeField]    Text dancetext;

    public void UIChange(string dance){
        dancetext.text = dance;
    }
}
