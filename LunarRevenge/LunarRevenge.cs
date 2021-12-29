using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LunarRevenge
{
    public class LunarRevenge : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<Entity> entitys = new List<Entity>();
        private TextureManager textureManager;

        Entity player;
        private WorldLoader world;

        public LunarRevenge()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic 
            IsFixedTimeStep = false; //fix's lag after a few minutes
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        
            textureManager = new TextureManager(Content.Load<Texture2D>("tileset x1"), Content.Load<Texture2D>("Props and Items/props and items x1"), GraphicsDevice);
            world = new WorldLoader(textureManager);
            entitys.Add(new Player(Content.Load<Texture2D>("Players/players blue x1"), world, graphics)); //add player //alles x3 voor de x3
        }


        private double secondcounter = 0;
        protected override void Update(GameTime gameTime)
        {
            secondcounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondcounter >= 1d/60) //updating game at 60fps
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                if (Keyboard.GetState().IsKeyDown(Keys.F))
                {
                    graphics.ToggleFullScreen();

                    //graphics.ApplyChanges();
                }

                foreach (Entity e in entitys)
                {
                    e.Update(gameTime);
                }

                world.Update(gameTime);
                secondcounter = 0;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //ending to split layers
            spriteBatch.Begin();



            world.Draw(spriteBatch);
            foreach (Entity e in entitys)
            {
                e.Draw(spriteBatch, GraphicsDevice, gameTime);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
