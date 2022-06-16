using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Ken.Setting;
using Ken.Main;

namespace Ken
{
    public class TextViewer : MonoBehaviour
    {
        [SerializeField] Text _musicName;
        [SerializeField] Text _bpm;
        [SerializeField] Text _beatType;
        [SerializeField] Text _beatSound;
        [SerializeField] Text _delay;

        [SerializeField] Text _musicalTime;
        [SerializeField] Text _playingTime;
        [SerializeField] Text _zoomLevel;

        [SerializeField] AudioImport _audioImport;
        [SerializeField] BPMSetting _bpmSetting;
        [SerializeField] BeatTypeSetting _beatTypeSetting;
        [SerializeField] BeatSoundSetting _beatSoundSetting;
        [SerializeField] DelaySetting _delaySetting;
        [SerializeField] AudioSource _musicEngine;
        [SerializeField] ZoomController _zoomController;

        void Start(){
            _audioImport.ClipName
            .Subscribe(t => _musicName.text = t)
            .AddTo(this);

            //重すぎたので無し
            _bpmSetting.BPM
            .Subscribe(t => _bpm.text = t.ToString())
            .AddTo(this);

            _beatTypeSetting.BeatType
            .Subscribe(t => _beatType.text = t.ToString())
            .AddTo(this);

            _beatSoundSetting.BeatSound
            .Subscribe(t => _beatSound.text = t)
            .AddTo(this);

            _delaySetting.DelaySecond
            .Subscribe(t => _delay.text = t.ToString())
            .AddTo(this);

            _zoomController.ZoomLevel
            .Subscribe(t => _zoomLevel.text = t.ToString())
            .AddTo(this);
        }

        void Update()
        {
            if(_musicEngine.isPlaying){
                _musicalTime.text=Music.Just.ToString();
                _playingTime.text=_musicEngine.time.ToString();
            }
        }

    }
}
