using System.Collections.Generic;
using System.Linq;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using System.IO;
using static System.Math;
using Fusee.Xirkit;
using System;

namespace Fusee.Tutorial.Core
{
    class AnimationManager
    {
        public float speed;
        private Channel<float3> translationChannel = new Channel<float3>(Lerp.Float3Lerp);
        private Channel<float3> rotationChannel = new Channel<float3>(Lerp.Float3Lerp);
        private List<Channel<float3>> animationList = new List<Channel<float3>>();

        private float3 startPoint;
        private float3 endPoint;
        private List<float3> kreuzung = new List<float3>();
        private Dictionary<String, float3> rotation = new Dictionary<string, float3>();

        public AnimationManager()
        {
            speed = 1;
            getKreuzungen();
            fillRotation();
        }

        public AnimationManager(float _speed)
        {
            speed = _speed;
            getKreuzungen();
            fillRotation();
        }

        private void getKreuzungen()
        {
            var kreuzungen = Tutorial._scene.Children.FindNodes(n => n.Name == "Kreuzungen").First();
            foreach (var k in kreuzungen.Children)
            {
                kreuzung.Add(k.GetTransform().Translation);
            }

            startPoint = new float3(-6500.0f, 0, -299.3065f);
            endPoint = new float3(6700.0f, 0, 2024.351f);
        }

        private void fillRotation()
        {
            rotation.Add("norden", new float3(0, (float)PI, 0));
            rotation.Add("osten", new float3(0, (float)(PI + (PI / 2)), 0));
            rotation.Add("suedenNULL", new float3(0, 0, 0));
            rotation.Add("suedenPI", new float3(0, (float)(2 * PI), 0));
        }

// TODO: Animation - Zeiten an Raster anpassen
// TODO: Animation - Rotation einbauen
        public List<Channel<float3>> getAnimation(int anim)
        {
            switch (anim)
            {
                #region Animation_1
                case 0:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[7]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[7]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[6]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[6]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[5]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[5]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[4]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[4]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[3]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[3]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, kreuzung[2]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(13.5f, kreuzung[2]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(15, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(15, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_2
                case 1:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[21]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[21]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[20]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[20]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[19]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[19]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[18]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[18]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[17]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[17]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[16]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[16]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[15]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[15]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(13, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_3
                case 2:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[31]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[31]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[28]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[28]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[27]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[27]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[26]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[26]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[25]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[25]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(13.5f, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(15, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(15, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_4
                case 3:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[31]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[31]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[28]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[28]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[27]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[27]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[26]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[26]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[25]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[25]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(13, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_5
                case 4:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[21]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[21]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[20]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[20]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[19]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[19]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, kreuzung[18]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(13.5f, kreuzung[18]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14, kreuzung[17]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f, kreuzung[17]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(15, kreuzung[16]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(15.5f, kreuzung[16]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(16, kreuzung[15]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(16.5f, kreuzung[15]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(17, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(17.5f, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(18, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(18.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(19, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(19, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_6
                case 5:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(1, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(1.5f, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(2, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(2.5f, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(3, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(3.5f, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(4, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(4.5f, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(6, kreuzung[7]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(6.5f, kreuzung[7]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(7, kreuzung[6]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(7.5f, kreuzung[6]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8, kreuzung[5]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f, kreuzung[5]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(9, kreuzung[4]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.5f, kreuzung[4]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(10, kreuzung[3]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(10.5f, kreuzung[3]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(11, kreuzung[2]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(11.5f, kreuzung[2]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(12, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(12.5f, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(13, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0, rotation["osten"]));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(13, rotation["osten"]));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                default:
                    return animationList;
            }
        }

        public List<Channel<float3>> getRandomAnimation()
        {
            animationList = getAnimation(new Random().Next(6));
            return animationList;
        }
    }
}
