using System;
using System.Collections.Generic;
using Fusee.Xirkit;
using Fusee.Math.Core;
using static System.Math;

namespace Fusee.Tutorial.Core
{
    class AnimationManager
    {
        public float speed;
        private Channel<float3> translationChannel = new Channel<float3>(Lerp.Float3Lerp);
        private Channel<float3> rotationChannel = new Channel<float3>(Lerp.Float3Lerp);
        private List<Channel<float3>> animationList = new List<Channel<float3>>();

        public AnimationManager()
        {
            speed = 1;
        }

        public AnimationManager(float _speed)
        {
            speed = _speed;
        }

        public List<Channel<float3>> getAnimation(int anim)
        {
            switch (anim)
            {
                #region Animation_1
                case 0:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, new float3(0, 0, 0)));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, new float3(0, 0, 2000)));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, new float3(0, 0, 2000)));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, new float3(2000, 0, 2000)));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, new float3(2000, 0, 2000)));
                    translationChannel.AddKeyframe(new Keyframe<float3>(18, new float3(2000, 0, 0)));

                    translationChannel.AddKeyframe(new Keyframe<float3>(18.5f, new float3(2000, 0, 0)));
                    translationChannel.AddKeyframe(new Keyframe<float3>(24, new float3(0, 0, 0)));

                    translationChannel.AddKeyframe(new Keyframe<float3>(24.5f, new float3(0, 0, 0)));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, new float3(0, 0, 0)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(6, new float3(0, 0, 0)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(6.5f, new float3(0, (float)(PI/2), 0)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(12, new float3(0, (float)(PI / 2), 0)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(12.5f, new float3(0, (float)PI, 0)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(18, new float3(0, (float)PI, 0)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(18.5f, new float3(0, (float)(PI + (PI / 2)), 0)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(24, new float3(0, (float)(PI + (PI / 2)), 0)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(24.5f, new float3(0, (float)(2 * PI), 0)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                case 1:
                    return animationList;

                default:
                    return animationList;
            }
        }

        public List<Channel<float3>> getRandomAnimation()
        {
            animationList = getAnimation(new Random().Next(2));
            return animationList;
        }
    }
}
