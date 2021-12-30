using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content
{
    internal class ScreenManager
    {
        public enum ScreenStates
        {
            home,
            level,
            paused,
        }

        private List<Entity> entitys = new List<Entity>();
        private TextureManager textureManager;

        Entity player;
        private WorldLoader world;
        private StartScreen startScreen;
        private KeyBinding keyBinding;
        private PauseScreen pauseScreen;



        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;



        public ScreenStates state = ScreenStates.home;

        public ScreenManager(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.graphics = graphics;
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            init();
        }

        private void init()
        {
            startScreen = new StartScreen(this);
            keyBinding = new KeyBinding();
            pauseScreen = new PauseScreen(this);



            textureManager = new TextureManager(content.Load<Texture2D>("tileset x1"), content.Load<Texture2D>("Props and Items/props and items x1"), graphicsDevice);
            world = new WorldLoader(textureManager);
            entitys.Add(new Player(content.Load<Texture2D>("Players/players blue x1"), world, graphics)); //add player //alles x3 voor de x3
        }

        public void changeState(ScreenStates states)
        {
            state = states;
        }

        public void Update(GameTime gameTime)
        {
            keyBinding.Update(this, graphics);

            if (state == ScreenStates.home)
            {
                startScreen.Update();
            }else if (state == ScreenStates.level)
            {
                foreach (Entity e in entitys)
                {
                    e.Update(gameTime);
                }
                world.Update(gameTime);
            }else if (state == ScreenStates.paused)
            {

            }
        }

        

        public void Draw(GameTime gameTime)
        {
            if (state == ScreenStates.home)
            {
                startScreen.Draw(graphicsDevice, spriteBatch);
            }
            else if (state == ScreenStates.level)
            {
                world.Draw(spriteBatch);
                foreach (Entity e in entitys)
                {
                    e.Draw(spriteBatch, graphicsDevice, gameTime);
                }

            }
            else if (state == ScreenStates.paused)
            {
                pauseScreen.Draw(graphicsDevice, spriteBatch);
            }
        }
    }
}
