using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    public class Creep
    {
        Texture2D texture;
        Point position;
        Path path;
        
        public Creep(Point position)
        {
            this.position = position;
            texture = Game.texCreep;
            path = new Path(new Node(position.X / 32, position.Y / 32));
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, null, new Rectangle(position, texture.Bounds.Size), null, new Vector2(texture.Bounds.Width/2), 0.0f, Vector2.One, Color.White, 0.0f);
        }
    }
}
