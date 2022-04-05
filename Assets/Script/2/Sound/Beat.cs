using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beat : MonoBehaviour
{
    [SerializeField] AudioSource Click;
    [SerializeField] AudioSource Clickupkey;
    [SerializeField] AudioSource Clap;

    [SerializeField] AudioSource one;
    [SerializeField] AudioSource two;
    [SerializeField] AudioSource three;
    [SerializeField] AudioSource four;
    [SerializeField] Dropdown dd3or4;

    public int type=0;

    bool playing=false;

    public void ONplay(){//スタートの判定
        playing=true;
    }

    //メトロノーム
    Image metro0;
    Image metro1;
    Image metro2;
    Image metro3;

    Color oncolor;
    Color offcolor;


    void Start(){
        metro0 = transform.GetChild(0).GetComponent<Image>();
        metro1 = transform.GetChild(1).GetComponent<Image>();
        metro2 = transform.GetChild(2).GetComponent<Image>();
        metro3 = transform.GetChild(3).GetComponent<Image>();

        //いろを予め用意
        oncolor = new  Color32 (255, 255, 255, 255);
        offcolor = new Color32 (100 ,100 ,100, 150);
    }

    void Update()
    {
        if(playing){
            BeatMetronome();
            BeatSound();
        }
    }


    void BeatMetronome(){
        if ( Music.IsJustChanged ){
            metro0.color = Music.Just.Beat % 4 ==0 ? oncolor:offcolor;
            metro1.color = Music.Just.Beat % 4 ==1 ? oncolor:offcolor;
            metro2.color = Music.Just.Beat % 4 ==2 ? oncolor:offcolor;
            metro3.color = Music.Just.Beat % 4 ==3 ? oncolor:offcolor;
        }
    }

    void BeatSound(){
        if(type==1){//音の変更アリ
            if(Music.IsJustChangedBeat()){
                // if(Music.Just.Beat%4==3)    Music.QuantizePlay(Click,1);//ボツ
                if(dd3or4.value==1){//3はく
                    if(Music.Just.Beat%4==2)    Clickupkey.Play();
                    else    Click.Play();
                }else if(dd3or4.value==0){//4はく
                    if(Music.Just.Beat%4==3)    Clickupkey.Play();
                    else    Click.Play();
                }
            }
        }else if(type==2){//拍手
            if(Music.IsJustChangedBeat())   Clap.Play();
        }else if(type==3){//声 //3はく未対応
            if(dd3or4.value==1){//3はく
            if(Music.Just.Beat%3==0)   two.Play();
            else if(Music.Just.Beat%3==1)   three.Play();
            else if(Music.Just.Beat%3==2)   one.Play();
            }else if(dd3or4.value==0){//4はく
            if(Music.Just.Beat%4==0)   two.Play();
            else if(Music.Just.Beat%4==1)   three.Play();
            else if(Music.Just.Beat%4==2)   four.Play();
            else if(Music.Just.Beat%4==3)   one.Play();
            }
        }else if(type==4){//無音
            //無音
        }else if(type==0){//一定
            if(Music.IsJustChangedBeat())   Click.Play();
        }
    }
}
