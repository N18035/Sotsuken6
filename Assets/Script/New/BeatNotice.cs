using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ken{
    public class BeatNotice : MonoBehaviour
    {
        [SerializeField] AudioSource _musicEngine;
        [SerializeField] Ken.Main.Zahyou _zahyou;


        public Image[] _beatNoticeImage = new Image[8];

        Color _onColor = new  Color32 (255, 255, 255, 255);
        Color _offColor = new Color32 (100 ,100 ,100, 150);

        void Start(){
            _zahyou.SeekMusic
            .Subscribe(_ => {
                for(int i=0;i<_beatNoticeImage.Length;i++){
                    _beatNoticeImage[i].color =_offColor;
                }
            })
            .AddTo(this);
        }
        void Update()
        {
            if(_musicEngine.isPlaying){
                PlayBeatNotice();
            }
        }

        void PlayBeatNotice(){
                if(Music.Just.Beat % 4 == 0){
                    _beatNoticeImage[0].color = Music.GetUnit == 0 ? _onColor:_offColor;
                    _beatNoticeImage[1].color = Music.GetUnit == 2 ? _onColor:_offColor;
                }else if(Music.Just.Beat % 4 == 1){
                    _beatNoticeImage[2].color = Music.GetUnit == 0 ? _onColor:_offColor;
                    _beatNoticeImage[3].color = Music.GetUnit == 2 ? _onColor:_offColor;
                }else if(Music.Just.Beat % 4 == 2){
                    _beatNoticeImage[4].color = Music.GetUnit == 0 ? _onColor:_offColor;
                    _beatNoticeImage[5].color = Music.GetUnit == 2 ? _onColor:_offColor;
                }else if(Music.Just.Beat % 4 == 3){
                    _beatNoticeImage[6].color = Music.GetUnit == 0 ? _onColor:_offColor;
                    _beatNoticeImage[7].color = Music.GetUnit == 2 ? _onColor:_offColor;
                }
        }
    }
}

