using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Ken.Setting
{

    public class BeatSoundSetting : MonoBehaviour{
        [SerializeField] BeatSound _beatSound;
        [SerializeField] Dropdown _dropdown;

        public IObservable<Unit> OnSelectBeatSound => _selectBeatSound;
        private Subject<Unit> _selectBeatSound = new Subject<Unit>();

        public IReadOnlyReactiveProperty<string> BeatSound => _beatSoundNum;
        private ReactiveProperty<string> _beatSoundNum = new ReactiveProperty<string>("電子音");

        Dictionary<int, string> ClipNameDictionary = new Dictionary<int, string>()
        {
            {0, "電子音"},
            {1, "拍手"},
            {2, "音無し"},
        };

        //ドロップダウンで使用中
        public void BeatSoundChange()
        {    
            _beatSound.SetBeatSound(_dropdown.value);
            _beatSoundNum.Value = ClipNameDictionary[_dropdown.value];
            _selectBeatSound.OnNext(Unit.Default);
        }
    }
}
