using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public enum Terrain
    {
        Grass,
        Rock
    }

    public class Tile
    {
        int cost = 1;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        int x;
        int y;
        public int X { get { return x; } }
        public int Y { get { return y; } }

        Terrain terrain;

        Building building;
        public Building Building
        {
            get { return building; }
            set { building = value; }
        }
        Texture2D texture;
        public Tile(Texture2D texture,int X,int Y,Terrain terrain)
        {
            this.texture = texture;
            x = X;
            y = Y;
            building = null;
            this.terrain = terrain;
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
                return !(building is Tower) && terrain == Terrain.Grass;
            }
        }
    }
}