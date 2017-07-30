using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public class Tile
    {
        Building building;
        Texture2D texture;
        public Tile(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            spriteBatch.Draw(texture, new Rectangle(position, Game.pTILE_SIZE), Color.White);
        }
    }
}