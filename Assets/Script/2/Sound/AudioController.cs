using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] Music music;
    [SerializeField] SeekBar seekbar;
    [SerializeField] Beat beat;
    [SerializeField] Animationtime_mc animemc;

    public void PlayButton(){
        //audioplayから直で呼べないから仮でこうしてる
        music.Play("musicengine","");

        seekbar.StartPlay();

        beat.ONplay();

        animemc.ONplay();

        animemc.ONPlayAnimation();
    }

    public void StopButton(){
        // 本来はmusic stopをやりたいけど、なんかおかしい
        animemc.StopAnimation();
    }

    public void PauseButton(){
        // 本来はmusic pauseをやりたいけど、なんかおかしい
        animemc.StopAnimation();

    }
}
