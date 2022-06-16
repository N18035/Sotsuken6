using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ken.Main
{
    public class SeekBar : MonoBehaviour
    {
        //スライダーの単位は%

        //スライダー本体
        [SerializeField] Slider _slider;
        //使用楽曲
        [SerializeField] AudioSource _musicEngine;

        //曲の長さ(秒)
        float _musicLength;

        //疑似Startで使用。準備
        public void ReadySeekbar(){
            //スライダーの最大値の設定
            //スライダーの単位は%なので、最大値は100になる
            _slider.maxValue = 100f;

            //AudioClipの長さを取得
            _musicLength = _musicEngine.clip.length;
        }

        void Update()
        {
            //音楽の進行に合わせてシークバーを動かす
            // 今の再生時間 / 総再生時間 * 100 = 今全体の何％にいるか
            if(_musicEngine.isPlaying)     _slider.value = _musicEngine.time / _musicLength * 100;
        }
    }
}

