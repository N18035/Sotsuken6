using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextFromslider2 : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text text;

    public void Do(){
        //変更
        text.text = slider.value.ToString("F2");
        
    }
}
