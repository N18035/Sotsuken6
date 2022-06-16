using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Ken.Main{

    public class ZoomController : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> ZoomLevel => _zoomLevel;
        private readonly ReactiveProperty<int> _zoomLevel = new ReactiveProperty<int>(1);

        #region  外部公開

        public void AddZoomLevel(){
            if(_zoomLevel.Value >= 5) return;
            _zoomLevel.Value ++;
        }

        public void SubZoomLevel(){
            if(_zoomLevel.Value == 1) return;
            _zoomLevel.Value --;
        }
        #endregion
    }
}