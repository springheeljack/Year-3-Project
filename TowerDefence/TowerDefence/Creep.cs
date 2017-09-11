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
        public static float Speed = 100.0f;

        Texture2D texture;
        Vector2 position;
        Path path;
        int tracePosition = 0;
        
        public Creep(Vector2 position)
        {
            this.position = position;
            texture = Game.texCreep;
            path = new Path(new Node((int)position.X / 32, (int)position.Y / 32));
        }

        public void Update()
        {
            Node currentTrace = path.trace.ElementAt(tracePosition);

            if (position.X < currentTrace.x * 32+16)
                position.X += Game.frameTime * Speed;
            if (position.X > currentTrace.x * 32 + 16)
                position.X -= Game.frameTime * Speed;
            if (position.Y < currentTrace.y * 32 + 16)
                position.Y += Game.frameTime * Speed;
            if (position.Y > currentTrace.y * 32 + 16)
                position.Y -= Game.frameTime * Speed;

            if (currentTrace.x * 32 + 16 > TLCorner.X && currentTrace.x * 32 + 16 < BRCorner.X && currentTrace.y * 32 + 16 > TLCorner.Y && currentTrace.y * 32 + 16 < BRCorner.Y)
            {
                tracePosition++;
                if (tracePosition >= path.trace.Count)
                    tracePosition = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, null, new Rectangle(position.ToPoint(), texture.Bounds.Size), null, new Vector2(texture.Bounds.Width/2), 0.0f, Vector2.One, Color.White, 0.0f);
        }

        public Vector2 TLCorner
        {
            get
            {
                return position - texture.Bounds.Size.ToVector2() / 2;
            }
        }
        public Vector2 BRCorner
        {
            get
            {
                return position + texture.Bounds.Size.ToVector2() / 2;
            }
        }
    }
}
