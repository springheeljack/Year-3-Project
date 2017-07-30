using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TowerDefence
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Constants
        public const int iTILE_SIZE = 32;
        public const int iTILE_SIZE_HALF = iTILE_SIZE / 2;
        public static readonly Point pTILE_SIZE = new Point(iTILE_SIZE);
        public const int iMAP_WIDTH = 40;
        public const int iMAP_HEIGHT = 20;
        public static float frameTime;

        public static Tile[,] tiles = new Tile[iMAP_WIDTH, iMAP_HEIGHT];
        List<Building> allBuildings = new List<Building>();
        List<Tower> allTowers = new List<Tower>();
        public static List<Spawner> allSpawners = new List<Spawner>();
        Castle castle;
        static CreepManager creepManager = new CreepManager();


        public static Texture2D texTileGrass;
        public static Texture2D texTileRock;
        public static Texture2D texCastle;
        public static Texture2D texTower, texTowerBarrel, texSpawner, texCreep;

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
            texCastle = Content.Load<Texture2D>("Building/Castle");
            texTower = Content.Load<Texture2D>("Building/Tower");
            texTowerBarrel = Content.Load<Texture2D>("Building/TowerBarrel");
            texSpawner = Content.Load<Texture2D>("Building/Spawner");
            texCreep = Content.Load<Texture2D>("Creep/Creep");

            LoadMap("test.tdmap");

            CreateBuilding(new Tower(), 3, 3);
            CreateBuilding(new Tower(), 2, 3);
            CreateBuilding(new Tower(), 1, 3);

            CreateBuilding(new Castle(), 5, 5);

            CreateBuilding(new Spawner(), 15, 15);
            CreateBuilding(new Spawner(), 15, 14);
            CreateBuilding(new Spawner(), 15, 13);
            CreateBuilding(new Spawner(), 6, 5);
            CreateBuilding(new Spawner(), 4, 3);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Spawner s in allSpawners)
                s.Update();
            creepManager.Update();
   
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int x = 0; x < iMAP_WIDTH; x++)
                for (int y = 0; y < iMAP_HEIGHT; y++)
                    tiles[x, y].Draw(spriteBatch, new Point(x * iTILE_SIZE, y * iTILE_SIZE));

            creepManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void LoadMap(string path)
        {
            string fileText = System.IO.File.ReadAllText("Map/" + path);
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
        void CreateBuilding(Building building, int TileX, int TileY)
        {
            building.position = new Point(TileX * iTILE_SIZE + iTILE_SIZE_HALF, TileY * iTILE_SIZE + iTILE_SIZE_HALF);
            tiles[TileX, TileY].Building = building;
            allBuildings.Add(building);
            if (building is Tower)
                allTowers.Add(building as Tower);
            else if (building is Spawner)
                allSpawners.Add(building as Spawner);
            else if (building is Castle)
            {
                if (castle != null)
                    throw new Exception("Only one castle can exist at once.");
                castle = building as Castle;
            }
        }
    }
}