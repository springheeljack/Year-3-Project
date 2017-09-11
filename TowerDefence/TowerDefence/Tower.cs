using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public class Tower : Building
    {
        public float rotation = 0.0f;
        public Texture2D barrelTexture;
        public Tower(Tile t) : base(t)
        {
            Texture = Game.texTower;
            barrelTexture = Game.texTowerBarrel;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(barrelTexture, null, new Rectangle(position, barrelTexture.Bounds.Size), null, new Vector2(Game.iTILE_SIZE_HALF), rotation, Vector2.One, Color.White, 0.0f);
        }
    }
}
