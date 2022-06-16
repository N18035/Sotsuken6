using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Ken.Main
{
    public class GetMousePosition : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<Vector3> MousePostion => _mousePos;
        private readonly ReactiveProperty<Vector3> _mousePos = new ReactiveProperty<Vector3>();

        public void OnClickbutton(){
            //マウスクリックはスクリーン座標
            var mousePos = Input.mousePosition;
            _mousePos.Value = mousePos;
        }
    }
}
