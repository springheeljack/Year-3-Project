using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public abstract class Building
    {
        int health;
        int maxHealth;
        public Point position;
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Texture, new Rectangle(position, Texture.Bounds.Size), Color.White);
            spriteBatch.Draw(Texture, null, new Rectangle(position, Texture.Bounds.Size), null, new Vector2(Game.iTILE_SIZE_HALF), 0.0f, Vector2.One, Color.White, 0.0f);
        }
        public abstract void Update();
        public Texture2D Texture;
    }
}