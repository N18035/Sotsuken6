using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachTOMusic : MonoBehaviour
{
    [SerializeField] Slider Delay;
    // [SerializeField] Slider SWDelay;//ダンス画面で移動予定だったもの
    [SerializeField] Slider BPMChanger;
    [SerializeField] Music music;
    [SerializeField] Beat beat;
    [SerializeField] Dropdown ddtmp;
    [SerializeField] Dropdown DDown;

    public void Beatchange3or4(){
        if(DDown.value==1){
            //3はく
            music.myBar=9;
            music.myBeat=3;
        }else if(DDown.value==0){
            //4はく
            music.myBar=16;
            music.myBeat=4;
        }else{
            Debug.LogError("ドロップダウンがおかしいよ");
        }
    }

    public void BeatTypeChange()
    {
        beat.type = ddtmp.value;
    }

    public void NextPhase(){
        BPMsetup();
        Delaysetup();
        //順番が大切。入れ替え厳禁
        music.OnValidate();
        music.OnclickAwake();
    }

    private void BPMsetup(){
        music.myTempo = (int)BPMChanger.value;
    }

    private void Delaysetup(){
        music.EntryPointSample = (int)Delay.value * 44100;
        // music.EntryPointSample = (int)SWDelay.value * 44100;
    }
}
