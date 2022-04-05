using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timeline{
    public class Controll : MonoBehaviour
    {
        TimeLine _timeline;

        void Start(){
            _timeline = GetComponent<TimeLine>();
        }

        public void CreateTimeline(){
            GIJIStart();//新しい方
        }

        public void TL_resize(int level){
            Resize(level);//新しい方
        }

        

        void GIJIStart(){
            _timeline.GetBPM();
        }
        void Resize(int level){
            _timeline.Resize(level);
        }


    }
}
