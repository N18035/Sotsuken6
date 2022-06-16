using UnityEngine;
using UnityEngine.UI;

public class SeekBar : MonoBehaviour
{
    //シークバーを動かすスクリプト
    //Audio Clipにのみ依存
    //スライダーの単位は%

    //スライダー本体
    [SerializeField] Slider sSlider;
    //使用楽曲
    [SerializeField] AudioSource ac;


    //曲の長さ(秒)
    float musiclong;
    //再生中
    bool playing=false;

    #region 
    //外部向けの準備メソッド

    //paly判定をonにするだ。再生ボタンに紐付け
    public void StartPlay(){
        playing = true;
    }

    //疑似Startで使用。準備
    public void ReadySeekbar(){
        //スライダーの最大値の設定
        //スライダーの単位は%なので、最大値は100になる
        sSlider.maxValue = 100f;

        //AudioClipの長さを取得
        musiclong = ac.clip.length;
    }

    #endregion

    void Update()
    {
        //音楽の進行に合わせてシークバーを動かす
        // 今の再生時間 / 総再生時間 * 100 = 今全体の何％にいるか
        if(ac.isPlaying)     sSlider.value = ac.time / musiclong * 100;
    }
 
}