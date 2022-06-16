﻿using System;
using UnityEngine;


namespace UniHumanoid
{
    public class HandPoseModifier : IPoseModifier
    {
        public class HandPose
        {
            [Obsolete("Use ThumbStretch")]
            public float ThumbStrech { get {  return ThumbStretch; } set { ThumbStretch = value; } }
            public float ThumbStretch;
            public float ThumbSpread;

            [Obsolete("Use IndexStretch")]
            public float IndexStrech { get { return IndexStretch; } set { IndexStretch = value; } }
            public float IndexStretch;
            public float IndexSpread;

            [Obsolete("Use MiddleStretch")]
            public float MiddleStrech { get { return MiddleStretch; } set { MiddleStretch = value; } }
            public float MiddleStretch;
            public float MiddleSpread;

            [Obsolete("Use RingStretch")]
            public float RingStrech { get { return RingStretch; } set { RingStretch = value; } }
            public float RingStretch;
            public float RingSpread;

            [Obsolete("Use LittleStretch")]
            public float LittleStrech { get { return LittleStretch; } set { LittleStretch = value; } }
            public float LittleStretch;
            public float LittleSpread;
        }
        public HandPose LeftHandPose
        {
            get;
            set;
        }
        public HandPose RightHandPose
        {
            get;
            set;
        }

        int LeftThumb1Stretched;
        int LeftThumb2Stretched;
        int LeftThumb3Stretched;
        int LeftIndex1Stretched;
        int LeftIndex2Stretched;
        int LeftIndex3Stretched;
        int LeftMiddle1Stretched;
        int LeftMiddle2Stretched;
        int LeftMiddle3Stretched;
        int LeftRing1Stretched;
        int LeftRing2Stretched;
        int LeftRing3Stretched;
        int LeftLittle1Stretched;
        int LeftLittle2Stretched;
        int LeftLittle3Stretched;
        int LeftThumbSpread;
        int LeftIndexSpread;
        int LeftMiddleSpread;
        int LeftRingSpread;
        int LeftLittleSpread;

        int RightThumb1Stretched;
        int RightThumb2Stretched;
        int RightThumb3Stretched;
        int RightIndex1Stretched;
        int RightIndex2Stretched;
        int RightIndex3Stretched;
        int RightMiddle1Stretched;
        int RightMiddle2Stretched;
        int RightMiddle3Stretched;
        int RightRing1Stretched;
        int RightRing2Stretched;
        int RightRing3Stretched;
        int RightLittle1Stretched;
        int RightLittle2Stretched;
        int RightLittle3Stretched;
        int RightThumbSpread;
        int RightIndexSpread;
        int RightMiddleSpread;
        int RightRingSpread;
        int RightLittleSpread;

        public HandPoseModifier()
        {
            LeftThumb1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 1 Stretched");
            LeftThumb2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 2 Stretched");
            LeftThumb3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 3 Stretched");
            LeftIndex1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 1 Stretched");
            LeftIndex2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 2 Stretched");
            LeftIndex3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 3 Stretched");
            LeftMiddle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 1 Stretched");
            LeftMiddle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 2 Stretched");
            LeftMiddle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 3 Stretched");
            LeftRing1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 1 Stretched");
            LeftRing2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 2 Stretched");
            LeftRing3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 3 Stretched");
            LeftLittle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 1 Stretched");
            LeftLittle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 2 Stretched");
            LeftLittle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 3 Stretched");
            LeftThumbSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb Spread");
            LeftIndexSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Index Spread");
            LeftMiddleSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Middle Spread");
            LeftRingSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Ring Spread");
            LeftLittleSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Little Spread");

            RightThumb1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 1 Stretched");
            RightThumb2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 2 Stretched");
            RightThumb3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 3 Stretched");
            RightIndex1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 1 Stretched");
            RightIndex2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 2 Stretched");
            RightIndex3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 3 Stretched");
            RightMiddle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 1 Stretched");
            RightMiddle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 2 Stretched");
            RightMiddle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 3 Stretched");
            RightRing1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 1 Stretched");
            RightRing2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 2 Stretched");
            RightRing3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 3 Stretched");
            RightLittle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 1 Stretched");
            RightLittle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 2 Stretched");
            RightLittle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 3 Stretched");
            RightThumbSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb Spread");
            RightIndexSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Index Spread");
            RightMiddleSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Middle Spread");
            RightRingSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Ring Spread");
            RightLittleSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Little Spread");
        }

