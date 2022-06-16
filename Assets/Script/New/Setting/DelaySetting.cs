using System;
using UnityEngine;
using UniRx;

namespace Ken.Setting{
    public class DelaySetting : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> DelaySecond => _delaysecond;
        private readonly ReactiveProperty<int> _delaysecond = new ReactiveProperty<int>();

        public IObservable<Unit> OnSelectDelay => _selectDelay;
        private Subject<Unit> _selectDelay = new Subject<Unit>();

        [SerializeField] Music _music;

        void Start(){
            Delaysetup(0);
        }

        public void Delaysetup(int delay){
            _delaysecond.Value = delay;
            _music.EntryPointSample = delay * 44100;
        }

        public void ApplyDelay(){
            _selectDelay.OnNext(Unit.Default);
        }
    }
}
