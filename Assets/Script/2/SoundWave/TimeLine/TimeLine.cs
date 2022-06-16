using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeLine : MonoBehaviour
{
    //73行目、3拍に未対応

    [SerializeField] Music music;
    [SerializeField] GameObject memory;
    [SerializeField] AudioSource Audio;

    [SerializeField] private int BPM;
    [SerializeField] private float bar;
    [SerializeField] private float beat;
    [SerializeField] private float apl;//audio/length

    //1倍のタイムラインの座標指定
    private float originstart = -381;
    private float originend = 386f;
    [SerializeField] private int soundwavelength=600;

    //座標計算対象
    [SerializeField] RectTransform timeline;

    //倍率を上げた時の座標
    float start;
    float end;

    //音源の小節数
    [SerializeField] private float maxbar;
    //音源の拍数
    [SerializeField] private float maxbeat;

    //メモリの数字
    GameObject[] memrory = new GameObject[1];
    //メモリを配置する座標
    float[] memorypositon = new float[1];
    //メモリのもとになるプレファブ
    [SerializeField] GameObject num;

    void Start(){
        //初期化
        start = originstart;
        end = originend;

        // MyRect myRect = new MyRect(timeline);
        // Debug.Log(timeline.GetComponentInParent<Canvas>());

        // Debug.Log(myRect.ToString());

    }

    public void GetBPM(){
        BPM = music.myTempo;

        beat =  60f / music.myTempo;

        //音源の小節数
        //1足すのは最初の0を追加分
        maxbar =(Audio.clip.length /bar)+1;
        //音源の伯数を取得
        //1足すのは最初の0を追加分
        maxbeat=(Audio.clip.length /beat)+1;

        apl = Audio.clip.length / soundwavelength;

        //動的配列の変更
        // Array.Resize(ref 配列, 変更後の要素数の上限)
        Array.Resize(ref memrory,(int)maxbeat);
        Array.Resize(ref memorypositon,(int)maxbeat);

        CreateTL_beat();
    }

    //タイムラインの生成とメモリの変更
    void CreateTL_beat(){
        //メモリの生成
        for(int j=0;j<memorypositon.Length;j++){
                memrory[j] = Instantiate(num, new Vector3(memorypositon[j], -70f, 0), Quaternion.identity);
                memrory[j].transform.SetParent(memory.transform,false);//でふぉ
        }

        //ここから数字のセットの工程
        //ビートを全部for文で見て、barの部分だけ取得
        int n=0;
        for(int i=0;i<memorypositon.Length;i++){
            if(i%4==0){//4拍の場合なので3に対応させる
                memrory[i].GetComponent<Text>().text = n.ToString();
                n++;
            }
        }

        Calc();//座標計算と移動
        Selectionsecond(0);//初期設定なので0
        Resize(0);//なんかこうしたら綺麗に表示される
    }

    //座標計算とUIの配置
    void Calc(){
        memorypositon[0]=start;
        memorypositon[memorypositon.Length-1]=end;

        //beatとbeatの間の距離。TL全体/beatの総数
        float mass = (Mathf.Abs(start)+end)/(memorypositon.Length-1);

        for(int j=1;j<memorypositon.Length;j++){
            memorypositon[j] = memorypositon[j-1] + mass;
        }

        RectTransform rt;

        //座標移動
        for(int i=0;i<memorypositon.Length;i++){
            rt = memrory[i].GetComponent<RectTransform>();
            rt.localPosition = new Vector3(memorypositon[i],0,0);
        }
    }

    //表示する秒数を選定する
    void Selectionsecond(int level){
        //一度初期化する
        for(int i=0;i<memorypositon.Length;i++){
            memrory[i].SetActive(true);
        }

        //最大値-今回のzoomレベル=どれくらい削るか
        int minus = 4 * (5 - level);

        //小節の部分以外消す&&上の数に合わせて消す
        for(int i=0;i<memorypositon.Length;i++){
            if(i%4!=0 || i%minus!=0)  memrory[i].SetActive(false);
        }
    }

    //リサイズ
    //ズレの調整は完全に数字見て微調整
    public void Resize(int level){
        // start = originstart + (-1 *originend*level)+(-3*level);
        start = originstart + (-1 *originend*level);
        end   = originend   + (originend*level)+(level*level)-(0.03f*level);
 
        Calc();
        Selectionsecond(level);
    }
}