        public void Modify(ref HumanPose pose)
        {
            if (LeftHandPose != null)
            {
                pose.muscles[this.LeftThumb1Stretched] = LeftHandPose.ThumbStretch;
                pose.muscles[this.LeftThumb2Stretched] = LeftHandPose.ThumbStretch;
                pose.muscles[this.LeftThumb3Stretched] = LeftHandPose.ThumbStretch;
                pose.muscles[this.LeftIndex1Stretched] = LeftHandPose.IndexStretch;
                pose.muscles[this.LeftIndex2Stretched] = LeftHandPose.IndexStretch;
                pose.muscles[this.LeftIndex3Stretched] = LeftHandPose.IndexStretch;
                pose.muscles[this.LeftMiddle1Stretched] = LeftHandPose.MiddleStretch;
                pose.muscles[this.LeftMiddle2Stretched] = LeftHandPose.MiddleStretch;
                pose.muscles[this.LeftMiddle3Stretched] = LeftHandPose.MiddleStretch;
                pose.muscles[this.LeftRing1Stretched] = LeftHandPose.RingStretch;
                pose.muscles[this.LeftRing2Stretched] = LeftHandPose.RingStretch;
                pose.muscles[this.LeftRing3Stretched] = LeftHandPose.RingStretch;
                pose.muscles[this.LeftLittle1Stretched] = LeftHandPose.LittleStretch;
                pose.muscles[this.LeftLittle2Stretched] = LeftHandPose.LittleStretch;
                pose.muscles[this.LeftLittle3Stretched] = LeftHandPose.LittleStretch;
                pose.muscles[this.LeftThumbSpread] = LeftHandPose.ThumbSpread;
                pose.muscles[this.LeftIndexSpread] = LeftHandPose.IndexSpread;
                pose.muscles[this.LeftMiddleSpread] = LeftHandPose.MiddleSpread;
                pose.muscles[this.LeftRingSpread] = LeftHandPose.RingSpread;
                pose.muscles[this.LeftLittleSpread] = LeftHandPose.LittleSpread;
            }

            if (RightHandPose != null)
            {
                pose.muscles[this.RightThumb1Stretched] = RightHandPose.ThumbStretch;
                pose.muscles[this.RightThumb2Stretched] = RightHandPose.ThumbStretch;
                pose.muscles[this.RightThumb3Stretched] = RightHandPose.ThumbStretch;
                pose.muscles[this.RightIndex1Stretched] = RightHandPose.IndexStretch;
                pose.muscles[this.RightIndex2Stretched] = RightHandPose.IndexStretch;
                pose.muscles[this.RightIndex3Stretched] = RightHandPose.IndexStretch;
                pose.muscles[this.RightMiddle1Stretched] = RightHandPose.MiddleStretch;
                pose.muscles[this.RightMiddle2Stretched] = RightHandPose.MiddleStretch;
                pose.muscles[this.RightMiddle3Stretched] = RightHandPose.MiddleStretch;
                pose.muscles[this.RightRing1Stretched] = RightHandPose.RingStretch;
                pose.muscles[this.RightRing2Stretched] = RightHandPose.RingStretch;
                pose.muscles[this.RightRing3Stretched] = RightHandPose.RingStretch;
                pose.muscles[this.RightLittle1Stretched] = RightHandPose.LittleStretch;
                pose.muscles[this.RightLittle2Stretched] = RightHandPose.LittleStretch;
                pose.muscles[this.RightLittle3Stretched] = RightHandPose.LittleStretch;
                pose.muscles[this.RightThumbSpread] = RightHandPose.ThumbSpread;
                pose.muscles[this.RightIndexSpread] = RightHandPose.IndexSpread;
                pose.muscles[this.RightMiddleSpread] = RightHandPose.MiddleSpread;
                pose.muscles[this.RightRingSpread] = RightHandPose.RingSpread;
                pose.muscles[this.RightLittleSpread] = RightHandPose.LittleSpread;
            }
        }
    }
}
