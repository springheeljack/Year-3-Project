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
        int X;
        int Y;
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update();
        Texture2D texture;
    }
}
