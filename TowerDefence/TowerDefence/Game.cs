using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TowerDefence
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public const int iTILE_SIZE = 32;
        public static readonly Point pTILE_SIZE = new Point(iTILE_SIZE);
        public const int iMAP_WIDTH = 40;
        public const int iMAP_HEIGHT = 20;
        Tile[,] tiles = new Tile[iMAP_WIDTH, iMAP_HEIGHT];

        Texture2D texTileGrass;
        Texture2D texTileRock;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texTileGrass = Content.Load<Texture2D>("Tile/Grass");
            texTileRock = Content.Load<Texture2D>("Tile/Rock");

            LoadMap("test.tdmap");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int x = 0; x < iMAP_WIDTH; x++)
                for (int y = 0; y < iMAP_HEIGHT; y++)
                    tiles[x, y].Draw(spriteBatch, new Point(x * iTILE_SIZE, y * iTILE_SIZE));

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void LoadMap(string path)
        {
            string fileText = System.IO.File.ReadAllText(path);
            string cleanedFileText = "";
            foreach (char c in fileText)
                if (!char.IsControl(c))
                    cleanedFileText += c;
            fileText = cleanedFileText;

            int count = 0;
            Texture2D texture;
            foreach (char c in fileText)
            {
                if (c == '0')
                    texture = texTileGrass;
                else
                    texture = texTileRock;
                tiles[count % iMAP_WIDTH, count / iMAP_WIDTH] = new Tile(texture);
                count++;
            }
        }
    }
}
