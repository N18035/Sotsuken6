using UnityEngine;
using UniRx;

namespace Ken.Main
{
    public class Zahyou : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<float> SeekMusic => _seekMusic;
        private readonly ReactiveProperty<float> _seekMusic = new ReactiveProperty<float>();

        //外部
        [SerializeField] Animationtime_mc animationMC;
        [SerializeField] RectTransform canvasRect;
        [SerializeField] GetMousePosition _getMousePosition;
        [SerializeField] Content _contentZoom;



        void Start(){
            _getMousePosition.MousePostion
            .Subscribe(t => CalcNowMusicTime(t))
            .AddTo(this);
        }


        private void CalcNowMusicTime(Vector3 mousePos){
            //引数はスクリーン座標

            //キャンバスと画面サイズの倍率を取る
            var magnification = canvasRect.sizeDelta.x / Screen.width;

            //スクリーン座標は画面左はしが0,0でCanvasは中心が0,0なのでこの差を解消する
            // 倍率をかけてキャンバス座標にして、起点を揃えた部分がこれ。
            mousePos.x = mousePos.x * magnification - canvasRect.sizeDelta.x / 2;
            mousePos.y = mousePos.y * magnification - canvasRect.sizeDelta.y / 2;
            mousePos.z = transform.localPosition.z;

            
            //(マウスの場所)/(全体)) = 楽曲のパーセント
            var now = ((mousePos.x - _contentZoom.NowStart) / (_contentZoom.NowEnd - _contentZoom.NowStart));

            //音楽を変更
            _seekMusic.Value = now;

            //ダンスも変更----------------
            //このまま実行するとシーク前にメソッドを読んでしまうので1フレーム待つ
            // StartCoroutine("UrgentAnimationChangeCol");
        }
    }
}
