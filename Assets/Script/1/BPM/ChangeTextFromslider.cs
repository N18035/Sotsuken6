using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextFromslider : MonoBehaviour
{
    [SerializeField] Slider BPMslider;
    [SerializeField] Text BPMtext;

    //オンドラッグで使用を想定
    //Change text from slider
    public void Do(){
        //変更
        BPMtext.text = BPMslider.value.ToString("F0");
    }
}
