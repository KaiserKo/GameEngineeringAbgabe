using Fusee.Base.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Math;

namespace Fusee.Tutorial.Core
{
    class Tower
    {
        private SceneContainer model;
        private float3 position;
        private int speed;
        private float range;
        private int damage;
        public float3 cylinderPos;
        public List<Shot> towerBulletList;
        public List<Shot> removeShots;
        private int inxShotRepeating;
        public bool towerIsShoting;
        public Wuggy nextWuggy;
        private Timer timer;

        public Tower(SceneContainer _model, float3 _position, int _speed, float _range, int _damage) {
            position = _position;
            speed = _speed;
            range = _range;
            damage = _damage;

            model = _model;

            model.Children.First().GetTransform().Translation = position;

            cylinderPos = Model.Children.FindNodes(c => c.Name == "Cylinder").First().GetTransform().Translation;

            towerBulletList = new List<Shot>();
            removeShots = new List<Shot>();
            towerIsShoting = false;
        }

        public Wuggy getClosestWuggy()
        {
            float minDist = float.MaxValue;
            Wuggy ret = null;
            foreach (var target in Tutorial.ListWuggys)
            {
                var xf = target.Model.Children[0].GetTransform();
                float dist = (position - xf.Translation).Length;
                if (dist < minDist && dist < range)
                {
                    ret = target;
                    minDist = dist;
                }
            }
            return ret;
        }

        public void towerShot(bool check)
        {
            if (check)
            {
                timer = new Timer(createShot, null, 0, speed);
            }
            else if (!check && timer != null)
            {
                timer.Dispose();
            }
        }

        public void createShot(Object state)
        {
            towerBulletList.Add(new Shot(this, nextWuggy));
        }

        public void removeTowerShot()
        {
            List<Shot> temp = new List<Shot>(removeShots);
            foreach (Shot s in temp)
            {
                towerBulletList.Remove(s);
                removeShots.Remove(s);
            }
        }

        public SceneContainer Model { get { return model; } set { model = value; }}

        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }
    }

    /*************
    * SHOT-CLASS *
    **************/
    class Shot
    {
        public SceneContainer bullet;
        public Wuggy wuggy;
        public Tower tower;
        public float bulletSpeed;

        public Shot(Tower _tower, Wuggy _wuggy)
        {
            tower = _tower;
            wuggy = _wuggy;
            bullet = Tutorial.DeepCopy(Tutorial.towerBullet);
            bulletSpeed = 100;

            float3 vVec = new float3(-148, 150, 0);
            float3 towerPos = _tower.Model.Children.First().GetTransform().Translation;
            float4x4 mtxRot = float4x4.CreateRotationY(_tower.Model.Children.First().GetTransform().Rotation.y);
            float3 bulletPos = (mtxRot * vVec) + towerPos;

            bullet.Children.First().GetTransform().Translation = bulletPos;
            bullet.Children.First().GetTransform().Scale = new float3(10, 10, 10);
        }
      // TODO: Schuss - Kugelanimation  
        public void moveShot()
        {
            float3 wuggyPos = wuggy.Model.Children.First().GetTransform().Translation;
            float3 bulletPos = bullet.Children.First().GetTransform().Translation;
            float3 targetDist = wuggyPos - bulletPos;

            float3 absTargetDist = new float3((float)Abs(targetDist.x), (float)Abs(targetDist.y), (float)Abs(targetDist.z));

            float wuggyScale = wuggy.Size;

            if (hitTarget(absTargetDist, wuggyScale))
            {
                tower.removeShots.Add(this);
            }
            else
            {
                float bulletYaw = (float)Atan2(targetDist.z, targetDist.x) * 180 / (float)PI;
                bullet.Children.First().GetTransform().Rotation.y = bulletYaw;

                float vx = bulletSpeed * (90 - Abs(bullet.Children.First().GetTransform().Rotation.y)) / 90;
                float vz;

                if (bullet.Children.First().GetTransform().Rotation.y < 0)
                {
                    vz = -bulletSpeed + Abs(vx);
                }
                else
                {
                    vz = bulletSpeed - Abs(vx);
                }

                bullet.Children.First().GetTransform().Translation.x += vx;
                bullet.Children.First().GetTransform().Translation.z += vz;

                float3 vy = float3.Lerp(bulletPos, new float3(wuggyPos.x, wuggyScale * 10.0f, wuggyPos.z), 0.3f);

                bullet.Children.First().GetTransform().Translation.y = vy.y;
            }
        }

        private bool hitTarget(float3 dist, float scale)
        {
            bool val = false;

            if (dist.x < scale * 20.0f && dist.y < scale * 20.0f && dist.z < scale * 20.0f)
            {
                val = true;
                bool killed = wuggy.takeDamage(tower.Damage);

                if (killed)
                {
                    List<Shot> tempList = tower.towerBulletList;
                    foreach (Shot s in tempList)
                    {
                        if (s.wuggy == wuggy)
                        {
                            tower.removeShots.Add(s);
                            Tutorial.ListWuggys.Remove(wuggy);
                        }
                    }
                }
            }

            return val;
        }
    }
}
