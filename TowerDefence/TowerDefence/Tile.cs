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
        public Building Building
        {
            get { return building; }
            set { building = value; }
        }
        Texture2D texture;
        public Tile(Texture2D texture)
        {
            this.texture = texture;
            building = null;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            spriteBatch.Draw(texture, new Rectangle(position, Game.pTILE_SIZE), Color.White);
            if (building != null)
                building.Draw(spriteBatch);
        }
        public bool IsPassable
        {
            get
            {
                return !(building is Tower);
            }
        }
    }
}