using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeLineView : MonoBehaviour
{
    [SerializeField] Ken.Main.ZoomController _zoomController;
    // [SerializeField] TimeLine _timeline;
    [SerializeField] GameObject TLImage;
    [SerializeField] GameObject TLImage2nd;

    //メモリのもとになるプレファブ
    [SerializeField] GameObject num;

    public GameObject[] Memory;
    public GameObject[] Memory2nd;

    /// <summary>
    /// 初期設定
    /// </summary>
    public void ReadyTimeLineView(Ken.Main.TLData data){
        //子要素を破壊
        foreach(Transform child in TLImage.transform){
            Destroy(child.gameObject);
        }

        //秒も破壊
        foreach(Transform child in TLImage2nd.transform){
            Destroy(child.gameObject);
        }

        Array.Resize(ref Memory,data.MaxDisplayBar);
        Array.Resize(ref Memory2nd,data.MaxDisplaySecond);

        //目盛りの生成(初回しかやらない)
        for(int j=0;j<data.ScalePositionsBar.Length;j++){
            Memory[j] = Instantiate(num, new Vector3(data.ScalePositionsBar[j], -2f, 0), Quaternion.identity);
            Memory[j].transform.SetParent(TLImage.transform,false);//でふぉ
        }

        for(int j=0;j<data.ScalePositionsSecond.Length;j++){
            Memory2nd[j] = Instantiate(num, new Vector3(data.ScalePositionsSecond[j], -2f, 0), Quaternion.identity);
            Memory2nd[j].transform.SetParent(TLImage2nd.transform,false);//でふぉ
        }

        SetMoji();
        SelectMoji();
    }

    /// <summary>
    /// 位置変更。Resize
    /// </summary>
    public void ResizeTimeLineView(Ken.Main.TLData data){
        for(int i=0;i<Memory.Length;i++){
            Memory[i].GetComponent<RectTransform>().localPosition = new Vector3(data.ScalePositionsBar[i], -2f,0);
        }

        for(int i=0;i<Memory2nd.Length;i++){
            Memory2nd[i].GetComponent<RectTransform>().localPosition = new Vector3(data.ScalePositionsSecond[i], -2f,0);
        }
    }

    /// <summary>
    /// 目盛りのtextを編集
    /// </summary>
    void SetMoji(){
        int n=0;
        for(int i=0;i<Memory.Length;i++){
            Memory[i].GetComponent<Text>().text = n.ToString();
            Memory2nd[i].GetComponent<Text>().text = n.ToString();
            n++;
        }

        n=0;
        for(int i=0;i<Memory2nd.Length;i++){
            Memory2nd[i].GetComponent<Text>().text = n.ToString();
            n++;
        }
    }

    /// <summary>
    /// 目盛りの表示する、しないを変更
    /// </summary>
    void SelectMoji(){
        //初期化
        for(int i=0;i<Memory.Length;i++){
            Memory[i].SetActive(false);
        }

        for(int i=0;i<Memory2nd.Length;i++){
            Memory2nd[i].SetActive(false);
        }

        //最大値-今回のzoomレベル=どれくらい削るか
        // int kezuru = 4 * (5 - _zoomController.ZoomLevel.Value);

        //小節の部分以外消す&&上の数に合わせて消す
        // for(int i=0;i<Memory.Length;i++){
        //     if(i%4!=0 || i%kezuru!=0)  Memory[i].SetActive(false);
        // }

        for(int i=0;i<Memory.Length;i++){
            if(i % 5 == 0)  Memory[i].SetActive(true);
        }

        for(int i=0;i<Memory2nd.Length;i++){
            if(i % 5 == 0)  Memory2nd[i].SetActive(true);
        }
    }
}
