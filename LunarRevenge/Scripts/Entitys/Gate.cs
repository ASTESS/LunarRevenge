﻿using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LunarRevenge.Scripts.Entitys
{
    enum GateState { Open, Closed };

    internal class Gate : Entity
    {

        public GateState CurrentGateState = GateState.Closed;
        private Vector2 postition = new Vector2(0, 0);
        TextureManager textureManager;
        private bool canUpdate = true;
        private bool doorOpen = true;
        string key = "animated_smallgate_1";

        public Gate(Texture2D texture, Vector2 pos, Collision collision, string name, TextureManager textureManager) : base(texture, collision, name)
        {
            this.health = 50;
            speed = 1f;
            this.postition = pos;
            this.textureManager = textureManager;
        }

        public override void Update(GameTime gameTime)
        {
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);

            if (Distance(LevelScreen.entitys["player"]) > 75)
            {
                closeGate();
            }
            else
            {
                openGate();
            }

            updateTimer(gameTime);
            base.Update(gameTime);
        }

        float timer;
        private void updateTimer(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 0.5f)
            {
                timer -= 0.5f;
                canUpdate = true;
            }
        }

        public void openGate()
        {
            if(CurrentGateState.Equals(GateState.Closed))
            {
                CurrentGateState = GateState.Open;
                Console.WriteLine("open");

                // Animation for opening the gate

                // remove temporary collision

            }
            
        }

        public void closeGate()
        {
            if (CurrentGateState.Equals(GateState.Open))
            {
                CurrentGateState = GateState.Closed;
                Console.WriteLine("closed");

                // Animation for closing the gate

                // Add temporary colission

            }
        }



        public void _Animation(GameTime gameTime)
        {
            startingY = 672;
            width = 32;
            height = 32;
            frames = 12;
            currentX = startingX;
            duration = 150;

            if (canUpdate)
            {
                string[] split = key.Split('_');
                int number = Convert.ToInt32(split[split.Length - 1]);

                if (number == 12)
                {
                    doorOpen = true;
                }
                else if (number == 1)
                {
                    doorOpen = false;
                }
                if (doorOpen)
                {
                    number--;
                }
                else if (!doorOpen)
                {
                    number++;
                }

                string newItem = "";
                for (int i = 0; i < split.Length - 1; i++)
                {
                    newItem += split[i];
                    newItem += '_';
                }

                Console.WriteLine(newItem);

                string test = newItem + number.ToString();
                if (textureManager.worldTextures.ContainsKey(test))
                {
                    newItem += number.ToString();
                }
                key = newItem;
                startingX = number * 32;
                canUpdate = false;
            }
        }
    }
}
