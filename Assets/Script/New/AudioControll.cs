using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Ken
{
    public class AudioControll : MonoBehaviour
    {
        [SerializeField] Music _music;
        [SerializeField] AudioSource _audioSource;
        [SerializeField] Ken.Main.Zahyou _zahyou;


        void Start(){
            _zahyou.SeekMusic
            .Where(_ => _audioSource.clip != null)
            .Subscribe(t => _audioSource.time = t * _audioSource.clip.length)
            .AddTo(this);
        }

        public void PlayButton(){
            //FIXME 色々残ってる
            //audioplayから直で呼べないから仮でこうしてる
            _music.Play("musicengine","");

            //これはmusicに紐づける
            // seekbar.StartPlay();

            // beat.ONplay();

            // animemc.ONplay();

            // animemc.ONPlayAnimation();
        }

        public void StopButton(){
            // 本来はmusic stopをやりたいけど、なんかおかしい
            // animemc.StopAnimation();
        }

        public void PauseButton(){
            // 本来はmusic pauseをやりたいけど、なんかおかしい
            // animemc.StopAnimation();
            Music.Pause();
        }

        public void FastForward(){
            _audioSource.pitch = _audioSource.pitch==2f ? 1f : 2f;
        }

        public void ReWind(){
            _audioSource.pitch = _audioSource.pitch==-2f ? 1f : -2f;
        }

        public void Forward10(){
            if(_audioSource.time + 10f > _audioSource.clip.length) return;
            _audioSource.time += 10f;
        }

        public void BackForward10(){
            if(_audioSource.time - 10f < 0) return;
            _audioSource.time -= 10f;
        }

        public void ReStart(){
            _audioSource.time = 0f;
        }
    }
}
