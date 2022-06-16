using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Ken.Setting;

namespace Ken{
    public class GIJIStart : MonoBehaviour
    {
        [SerializeField] AudioImport _audioImport;
        [SerializeField] BPMSetting _bpmSetting;
        [SerializeField] BeatTypeSetting _beatTypeSetting;
        [SerializeField] BeatSoundSetting _beatSoundSetting;
        [SerializeField] DelaySetting _delaySetting;
        [SerializeField] Music _music;
        [SerializeField] AudioSource _audioSource;

        [SerializeField] Ken.Main.SoundWave _soundWave;
        [SerializeField] Ken.Main.SeekBar _seekBar;
        [SerializeField] Ken.Main.TimeLine _timeLine;
        [SerializeField] Ken.Main.Content _contentZoom;
        void Start()
        {
            _audioImport.OnSelectMusic
            .Subscribe(_ => Onvalidate())
            .AddTo(this);

            _bpmSetting.OnSelectBPM
            .Subscribe(_ => Onvalidate())
            .AddTo(this);

            _beatTypeSetting.OnSelectBeatType
            .Subscribe(_ => Onvalidate())
            .AddTo(this);

            _beatSoundSetting.OnSelectBeatSound
            .Subscribe(_ => Onvalidate())
            .AddTo(this);

            _delaySetting.OnSelectDelay
            .Subscribe(_ => Onvalidate())
            .AddTo(this);
        }

        private void Onvalidate(){
            //delayをセットアップする
            _music.OnValidate();
            _music.OnclickAwake();

            _soundWave.CreateSoundWave();
            _seekBar.ReadySeekbar();
            _contentZoom.ReadyStartAndEnd();
            _timeLine.ReadyTimeLine();
        }
    }
}
