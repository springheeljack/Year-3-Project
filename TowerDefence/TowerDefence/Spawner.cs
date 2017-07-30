using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public class Spawner : Building
    {
        public static float spawnTime = 2.5f;

        public bool ReadyToSpawn
        {
            get { return timer == 0.0f; }
        }
        float timer;

        public Spawner()
        {
            Texture = Game.texSpawner;
            ResetTimer();
        }

        public override void Update()
        {
            if (timer > 0.0f)
                timer -= Game.frameTime;
            if (timer < 0.0f)
                timer = 0.0f;
        }

        public void ResetTimer()
        {
            timer = spawnTime;
        }
    }
}
