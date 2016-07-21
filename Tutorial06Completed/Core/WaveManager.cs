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
        public bool newWave = false;
        private int spawnedWuggys = 0;

        public WaveManager()
        {
            _wuggy = AssetStorage.Get<SceneContainer>("WuggyFromLand.fus");
            waveCount = 1;
        }

        public void spawnWave()
        {
            newWave = true;
            timer = new Timer(spawnWuggy, null, 0, 1000);
        }

        private void spawnWuggy(Object state)
        {
            int maxWuggys;

            if (waveCount > 5)
            {
                maxWuggys = 50;
            }
            else
            {
                switch (waveCount)
                {
                    case 1:
                        maxWuggys = 5;
                        break;
                    case 2:
                        maxWuggys = 10;
                        break;
                    case 3:
                        maxWuggys = 15;
                        break;
                    case 4:
                        maxWuggys = 20;
                        break;
                    case 5:
                        maxWuggys = 30;
                        break;

                    default:
                        maxWuggys = 1;
                        break;
                }

                if (newWave && spawnedWuggys < maxWuggys)
                {
                    spawnedWuggys += 1;
                    Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 8, new float3(0.2f, 0.9f, 0.2f), 0, 1, 100, 4));
                }
                else
                {
                    timer.Dispose();
                    spawnedWuggys = 0;
                    waveCount++;
                    newWave = false;
                }

            }
        }
    }
}
