using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
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
        private WorldLoader world;
        private TextureManager textureManager;
        ContentManager content;
        GraphicsDevice graphicsDevice;
        GraphicsDeviceManager graphics;
        private Collision collision;

        GuiScreen gui;

        public LevelScreen(ContentManager content, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            Init();
        }

        private void Init()
        {
            textureManager = new TextureManager(content.Load<Texture2D>("tileset x1"), content.Load<Texture2D>("Props and Items/props and items x1"), graphicsDevice);
            world = new WorldLoader(textureManager);
            collision = new Collision(world);
            entitys.Add("player", new Player(content.Load<Texture2D>("Players/players blue x1 IDLE ANIMATION"), graphics, collision, "player", content)); //add player //alles x3 voor de x3
            entitys.Add("enemy1", new ShooterEnemy(content.Load<Texture2D>("Enemies/enemies x1"), collision, "enemy1"));

            Vector2 v = new Vector2(500, 500);
            entitys.Add("gate1", new Gate(content.Load<Texture2D>("Props and Items/props and items x1"), v,  collision, "gate1"));

            gui = new GuiScreen(content, entitys["player"]);
        }

        public void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            UpdateEntitys(gameTime);
            gui.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            world.Draw(spriteBatch);
            DrawEntitys(spriteBatch, gameTime);
            gui.Draw(gameTime, graphics, spriteBatch);
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
