using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace Ken.Main
{
    public enum DisplayFormat{
        Beat,
        Bar,
        Second
    }

    public class TLData{
        public int MaxDisplayBar;
        public int MaxDisplaySecond;
        public float[] ScalePositionsBar;
        public float[] ScalePositionsSecond;

        public void Resize(int maxBar,int maxSecond){
            MaxDisplayBar = maxBar;
            MaxDisplaySecond = maxSecond;
            Array.Resize(ref ScalePositionsBar,MaxDisplayBar);
            Array.Resize(ref ScalePositionsSecond,MaxDisplaySecond);
        }

        public void SetPosition(float[] array,float[] arraySecond){
            Array.Copy(array,ScalePositionsBar,array.Length);
            Array.Copy(arraySecond,ScalePositionsSecond,arraySecond.Length);
        }

    }

    public class TimeLine : MonoBehaviour
    {
        //TODO小節単位だから秒とか動的に変更可能にする

        [SerializeField] Music music;
        [SerializeField] AudioSource Audio;
        [SerializeField] ZoomController _zoomController;
        [SerializeField] Content _contentZoom;
        [SerializeField] TimeLineView _timeLineView;

        TLData sendData;


        void Start(){
            _zoomController.ZoomLevel
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ => Resize())
            .AddTo(this);
        }

        public void ReadyTimeLine(){
            sendData = new TLData();
            ResizeArray();
            CalcPosition();
            _timeLineView.ReadyTimeLineView(sendData);
        }


        //リサイズ
        //ズレの調整は完全に数字見て微調整
        private void Resize(){
            //FIXMETimeLine用にcontentのstartをちょっと編集する必要はありそう
            
            sendData = new TLData();
            //FIXME この２つが無いと正常に動作しない生焼けオブジェクトになってる
            ResizeArray();
            CalcPosition();


            //見た目
            _timeLineView.ResizeTimeLineView(sendData);
        }


        void ResizeArray(){
            int maxBar = GetMaxBar();
            int maxSecond = GetMaxSecond();
            sendData.Resize(maxBar,maxSecond);

            //displayScaleに合わせて返す値を変更するメソッド
            //FIXME今は小節単位だから、全てのbeat単位にする
            int GetMaxBar(){
                //「60(1分)÷150(テンポ)で４分音符一拍分の長さ」(s)
                float oneBeat = 60f / music.myTempo;
                //「×4（一拍数）で1小節分の長さ」(s)
                float oneBar = oneBeat * music.myBeat;
                //「×32（小節数）で曲の長さ」これを求めたい
                //oneBar * s = Audio.clip.length こうなる
                int s;


                s = (int)(Audio.clip.length / oneBar);
                //0を配列に加えるために+1
                s++;

                return s;
            }

            ////とりあえず再生時間(秒数)を返す。
            int GetMaxSecond(){
                //FIXME intで切り捨てる分の誤差は発生する
                return (int)Audio.clip.length;
            }

        }

        //座標計算
        void CalcPosition(){
            //FIXME 抽象化出来る

            //キャッシュ
            var zoomLevel = _zoomController.ZoomLevel.Value -1;

            //スタート位置＋拡大は厳密には右に拡張してるからEnd*zoomLevelで求められるに、マイナスをする
            float left = _contentZoom._originStart + (-1 * zoomLevel * _contentZoom._originalEnd);
            float right = _contentZoom._originalEnd + (_contentZoom._originalEnd * zoomLevel);

            //Bar版
            float[] scalePositions = sendData.ScalePositionsBar;

            scalePositions[0]=left;
            scalePositions[scalePositions.Length-1]=right;

            //間の距離。TL全体/目盛りの総数
            // float between = (Mathf.Abs(_contentZoom.NowStart)+_contentZoom.NowEnd)/(scalePositions.Length-1);
            float between = (Mathf.Abs(left)+right)/(scalePositions.Length-1);

            //左から順番に入れていく
            for(int j=1;j<scalePositions.Length;j++){
                scalePositions[j] = scalePositions[j-1] + between;
            }


            #region  秒数版を作成
            float[] scalePositions2 = sendData.ScalePositionsSecond;

            scalePositions2[0]=left;
            scalePositions2[scalePositions2.Length-1]=right;

            between = (Mathf.Abs(left)+right)/(scalePositions2.Length-1);

            //左から順番に入れていく
            for(int j=1;j<scalePositions2.Length;j++){
                scalePositions2[j] = scalePositions2[j-1] + between;
            }
            #endregion

            sendData.SetPosition(scalePositions,scalePositions2);
        }
    }
}
