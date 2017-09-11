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
        public static Castle castle;
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

            CreateBuilding(new Tower(tiles[3, 3]));
            CreateBuilding(new Tower(tiles[2, 3]));
            CreateBuilding(new Tower(tiles[1, 3]));

            for (int i = 3; i < 17; i++)
                CreateBuilding(new Tower(tiles[i, 6]));

            CreateBuilding(new Castle(tiles[5, 5]));

            CreateBuilding(new Spawner(tiles[15, 15]));
            //CreateBuilding(new Spawner(tiles[15, 14]));
            //CreateBuilding(new Spawner(tiles[15, 13]));
            //CreateBuilding(new Spawner(tiles[6, 5]));
            //CreateBuilding(new Spawner(tiles[4, 3]));
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
            Terrain terrain;
            foreach (char c in fileText)
            {
                if (c == '0')
                {
                    texture = texTileGrass;
                    terrain = Terrain.Grass;
                }
                else
                {
                    texture = texTileRock;
                    terrain = Terrain.Rock;
                }
                tiles[count % iMAP_WIDTH, count / iMAP_WIDTH] = new Tile(texture, count % iMAP_WIDTH, count / iMAP_WIDTH, terrain);
                count++;
            }
        }
        void CreateBuilding(Building building)
        {
            building.position = new Point(building.Tile.X * iTILE_SIZE + iTILE_SIZE_HALF, building.Tile.Y * iTILE_SIZE + iTILE_SIZE_HALF);
            tiles[building.Tile.X, building.Tile.Y].Building = building;
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