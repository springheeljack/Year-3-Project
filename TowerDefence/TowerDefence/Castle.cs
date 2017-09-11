using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public class Castle : Building
    {
        public Castle(Tile t) : base(t)
        {
            Texture = Game.texCastle;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
