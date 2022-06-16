using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using UnityEngine.Profiling;
using System.Linq;

//dancetextの変更をanimationを購読するようにしたいUniRx導入後

public class Animationtime_mc : MonoBehaviour
{

	[SerializeField] AnimationClip[] clips = null;
	[SerializeField] float transitionTime = 0.3f;

    [SerializeField] DanceText dancetext;

	public int[] Animationtime = new int[5];//music.csのタイミング


	PlayableGraph graph;
	AnimationMixerPlayable mixer;
	AnimationClipPlayable prePlayable, currentPlayable;

	AnimationClipPlayable playableClip;
	public float ATime;


	//BPMとか色々もらいます。
	[SerializeField] Music music;

    //コルーチンのi代わり
    [SerializeField]int Nextanimation=0;//次に再生する

	bool playing=false;




    public void ONplay(){//スタートの判定
        playing=true;
    }

	void Awake ()
	{
		graph = PlayableGraph.Create ();
	}

	void Start ()
	{
		// AnimationClipをMixerに登録
		currentPlayable = AnimationClipPlayable.Create (graph, clips [0]);
		mixer = AnimationMixerPlayable.Create (graph, 2, true);
		mixer.ConnectInput (0, currentPlayable, 0);
		mixer.SetInputWeight (0, 1);

		// outputにmixerとanimatorを登録して、再生
		var output = AnimationPlayableOutput.Create (graph, "output", GetComponent<Animator> ());
		output.SetSourcePlayable (mixer);
	}

    public void ONPlayAnimation(){
        graph.Play ();
		Nextanimation=1;
    }

    void Update(){
		if(playing){
			if(Music.IsNearChangedAt(Animationtime[Nextanimation]-1,3,0)){//ここの3は伯によって変わる。
        	    ChangeAnimation();
        	    dancetext.UIChange(clips[Nextanimation].ToString());
        	}else if(Music.IsNearChangedAt(Animationtime[Nextanimation]-1,3,0)){//ここの3は伯によって変わる。
        	    ChangeAnimation();
        	    dancetext.UIChange(clips[Nextanimation].ToString());
			}
		}
    }

    void ChangeAnimation(){
        // ClipPlayableを上書きは出来ない為、一旦mixerの1番と2番を一旦アンロード
        graph.Disconnect (mixer, 0);
        graph.Disconnect (mixer, 1);

        // 古いアニメーションを破棄し、次に再生するアニメーションを登録する
        if( prePlayable.IsValid())
            prePlayable.Destroy ();
        prePlayable = currentPlayable;
		//クリップをラップする
        currentPlayable = AnimationClipPlayable.Create (graph, clips [Nextanimation]);
		
        mixer.ConnectInput (1, prePlayable, 0);
        mixer.ConnectInput (0, currentPlayable, 0);

		StartCoroutine(AnimationTL());

        //旧for文の最後
        Nextanimation++;
    }

	IEnumerator AnimationTL(){
		// 指定時間でアニメーションをブレンド
		// Debug.Log("ブレンド開始");
		float waitTime = Time.timeSinceLevelLoad + transitionTime; 
		yield return new WaitWhile (() => {
			var diff = waitTime - Time.timeSinceLevelLoad;
			if (diff <= 0) {
				mixer.SetInputWeight (1, 0);
				mixer.SetInputWeight (0, 1);
				return false;
			} else {
				var rate = Mathf.Clamp01 (diff / transitionTime);
				mixer.SetInputWeight (1, rate);
				mixer.SetInputWeight (0, 1 - rate);
				return true;
			}
		});

		//再生開始
		graph.Play ();
	}



	public void UrgentChangeAnimation(){//緊急変更
		// Debug.Log(Music.Just+"JUST");
        // ClipPlayableを上書きは出来ない為、一旦mixerの1番と2番を一旦アンロード
        graph.Disconnect (mixer, 0);
        graph.Disconnect (mixer, 1);

		//現状はtargetKARIを変更すれば動く
		//どちらにせよ可読性死んでるから分ける。

		// 差し替えるAnimation clipが何かを特定する。
		//今のbarを入手
		int targetbar = (int)Music.MusicalTimeBar;
		//じっさいに持ってくるAnimation clipのインデックス
		int targetAnimationclipIndex=-1;

		for(int i=1;i<Animationtime.Length;i++){

			//今の時間に合わせてアニメーションクリップを調整
			if(targetbar < Animationtime[i]){
				//コンストラクタだからここで定義
				Timing timing = new Timing(Animationtime[i]-1,3,0);
				//musicfromメソッドが現時点とtimingの差分で遅れてると+になる
				//具体的には9(target)のとき 10以下なのでtimingを生成し、9以上で+になるから一個先の変更後をアニメーションクリップとして登録。
				if(0 <= Music.MusicalTimeFrom(timing)){
					targetAnimationclipIndex =i;
					break;
				}else{//上記条件でマイナスのとき
					targetAnimationclipIndex = i-1;//もし、移動先のbarが配列よりも小さければ、配列
					break;
				}
			}
		}

        // 古いアニメーションを破棄し、次に再生するアニメーションを登録する
        if( prePlayable.IsValid())
            prePlayable.Destroy ();


		//クリップをラップする
		prePlayable = currentPlayable;

		//範囲外なら矯正的にReadyに
		if (targetAnimationclipIndex >=7)	targetAnimationclipIndex = 0;
		
		currentPlayable = AnimationClipPlayable.Create (graph, clips [targetAnimationclipIndex]);

		//ミックスする
		mixer.ConnectInput (1, prePlayable, 0);
		mixer.ConnectInput (0, currentPlayable, 0);

		mixer.SetInputWeight (1, 0);
		mixer.SetInputWeight (0, 1);

		//今回変更したクリップ+1が次のクリップになる
		Nextanimation=targetAnimationclipIndex+1;

		//ここからAnimationclipのズレの計算--------------------

		//時間（秒）＝60÷テンポ(BPM)×拍子(とりあえず4で固定)×小節数
		float bartime = (60f /music.myTempo)*4f*(float)Animationtime[targetAnimationclipIndex];//AnimationClipの配列とAnimationtimeの配列は連動しているからこれで問題ないはず

		//今の再生時間(s) - bar?のときの秒数
		ATime = Music.AudioTimeSec - bartime;

		//手動で制御できるはず
		currentPlayable.SetTime(ATime);
		prePlayable.SetTime(ATime);

    }

	public void StopAnimation(){
		//再生停止
		graph.Stop ();
	}
}
