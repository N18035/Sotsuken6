using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePos : MonoBehaviour
{
    [SerializeField] RectTransform canvasRect;

    [SerializeField] Zahyou zahyou;

    public void OnClickbutton(){
        // //マウスのスクリーン座標をUIのRect座標に変換する

        //  // クリックしたスクリーン座標
        // var mousePos = Input.mousePosition;

        //  // Canvasにセットされているカメラを取得
        // var graphic = GetComponent<Graphic>();
        // var camera = graphic.canvas.worldCamera;

        // // Overlayの場合はScreenPointToLocalPointInRectangleにnullを渡さないといけないので書き換える
        // if (graphic.canvas.renderMode == RenderMode.ScreenSpaceOverlay) {
        //     camera = null;
        // }

        // // クリック位置に対応するRectTransformのlocalPositionを計算する
        // var localPoint = Vector2.zero;
        // //指定されたスクリーン座標を指定されたRectTransformオブジェクトのローカル座標に変換するメソッドです
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(graphic.rectTransform, mousePos, camera, out localPoint);

        // Debug.Log("変換後"+localPoint);


        //-------------------------------------
        //バージョン2
        //マウスクリックはスクリーン座標
        var mousePos = Input.mousePosition;
        //キャンバスと画面サイズの倍率を取る
        var magnification = canvasRect.sizeDelta.x / Screen.width;

        //スクリーン座標は画面左はしが0,0でCanvasは中心が0,0なのでこの差を解消する
        // 倍率をかけてキャンバス座標にして、起点を揃えた部分がこれ。
        mousePos.x = mousePos.x * magnification - canvasRect.sizeDelta.x / 2;
        mousePos.y = mousePos.y * magnification - canvasRect.sizeDelta.y / 2;
        mousePos.z = transform.localPosition.z;
        //この状態でmousePosは変換されてる
        Debug.Log(mousePos);

        //渡す。
        zahyou.CalcNowMusicTime(mousePos);

    }
}
