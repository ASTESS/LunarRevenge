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
        public static List<Entity> acid = new List<Entity>();
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
            textureManager = new TextureManager(content.Load<Texture2D>("tileset x1"), content.Load<Texture2D>("Props and Items/props and items x1"), graphicsDevice);
            world = new WorldLoader(textureManager, level, content);
            collision = new Collision(world);

            entitys.Clear();
            entitys.Add("player", new Player(content.Load<Texture2D>("Players/players blue x1 IDLE ANIMATION"), graphics, collision, "player", content, screenManager)); //add player //alles x3 voor de x3
            entitys.Add("enemy1", new ShooterEnemy(content.Load<Texture2D>("Enemies/enemies x1"), collision, "enemy1"));
            Vector2 v = new Vector2(400, 500);
            entitys.Add("alien1", new Alien(content.Load<Texture2D>("Enemies/enemies x1"), v, collision, "alien1"));

            acid.Clear();


            gui = new GuiScreen(content, entitys["player"]);
        }

        public void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            
            UpdateEntitys(gameTime);
            UpdateAcid(gameTime);
            gui.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            world.Draw(spriteBatch);
            DrawAcid(spriteBatch, gameTime);
            DrawEntitys(spriteBatch, gameTime);
            gui.Draw(gameTime, graphics, spriteBatch);
        }

        public void DrawAcid(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Entity e in acid)
            {
                e.Draw(spriteBatch, graphicsDevice, gameTime);
            }
        }
        public void UpdateAcid(GameTime gameTime)
        {
            foreach (Entity e in acid)
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
