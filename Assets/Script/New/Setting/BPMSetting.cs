using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Ken.Setting
{
    public class BPMSetting : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> BPM => _bpm;
        private readonly ReactiveProperty<int> _bpm = new ReactiveProperty<int>();

        public IObservable<Unit> OnSelectBPM => _selectBPM;
        private Subject<Unit> _selectBPM = new Subject<Unit>();

        [SerializeField] Music _music;

        //BPMの最大値
        public int MaxBPM=250;
        
        void Start(){
            _music.myTempo = 120;
            _bpm.Value = 120;
        }

        //BPM変更
        public void ChangeBPM(int value){
            _bpm.Value = Mathf.Clamp(value,0,MaxBPM);
        }

        //BPM決定
        public void ApplyBPM(){
            _music.myTempo = _bpm.Value;
            _selectBPM.OnNext(Unit.Default);
        }
    }
}