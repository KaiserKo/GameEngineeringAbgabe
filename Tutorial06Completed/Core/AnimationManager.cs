﻿using System.Collections.Generic;
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

        public AnimationManager()
        {
            speed = 1;
            getKreuzungen();
        }

        public AnimationManager(float _speed)
        {
            if (_speed > 0)
            {
                speed = _speed;
            }
            else
            {
                speed = 1;
            }
            getKreuzungen();
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

// TODO: Animation - Speed-Komponente einbauen
        public List<Channel<float3>> getAnimation(int anim, Wuggy wuggy)
        {
            wuggy.Model.Children.First().GetTransform().Rotation.y = (float)(PI + (PI / 2));
            switch (anim)
            {
                #region Animation_1
                case 0:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(52.5f / speed, kreuzung[7]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(53.0f / speed, kreuzung[7]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(65.0f / speed, kreuzung[6]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(65.5f / speed, kreuzung[6]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(66.5f / speed, kreuzung[5]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(67.0f / speed, kreuzung[5]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(76.0f / speed, kreuzung[4]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(76.5f / speed, kreuzung[4]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(77.5f / speed, kreuzung[3]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(78.0f / speed, kreuzung[3]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(87.5f / speed, kreuzung[2]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(88.0f / speed, kreuzung[2]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(91.5f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(92.0f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(102.0f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(52.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(53.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(65.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(65.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(66.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(67.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(76.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(76.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(77.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(78.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(87.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(88.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(91.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(92.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(102.0f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_2
                case 1:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(29.0f / speed, kreuzung[21]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(29.5f / speed, kreuzung[21]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(44.5f / speed, kreuzung[20]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(45.0f / speed, kreuzung[20]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(48.5f / speed, kreuzung[19]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(49.0f / speed, kreuzung[19]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(62.5f / speed, kreuzung[18]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(63.0f / speed, kreuzung[18]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(66.5f / speed, kreuzung[17]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(67.0f / speed, kreuzung[17]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(68.0f / speed, kreuzung[16]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(68.5f / speed, kreuzung[16]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(76.0f / speed, kreuzung[15]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(76.5f / speed, kreuzung[15]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(79.5f / speed, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(80.0f / speed, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(83.5f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(84.0f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(94.0f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(29.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(29.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(44.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(45.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(48.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(49.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(62.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(63.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(66.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(67.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(68.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(68.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(76.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(76.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(79.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(80.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(83.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(84.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(94.0f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_3
                case 2:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(46.0f / speed, kreuzung[31]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, kreuzung[31]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(56.5f / speed, kreuzung[28]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(57.0f / speed, kreuzung[28]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(60.0f / speed, kreuzung[27]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(60.5f / speed, kreuzung[27]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(68.0f / speed, kreuzung[26]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(68.5f / speed, kreuzung[26]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(71.5f / speed, kreuzung[25]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(72.0f / speed, kreuzung[25]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(85.0f / speed, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(85.5f / speed, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(89.0f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(89.5f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(99.5f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(46.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(56.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(57.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(60.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(60.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(68.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(68.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(71.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(72.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(85.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(85.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(89.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(89.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(99.5f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_4
                case 3:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(30.5f / speed, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(31.0f / speed, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(33.0f / speed, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(33.5f / speed, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(36.0f / speed, kreuzung[31]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(36.5f / speed, kreuzung[31]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, kreuzung[28]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(47.0f / speed, kreuzung[28]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(50.0f / speed, kreuzung[27]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(50.5f / speed, kreuzung[27]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(58.0f / speed, kreuzung[26]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(58.5f / speed, kreuzung[26]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(61.5f / speed, kreuzung[25]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(62.0f / speed, kreuzung[25]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(75.0f / speed, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(75.5f / speed, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(79.0f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(79.5f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(89.5f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(30.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(31.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(33.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(33.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(36.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(36.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(47.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(50.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(50.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(58.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(58.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(61.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(62.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(75.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(75.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(79.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(79.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(89.5f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_5
                case 4:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, kreuzung[14]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, kreuzung[14]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, kreuzung[13]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, kreuzung[13]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, kreuzung[12]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, kreuzung[12]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, kreuzung[11]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, kreuzung[11]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, kreuzung[10]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, kreuzung[10]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, kreuzung[9]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, kreuzung[9]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, kreuzung[8]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, kreuzung[8]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(48.5f / speed, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(49.0f / speed, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(51.0f / speed, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(51.5f / speed, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(59.0f / speed, kreuzung[21]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(59.5f / speed, kreuzung[21]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(74.5f / speed, kreuzung[20]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(75.0f / speed, kreuzung[20]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(78.5f / speed, kreuzung[19]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(79.0f / speed, kreuzung[19]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(92.5f / speed, kreuzung[18]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(93.0f / speed, kreuzung[18]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(96.5f / speed, kreuzung[17]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(97.0f / speed, kreuzung[17]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(98.0f / speed, kreuzung[16]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(98.5f / speed, kreuzung[16]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(106.0f / speed, kreuzung[15]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(106.5f / speed, kreuzung[15]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(109.5f / speed, kreuzung[1]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(110.0f / speed, kreuzung[1]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(113.5f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(114.0f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(124.0f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(5.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(17.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(18.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(21.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(22.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(27.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(37.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(38.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(41.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(43.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(44.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(48.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(49.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(51.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(51.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(59.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(59.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(74.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(75.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(78.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(79.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(92.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(93.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(96.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(97.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(98.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(98.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(106.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(106.5f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(109.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(110.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(113.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(114.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(124.0f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                #region Animation_6
                case 5:
                    #region Translation
                    translationChannel.AddKeyframe(new Keyframe<float3>(0.0f, startPoint));
                    translationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, kreuzung[24]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, kreuzung[24]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, kreuzung[23]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, kreuzung[23]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, kreuzung[22]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, kreuzung[22]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(30.5f / speed, kreuzung[30]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(31.0f / speed, kreuzung[30]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(33.0f / speed, kreuzung[29]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(33.5f / speed, kreuzung[29]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, kreuzung[7]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(47.0f / speed, kreuzung[7]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(59.0f / speed, kreuzung[6]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(59.5f / speed, kreuzung[6]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(60.5f / speed, kreuzung[5]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(61.0f / speed, kreuzung[5]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(70.0f / speed, kreuzung[4]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(70.5f / speed, kreuzung[4]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(71.5f / speed, kreuzung[3]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(72.0f / speed, kreuzung[3]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(81.5f / speed, kreuzung[2]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(82.0f / speed, kreuzung[2]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(85.5f / speed, kreuzung[0]));

                    translationChannel.AddKeyframe(new Keyframe<float3>(86.0f / speed, kreuzung[0]));
                    translationChannel.AddKeyframe(new Keyframe<float3>(96.0f / speed, endPoint));

                    animationList.Add(translationChannel);
                    #endregion

                    #region Rotation
                    rotationChannel.AddKeyframe(new Keyframe<float3>(0.0f, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(8.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(9.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(14.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(15.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(25.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(26.0f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(30.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(31.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(33.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(33.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(46.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(47.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(59.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(59.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(60.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(61.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(70.0f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(70.5f / speed, turnLeft(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(71.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(72.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(81.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(82.0f / speed, turnRight(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(85.5f / speed, getWuggyRot(wuggy)));
                    rotationChannel.AddKeyframe(new Keyframe<float3>(86.0f / speed, getWuggyRot(wuggy)));

                    rotationChannel.AddKeyframe(new Keyframe<float3>(96.0f / speed, getWuggyRot(wuggy)));

                    animationList.Add(rotationChannel);
                    #endregion

                    return animationList;
                #endregion

                default:
                    return animationList;
            }
        }

        public List<Channel<float3>> getRandomAnimation(Wuggy wuggy)
        {
            animationList = getAnimation(new Random().Next(6), wuggy);
            return animationList;
        }

        private float3 turnRight(Wuggy wuggy)
        {
            wuggy.Model.Children.First().GetTransform().Rotation = new float3(0, (float)(wuggy.Model.Children.First().GetTransform().Rotation.y + (PI / 2)), 0);
            return wuggy.Model.Children.First().GetTransform().Rotation;
        }

        private float3 turnLeft(Wuggy wuggy)
        {
            wuggy.Model.Children.First().GetTransform().Rotation = new float3(0, (float)(wuggy.Model.Children.First().GetTransform().Rotation.y - (PI / 2)), 0);
            return wuggy.Model.Children.First().GetTransform().Rotation;
        }

        private float3 getWuggyRot(Wuggy wuggy)
        {
            return wuggy.Model.Children.First().GetTransform().Rotation;
        }
    }
}
