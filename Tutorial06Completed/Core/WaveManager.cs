using Fusee.Base.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fusee.Tutorial.Core
{
    class WaveManager
    {
        public int difficulty;
        public int waveCount;
        private SceneContainer _wuggy;

        private Timer timer;
        public bool isWaveActive = false;

        private int maxNormalWuggys = 0;
        private int maxSpeedWuggys = 0;
        private int maxTankWuggys = 0;
        private int maxSpeedTankWuggys = 0;
        private int maxBossWuggys = 0;

        private int spawnedNormalWuggys = 0;
        private int spawnedSpeedWuggys = 0;
        private int spawnedTankWuggys = 0;
        private int spawnedSpeedTankWuggys = 0;
        private int spawnedBossWuggys = 0;

        private List<int> spawningListWuggys;

        public WaveManager()
        {
            _wuggy = AssetStorage.Get<SceneContainer>("WuggyFromLand.fus");
            waveCount = 10;
        }

        public void spawnWave()
        {
            spawningListWuggys = new List<int>();

            if (waveCount > 5)
            {
                int maxWuggysOverall = waveCount * 5;
                maxNormalWuggys = (int)(maxWuggysOverall * 0.5);
                maxSpeedWuggys = (int)(maxWuggysOverall * 0.2);
                maxTankWuggys = (int)(maxWuggysOverall * 0.15);
                maxSpeedTankWuggys = (int)(maxWuggysOverall * 0.1);
                maxBossWuggys = (int)(maxWuggysOverall * 0.05);
            }
            else
            {
                switch (waveCount)
                {
                    case 1:
                        maxNormalWuggys = 5;
                        break;
                    case 2:
                        maxNormalWuggys = 8;
                        maxSpeedWuggys = 2;
                        break;
                    case 3:
                        maxNormalWuggys = 10;
                        maxSpeedWuggys = 4;
                        maxTankWuggys = 1;
                        break;
                    case 4:
                        maxNormalWuggys = 10;
                        maxSpeedWuggys = 6;
                        maxTankWuggys = 3;
                        maxSpeedTankWuggys = 1;
                        break;
                    case 5:
                        maxNormalWuggys = 15;
                        maxSpeedWuggys = 8;
                        maxTankWuggys = 4;
                        maxSpeedTankWuggys = 2;
                        maxBossWuggys = 1;
                        break;

                    default:
                        maxNormalWuggys = 5;
                        break;
                }
            }

            for (int i = 0; i < maxNormalWuggys; i++)
            {
                spawningListWuggys.Add(1);
            }
            for (int i = 0; i < maxSpeedWuggys; i++)
            {
                spawningListWuggys.Add(2);
            }
            for (int i = 0; i < maxTankWuggys; i++)
            {
                spawningListWuggys.Add(3);
            }
            for (int i = 0; i < maxSpeedTankWuggys; i++)
            {
                spawningListWuggys.Add(4);
            }
            for (int i = 0; i < maxBossWuggys; i++)
            {
                spawningListWuggys.Add(5);
            }

            timer = new Timer(spawnWuggys, null, 0, 2000);
 
        }

        private void spawnWuggys(Object state)
        {

            if (spawningListWuggys.Count > 0)
            {
                Random rnd = new Random();
                int r = rnd.Next(spawningListWuggys.Count);
                spawnWuggy(spawningListWuggys[r]);
                spawningListWuggys.RemoveAt(r);
            }
            else
            {
                timer.Dispose();
                spawnedNormalWuggys = 0;
                spawnedSpeedWuggys = 0;
                spawnedTankWuggys = 0;
                spawnedSpeedTankWuggys = 0;
                spawnedBossWuggys = 0;
                waveCount++;
            }
            
        }

        private void spawnWuggy(int _wuggyType)
        {
            switch (_wuggyType)
            {
                case 1:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 4, new float3(0.2f, 0.2f, 0.9f), 5, 1.5f, 50, 20));
                    spawnedNormalWuggys += 1;
                    break;
                case 2:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 4, new float3(0.2f, 0.9f, 0.2f), 5, 3.0f, 50, 30));
                    spawnedSpeedWuggys += 1;
                    break;
                case 3:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 6, new float3(0.9f, 0.2f, 0.2f), 10, 1.5f, 100, 40));
                    spawnedTankWuggys += 1;
                    break;
                case 4:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 6, new float3(0.2f, 0.9f, 0.9f), 10, 3.0f, 100, 60));
                    spawnedSpeedTankWuggys += 1;
                    break;
                case 5:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 8, new float3(0.2f, 0.2f, 0.9f), 20, 1.0f, 300, 100));
                    spawnedBossWuggys += 1;
                    break;

                default:
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 4, new float3(0.2f, 0.2f, 0.9f), 5, 1.5f, 30, 20));
                    spawnedNormalWuggys += 1;
                    break;
            }
        }
    }
}
