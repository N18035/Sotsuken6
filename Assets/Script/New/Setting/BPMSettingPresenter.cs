using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ken.Setting
{
    public class BPMSettingPresenter : MonoBehaviour
    {
        [SerializeField] BPMSetting _bpmSetting;
        [SerializeField] Slider _slider;
        [SerializeField] TextViewer _textViewer;

        void Start(){
            _slider.maxValue = _bpmSetting.MaxBPM;
        }
        
        public void ChangeBPMforButton(int slidervalue){
            int value = _bpmSetting.BPM.Value + slidervalue;
            _bpmSetting.ChangeBPM(value);
        }

        public void ChangeBPMforSlider(){
            _bpmSetting.ChangeBPM((int)_slider.value);
        }
    }
}
