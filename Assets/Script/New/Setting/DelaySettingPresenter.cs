using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ken.Setting{
    public class DelaySettingPresenter : MonoBehaviour
    {
        [SerializeField] Slider _delaySlider;
        [SerializeField] DelaySetting _delaySetting;
        [SerializeField] AudioSource _musicEngine;
        [SerializeField] AudioImport _audioImport; 

        void Start(){
            _audioImport.OnSelectMusic
            .Subscribe(_ => _delaySlider.maxValue = _musicEngine.clip.length)
            .AddTo(this);
        }

        public void ChangeDelayforSlider(){
            _delaySetting.Delaysetup((int)_delaySlider.value);
        }
    }
}
