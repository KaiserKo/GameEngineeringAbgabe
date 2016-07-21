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
        private SceneContainer _wuggy;

        private Timer timer;
        public bool newWave = false;
        private int spawnedWuggys = 0;

        public WaveManager()
        {
            _wuggy = AssetStorage.Get<SceneContainer>("WuggyFromLand.fus");
        }

        public void spawnWave()
        {
            newWave = true;
            timer = new Timer(spawnWuggy, null, 0, 1000);
        }

        private void spawnWuggy(Object state)
        {
            if (newWave && spawnedWuggys < 1) {
                spawnedWuggys += 1;
                Tutorial.ListWuggys.Add(new Wuggy(Tutorial.DeepCopy(_wuggy), new float3(0, 0, 750), 8, new float3(0.2f, 0.9f, 0.2f), 0, 1, 100, 4));
            }
            else
            {
                timer.Dispose();
                spawnedWuggys = 0;
                newWave = false;
            }
            
        }
    }
}
