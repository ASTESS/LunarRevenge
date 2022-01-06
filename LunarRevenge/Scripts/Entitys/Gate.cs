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

        public override void Animation(GameTime gameTime)
        {
            startingY = 672;
            width = 32;
            height = 32;
            frames = 11;
            currentX = startingX;
            duration = 150;

            if (canUpdate)
            {
                string[] split = key.Split('_');
                int number = Convert.ToInt32(split[split.Length - 1]);

                if (!openDoor && number > 1)
                {
                    number--;
                }
                else if (openDoor && number < 12)
                {
                    number++;
                }

                if (number >= 12)
                {
                    doorOpen = true;
                }else { doorOpen = false;}

                string newItem = "";
                for (int i = 0; i < split.Length - 1; i++)
                {
                    newItem += split[i];
                    newItem += '_';
                }
                newItem += number.ToString();
                key = newItem;
                startingX = (number -1) * 32;
                canUpdate = false;
            }
        }
    }
}
