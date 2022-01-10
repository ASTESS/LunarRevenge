using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Levels;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class LevelScreen
    {

        private int currentLevel;

        public static Dictionary<string, Entity> entitys = new Dictionary<string, Entity>();
        public static List<Entity> specialTiles = new List<Entity>();
        private WorldLoader world;
        private TextureManager textureManager;
        public static ContentManager content;
        GraphicsDevice graphicsDevice;
        GraphicsDeviceManager graphics;
        public static Collision collision;
        private Level level;
        private ScreenManager screenManager;

        GuiScreen gui;

        public LevelScreen(ContentManager contentt, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, ScreenManager screenManager)
        {
            content = contentt;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            this.level = screenManager.level;
            this.screenManager = screenManager;
        }

        public void Init()
        {
            Player.score = 0;
            textureManager = new TextureManager(content.Load<Texture2D>("tileset x1"), content.Load<Texture2D>("Props and Items/props and items x1"), graphicsDevice);
            world = new WorldLoader(textureManager, level, content);
            collision = new Collision(world, screenManager);
            entitys.Clear();
            entitys.Add("player", new Player(content.Load<Texture2D>("Players/players blue x1 IDLE ANIMATION"), graphics, collision, "player", content, screenManager, new Vector2(0, 0))); //add player //alles x3 voor de x3
            specialTiles.Clear();
            gui = new GuiScreen(content, entitys["player"]);
        }

        public static int enemyCounter = 0;
        public static void addAlien(Vector2 pos)
        {
            entitys.Add($"alien{enemyCounter}", new Alien(content.Load<Texture2D>("Enemies/enemies x1"), pos, collision, $"alien{enemyCounter}"));
            enemyCounter++;
        }
        public static void addDroid(Vector2 pos)
        {
            entitys.Add($"droid{enemyCounter}", new Droid(content.Load<Texture2D>("Enemies/enemies x1"), pos ,collision, $"droid{enemyCounter}"));
            enemyCounter++;
        }
        public static void addSentinal(Vector2 pos)
        {
            entitys.Add($"sentinal{enemyCounter}", new Sentinal(content.Load<Texture2D>("Enemies/enemies x1"), pos, collision, $"sentinal{enemyCounter}"));
            enemyCounter++;
        }

        public void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            
            UpdateEntitys(gameTime);
            UpdateSpecialTiles(gameTime);
            gui.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            world.Draw(spriteBatch);
            DrawSpecialTiles(spriteBatch, gameTime);
            DrawEntitys(spriteBatch, gameTime);
            gui.Draw(gameTime, graphics, spriteBatch);
        }

        public void DrawSpecialTiles(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Entity e in specialTiles)
            {
                e.Draw(spriteBatch, graphicsDevice, gameTime);
            }
        }
        public void UpdateSpecialTiles(GameTime gameTime)
        {
            foreach (Entity e in specialTiles)
            {
                e.Update(gameTime);
            }
        }

        public void DrawEntitys(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (KeyValuePair<string, Entity> e in entitys)
            {
                e.Value.Draw(spriteBatch, graphicsDevice, gameTime);
            }
        }

        public void UpdateEntitys(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Entity> e in entitys)
            {
                e.Value.Update(gameTime);
            }
        }
    }
}
