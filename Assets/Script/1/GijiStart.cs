using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline;

public class GijiStart : MonoBehaviour
{
    //なんかSerializeFieldしないと動かん

    [SerializeField] SoundWave soundwave;
    [SerializeField] SeekBar seekbar;
    [SerializeField] Zahyou zahyou;
    [SerializeField] TimeLine timeline;


    public void GijiStartmethod(){
        soundwave.kinnkyuuwidth();
        soundwave.CreateSoundWave();
        seekbar.ReadySeekbar();
        zahyou.Readyzahyou();
        timeline.GetBPM();

    }
}
