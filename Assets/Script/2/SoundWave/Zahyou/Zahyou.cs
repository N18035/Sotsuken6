using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zahyou : MonoBehaviour
{
    //73行目、スライダーを動かす時に不具合。UniRxで対応

    [SerializeField] AudioSource ac;
    [SerializeField] Animationtime_mc animationMC;
    //音声波形をズラすスライダー
    [SerializeField] Scrollbar vscroll;


    //単位はUIのRect座標
    [SerializeField] private float originstart=-210;
    [SerializeField] private float originalend=393;
    [SerializeField] private int soundwavelength=600;

    //zahyouの誤差
    [SerializeField] private float gosa=0f;

    float start;
    float end;
    float now;

    //曲の長さ(秒)
    float musiclong;

    int zoomlevel;

    public void Readyzahyou()
    {
        start = originstart;
        end = originalend;

        //AudioClipの長さを取得
        musiclong = ac.clip.length;
    }

    //zahyouはButtonの関数なのでOnClickにて使用
    public void CalcNowMusicTime(Vector3 mousePos){
        //マウス座標の誤差修正
        mousePos.x += gosa;
        
        //(マウスの場所)/(全体)) * 100
        //音楽の何％か
        now = ((mousePos.x - start) / (end -start));
        Debug.Log(now+","+musiclong);
        now = now * musiclong;

        //音楽を変更
        ac.time = now;

        //ダンスも変更----------------
        //このまま実行するとシーク前にメソッドを読んでしまうのでコルーチンを使用
        StartCoroutine("UrgentAnimationChangeCol");

    }

    IEnumerator UrgentAnimationChangeCol(){//1Fでだいたいあってる
        //1フレーム停止
        //ハードによるけど基本60fpsだと0.016s
        yield return null;

        animationMC.UrgentChangeAnimation();
    }

    //Zoomにアタッチ
    public void Resize(int level){ 
        zoomlevel = level;

        if(level==1){//1倍のときに戻す。それ以外の倍率は別で管理
            start = originstart;
            end=originalend;
        }else if(vscroll.value<=0){//スクロールバーを移動させない(vs.v=0)のとき。初手zoomのとき 
            //Changeに合わせて変わるようにUniRxで修正
            start=originstart;
            end = originalend+soundwavelength*zoomlevel;
        }else{//スクロールバーを移動させた場合
            start = originstart + (-soundwavelength*zoomlevel*vscroll.value);
            end = (originalend+soundwavelength*zoomlevel) + (-soundwavelength*zoomlevel*vscroll.value);
        }
    }

    
    //スライダーのvaluechangeにアタッチ
    public void Changed(){
        //倍率とスライダーに合わせてstartとendを変更してクリックの場所を特定出来るようにする
        start = originstart + (-soundwavelength*zoomlevel*vscroll.value);
        end = (originalend+soundwavelength*zoomlevel) + (-soundwavelength*zoomlevel*vscroll.value);
    }
}
