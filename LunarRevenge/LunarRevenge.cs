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
        World world;

        public LunarRevenge()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            entitys.Add(new Player(Content.Load<Texture2D>("Players/players blue x1"))); //add player //alles x3 voor de x3
        
            textureManager = new TextureManager(Content.Load<Texture2D>("tileset x1"), GraphicsDevice);
            world = new World(textureManager);
        }


        private double secondcounter = 0;
        protected override void Update(GameTime gameTime)
        {
            secondcounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondcounter >= 1d/60) //updating game at 60fps
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //ending to split layers
            spriteBatch.Begin();



            world.Draw(spriteBatch);
            foreach (Entity e in entitys)
            {
                e.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
