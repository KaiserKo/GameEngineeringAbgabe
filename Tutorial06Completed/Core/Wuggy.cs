using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using System;
using System.Collections.Generic;
using System.Linq;
using Fusee.Xirkit;

namespace Fusee.Tutorial.Core
{
    class Wuggy
    {
        private SceneContainer model;
        private float3 position;
        private int speed;
        private int health;
        private float3 color;
        private int size;
        private int money;

        private Animation animation;
        public Channel<float3> channel;
        

        public Wuggy(SceneContainer _model, float3 _position, int _size, float3 _color, int _speed, int _health, int _money)
        {

            model = _model;
            position = _position;
            size = _size;
            color = _color;
            speed = _speed;
            health = _health;
            money = _money;

            model.Children.First().GetTransform().Translation = position;
            model.Children.FindNodes(n => n.Name == "Body").First().GetMaterial().Diffuse.Color = _color;
            var scaleFactor = size * 0.1f;
            model.Children.First().GetTransform().Scale = new float3(scaleFactor, scaleFactor, scaleFactor);

            SetUpAnimations();
        }

        public void SetUpAnimations()
        {
            animation = new Animation(0);
            channel = new Channel<float3>(Lerp.Float3Lerp);

            channel.AddKeyframe(new Keyframe<float3>(0, new float3(0, 0, 0)));
            channel.AddKeyframe(new Keyframe<float3>(1, new float3(20, 80, 80)));
            channel.AddKeyframe(new Keyframe<float3>(4, new float3(160, 40, 80)));
            channel.AddKeyframe(new Keyframe<float3>(10, new float3(160, 20, 320)));

            animation.AddAnimation(channel, model.Children[0].GetTransform(), "Translation");
        }

        public SceneContainer Model { get { return model; } set { model = value; } }
        public Animation Animation { get { return animation; } set { animation = value; } }



    }
}
