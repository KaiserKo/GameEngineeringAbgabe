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
        public List<Channel<float3>> channelList;
        

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
            AnimationManager animationManager = new AnimationManager();

            animation = new Animation(0);
            channelList = animationManager.getAnimation(0);

            animation.AddAnimation(channelList.ElementAt(0), model.Children[0].GetTransform(), "Translation");
            animation.AddAnimation(channelList.ElementAt(1), model.Children[0].GetTransform(), "Rotation");
        }

        public SceneContainer Model { get { return model; } set { model = value; } }
        public Animation Animation { get { return animation; } set { animation = value; } }



    }
}
