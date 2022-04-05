using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{

    [SerializeField]  GameObject content;
    RectTransform rectTransform;

    [SerializeField] TimeLine timeline;
    [SerializeField] Zahyou zahyou;

    [SerializeField] Text magnification;


    int zoomlevel=0;//0がデフォ。1でx倍===2でx倍====3でx倍
    float zoomlength = 1200;//0がデフォで、長さは600つまり、1200は2倍ズーム300は1.5倍
    [SerializeField] private int soundwavelength=600;
    [SerializeField] private int kariheight=50;//多分音声波形の縦に関する部分だと思う

    public void Start(){//初期設定
        rectTransform = content.GetComponent<RectTransform>();
    }

    public void Resize_Zoom(){
        if(zoomlevel<4){
            zoomlevel++;
            resize();
        }
    }

    public void Resize_Shrink(){
        if(zoomlevel>0){
            zoomlevel--;
            resize();
        }
    }

    void resize(){
        //倍率表示のUI
        magnification.text=(zoomlevel+1).ToString();

        //スライダーの変更
        zoomlength = soundwavelength+soundwavelength*zoomlevel;
        rectTransform.sizeDelta = new Vector2(zoomlength, kariheight);

        //他のパートに変更を要求する
        timeline.Resize(zoomlevel);
        zahyou.Resize(zoomlevel);
    }
    
}
