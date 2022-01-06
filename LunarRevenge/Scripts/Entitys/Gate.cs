using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LunarRevenge.Scripts.Entitys
{
    enum GateState { Open, Closed, None };

    internal class Gate : Entity
    {

        public GateState CurrentGateState = GateState.Closed;
        private Vector2 postition = new Vector2(0, 0);
        TextureManager textureManager;
        private bool canUpdate = true;
        string key = "animated_smallgate_1";
        private bool openDoor = false;
        private bool closed = true;
        private bool doorOpen = false;

        public Gate(Texture2D texture, Vector2 pos, Collision collision, string name, TextureManager textureManager) : base(texture, collision, name)
        {
            this.postition = pos;
            this.textureManager = textureManager;

            startingX = 0;
            startingY = 672;
            width = 32;
            height = 32;
            frames = 11;
            currentX = startingX;
            duration = 150;
        }

        public override void Update(GameTime gameTime)
        {
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);

            if (Distance(LevelScreen.entitys["player"]) > 75)
            {
                openDoor = false;
            }
            else
            {
                openDoor = true;
            }

            if (!doorOpen)
            {
                collision.collisions.Add(new Rectangle((int)pos.X - 16, (int)pos.Y - 16, 32, 20));
            }

            updateTimer(gameTime);
            base.Update(gameTime);
        }

        float timer;
        private void updateTimer(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 0.08f)
            {
                timer -= 0.08f;
                canUpdate = true;
            }
        }

        public void openGate()
        {
            if(CurrentGateState.Equals(GateState.Closed))
            {
                CurrentGateState = GateState.Open;
                openDoor = true;
                // Animation for opening the gate

                // remove temporary collision
            }
            
        }

        public void closeGate()
        {
            if (CurrentGateState.Equals(GateState.Open))
            {
                CurrentGateState = GateState.Closed;
                openDoor = false;
                collision.world.rectangles.Add(new Rectangle(-16, -16, 32, 16));
                // Animation for closing the gate

                // Add temporary colission
            }
        }


        int frameCounter = 1;
        public override void Animation(GameTime gameTime)
        {
            if (canUpdate)
            {
                if (!openDoor && frameCounter > 1)
                {
                    frameCounter--;
                }
                else if (openDoor && frameCounter < 12)
                {
                    frameCounter++;
                }
                currentX = (frameCounter - 1) * 32;

                if (frameCounter == 12)
                {
                    doorOpen = true;
                }else { doorOpen = false;}
                canUpdate = false;
            }
        }
    }
}
