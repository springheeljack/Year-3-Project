using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class CreepManager
    {
        int maxCreeps = 10;

        List<Creep> creeps = new List<Creep>();

        public void SpawnCreep(Point position)
        {
            Creep newCreep = new Creep(position.ToVector2());
            creeps.Add(newCreep);
        }

        public void Update()
        {
            foreach (Spawner s in Game.allSpawners)
            {
                if (s.ReadyToSpawn && creeps.Count < maxCreeps)
                {
                    SpawnCreep(s.position);
                    s.ResetTimer();
                }
            }
            foreach (Creep c in creeps)
                c.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Creep c in creeps)
                c.Draw(spriteBatch);
        }
    }
}