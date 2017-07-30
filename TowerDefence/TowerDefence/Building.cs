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
        Point position;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(position, texture.Bounds.Size), Color.White);
        }
        public abstract void Update();
        Texture2D texture;
    }
}
