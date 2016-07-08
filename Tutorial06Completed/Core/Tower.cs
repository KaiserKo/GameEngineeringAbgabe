using Fusee.Base.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using System.Collections.Generic;
using System.Linq;

namespace Fusee.Tutorial.Core
{
    class Tower
    {
        private SceneContainer model;
        private float3 position;
        private int speed;
        private int range;
        private int damage;

        public Tower(SceneContainer _model, float3 _position, int _speed, int _range, int _damage) {
            position = _position;
            speed = _speed;
            range = _range;
            damage = _damage;

            model = _model;

            model.Children.First().GetTransform().Translation = position;
        }

        public SceneContainer getClosestWuggy()
        {
            float minDist = float.MaxValue;
            SceneContainer ret = null;
            foreach (var target in Tutorial.ListWuggys)
            {
                var xf = target.Model.Children[0].GetTransform();
                float dist = (position - xf.Translation).Length;
                if (dist < minDist && dist < 1000)
                {
                    ret = target.Model;
                    minDist = dist;
                }
            }
            return ret;
        }

        public SceneContainer Model { get { return model; } set { model = value; }}
    }
}
