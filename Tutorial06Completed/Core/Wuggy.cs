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
        private float speed;
        private int health;
        private float3 color;
        private int size;
        private int damage;
        private int money;
        private int animationNumber;

        private Animation animation;
        public List<Channel<float3>> channelList;

        public Wuggy(SceneContainer _model, float3 _position, int _size, float3 _color, int _damage, float _speed, int _health, int _money)
        {

            model = _model;
            position = _position;
            size = _size;
            color = _color;
            damage = _damage;
            speed = _speed;
            health = _health;
            money = _money;

            model.Children.First().GetTransform().Translation = position;
            model.Children.FindNodes(n => n.Name == "Body").First().GetMaterial().Diffuse.Color = _color;
            var scaleFactor = size * 0.1f;
            model.Children.First().GetTransform().Scale = new float3(scaleFactor, scaleFactor, scaleFactor);

            SetUpRandomAnimations();
        }

        public Wuggy(SceneContainer _model, float3 _position, int _size, float3 _color, int _speed, int _health, int _money, int _animationNumber)
        {

            model = _model;
            position = _position;
            size = _size;
            color = _color;
            speed = _speed;
            health = _health;
            money = _money;
            animationNumber = _animationNumber;

            model.Children.First().GetTransform().Translation = position;
            model.Children.FindNodes(n => n.Name == "Body").First().GetMaterial().Diffuse.Color = _color;
            var scaleFactor = size * 0.1f;
            model.Children.First().GetTransform().Scale = new float3(scaleFactor, scaleFactor, scaleFactor);

            SetUpAnimations();
        }

        public bool takeDamage(int damage)
        {
            health -= damage;

            if(health <= 0)
            {
                Tutorial.ListWuggys.Remove(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetUpAnimations()
        {
            AnimationManager animationManager = new AnimationManager(speed);

            animation = new Animation(0);
            channelList = animationManager.getAnimation(animationNumber, this);

            animation.AddAnimation(channelList.ElementAt(0), model.Children[0].GetTransform(), "Translation");
            animation.AddAnimation(channelList.ElementAt(1), model.Children[0].GetTransform(), "Rotation");
        }

        public void SetUpRandomAnimations()
        {
            AnimationManager animationManager = new AnimationManager(speed);

            animation = new Animation(0);
            channelList = animationManager.getRandomAnimation(this);

            animation.AddAnimation(channelList.ElementAt(0), model.Children[0].GetTransform(), "Translation");
            animation.AddAnimation(channelList.ElementAt(1), model.Children[0].GetTransform(), "Rotation");
        }

        public SceneContainer Model { get { return model; } set { model = value; } }
        public Animation Animation { get { return animation; } set { animation = value; } }



    }
}
