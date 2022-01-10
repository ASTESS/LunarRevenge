using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LunarRevenge.Scripts.World.Textures
{
    class TextureManager
    {

        public Dictionary<string, Texture2D> worldTextures = new Dictionary<string, Texture2D>();
        private Texture2D texture;
        private Texture2D props;
        private GraphicsDevice graphicsDevice;

        public TextureManager(Texture2D texture, Texture2D props, GraphicsDevice graphics)
        {
            this.texture = texture;
            this.graphicsDevice = graphics;
            this.props = props;

            // Texture Explaination:
            // new Rectangle(x, y, z1, z2)
            // x = X Coordinate of LeftTop of the texture
            // y = Y Coordinate of LeffTop of the texture
            // z1 and z2 = The texture size (example: 32x32 => 32)

            // Floor Textures
            worldTextures.Add("floor", GetTile(new Rectangle(1088, 32, 32, 32)));
            worldTextures.Add("floor_2", GetTile(new Rectangle(1056, 32, 32, 32)));
            worldTextures.Add("floor_3", GetTile(new Rectangle(1024, 64, 32, 32)));
            worldTextures.Add("floor_vent", GetTile(new Rectangle(1024, 32, 32, 32)));
            worldTextures.Add("floor_vent_2", GetTile(new Rectangle(1152, 32, 32, 32)));
            worldTextures.Add("acid", GetTile(new Rectangle(1120, 96, 32, 32)));
            worldTextures.Add("acid_2", GetTile(new Rectangle(1120, 64, 32, 32)));

            // Wall Textures
            worldTextures.Add("wall", GetTile(new Rectangle(160, 0, 32, 32)));
            worldTextures.Add("wall_1", GetTile(new Rectangle(64, 0, 32, 32)));
            worldTextures.Add("wall_2", GetTile(new Rectangle(256, 0, 32, 32)));
            worldTextures.Add("wall_3", GetTile(new Rectangle(128, 0, 32, 32)));
            worldTextures.Add("wall_4", GetTile(new Rectangle(192, 0, 32, 32)));
            worldTextures.Add("wall_5", GetTile(new Rectangle(128, 288, 32, 32)));
            worldTextures.Add("wall_6", GetTile(new Rectangle(192, 288, 32, 32)));
            worldTextures.Add("wall_7", GetTile(new Rectangle(128, 32, 32, 32)));
            worldTextures.Add("wall_8", GetTile(new Rectangle(192, 32, 32, 32)));
            worldTextures.Add("wall_9", GetTile(new Rectangle(384, 96, 32, 32)));
            worldTextures.Add("wall_10", GetTile(new Rectangle(448, 224, 32, 32)));
            worldTextures.Add("wall_11", GetTile(new Rectangle(64, 320, 32, 32)));
            worldTextures.Add("wall_12", GetTile(new Rectangle(256, 320, 32, 32)));
            worldTextures.Add("wall_13", GetTile(new Rectangle(128, 320, 32, 32)));
            worldTextures.Add("wall_14", GetTile(new Rectangle(192, 0, 32, 32)));
            worldTextures.Add("wall_15", GetTile(new Rectangle(448, 64, 32, 32)));
            worldTextures.Add("wall_16", GetTile(new Rectangle(384, 192, 32, 32)));
            worldTextures.Add("wall_17", GetTile(new Rectangle(448, 32, 32, 32)));
            worldTextures.Add("wall_18", GetTile(new Rectangle(384, 160, 32, 32)));
            worldTextures.Add("wall_19", GetTile(new Rectangle(288, 224, 32, 32)));
            worldTextures.Add("wall_20", GetTile(new Rectangle(32, 224, 32, 32)));
            worldTextures.Add("wall_side", GetTile(new Rectangle(32, 64, 32, 32)));
            worldTextures.Add("wall_side_1", GetTile(new Rectangle(288, 64, 32, 32)));
            worldTextures.Add("wall_side_2", GetTile(new Rectangle(64, 288, 32, 32)));
            worldTextures.Add("wall_side_3", GetTile(new Rectangle(256, 288, 32, 32)));
            worldTextures.Add("wall_side_4", GetTile(new Rectangle(32, 128, 32, 32)));
            worldTextures.Add("wall_side_5", GetTile(new Rectangle(288, 128, 32, 32)));
            worldTextures.Add("wall_side_6", GetTile(new Rectangle(32, 96, 32, 32)));
            worldTextures.Add("wall_side_7", GetTile(new Rectangle(288, 96, 32, 32)));
            worldTextures.Add("wall_side_8", GetTile(new Rectangle(64, 32, 32, 32)));
            worldTextures.Add("wall_side_9", GetTile(new Rectangle(256, 32, 32, 32)));


            // Wall Decoration Textures
            worldTextures.Add("wall_yellow_stripe", GetTile(new Rectangle(161, 384, 32, 32)));


            // New Prop Textures
            worldTextures.Add("stain", GetProp(new Rectangle(0, 32, 32, 32)));
            worldTextures.Add("stain_1", GetProp(new Rectangle(32, 32, 32, 32)));
            worldTextures.Add("stain_2", GetProp(new Rectangle(96, 32, 32, 32)));
            worldTextures.Add("stain_3", GetProp(new Rectangle(128, 32, 32, 32)));
            worldTextures.Add("capsule_empty_top", GetProp(new Rectangle(1, 320, 32, 32)));
            worldTextures.Add("capsule_empty_bottom", GetProp(new Rectangle(1, 352, 32, 32)));

            // Animated Prop Textures
            worldTextures.Add("animated_smallgate_1", GetProp(new Rectangle(0, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_2", GetProp(new Rectangle(32, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_3", GetProp(new Rectangle(64, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_4", GetProp(new Rectangle(96, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_5", GetProp(new Rectangle(128, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_6", GetProp(new Rectangle(160, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_7", GetProp(new Rectangle(192, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_8", GetProp(new Rectangle(224, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_9", GetProp(new Rectangle(256, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_10", GetProp(new Rectangle(288, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_11", GetProp(new Rectangle(320, 672, 32, 32)));
            worldTextures.Add("animated_smallgate_12", GetProp(new Rectangle(352, 672, 32, 32)));

            worldTextures.Add("animated_capsule_empty_top_1", GetProp(new Rectangle(1, 256, 32, 32)));
            worldTextures.Add("animated_capsule_empty_bottom_1", GetProp(new Rectangle(1, 288, 32, 32)));
            worldTextures.Add("animated_capsule_empty_top_2", GetProp(new Rectangle(65, 256, 32, 32)));
            worldTextures.Add("animated_capsule_empty_bottom_2", GetProp(new Rectangle(65, 288, 32, 32)));
            worldTextures.Add("animated_capsule_empty_top_3", GetProp(new Rectangle(97, 256, 32, 32)));
            worldTextures.Add("animated_capsule_empty_bottom_3", GetProp(new Rectangle(97, 288, 32, 32)));
            worldTextures.Add("animated_capsule_empty_top_4", GetProp(new Rectangle(129, 256, 32, 32)));
            worldTextures.Add("animated_capsule_empty_bottom_4", GetProp(new Rectangle(129, 288, 32, 32)));

            worldTextures.Add("animated_capsule_filled_top_1", GetProp(new Rectangle(1, 192, 32, 32)));
            worldTextures.Add("animated_capsule_filled_bottom_1", GetProp(new Rectangle(1, 224, 32, 32)));
            worldTextures.Add("animated_capsule_filled_top_2", GetProp(new Rectangle(65, 192, 32, 32)));
            worldTextures.Add("animated_capsule_filled_bottom_2", GetProp(new Rectangle(65, 224, 32, 32)));
            worldTextures.Add("animated_capsule_filled_top_3", GetProp(new Rectangle(97, 192, 32, 32)));
            worldTextures.Add("animated_capsule_filled_bottom_3", GetProp(new Rectangle(97, 224, 32, 32)));
            worldTextures.Add("animated_capsule_filled_top_4", GetProp(new Rectangle(129, 192, 32, 32)));
            worldTextures.Add("animated_capsule_filled_bottom_4", GetProp(new Rectangle(129, 224, 32, 32)));

            worldTextures.Add("animated_monitorscreen_left_1", GetProp(new Rectangle(0, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_right_1", GetProp(new Rectangle(32, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_left_2", GetProp(new Rectangle(96, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_right_2", GetProp(new Rectangle(128, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_left_3", GetProp(new Rectangle(160, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_right_3", GetProp(new Rectangle(192, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_left_4", GetProp(new Rectangle(224, 132, 32, 32)));
            worldTextures.Add("animated_monitorscreen_right_4", GetProp(new Rectangle(256, 132, 32, 32)));
        }

        /*
         * Note:
         * 
         * The following idea was used for deviding up the spritesheet in to smaller textures to build levels.
         * We got the idea from: https://gamedev.stackexchange.com/questions/35358/create-a-texture2d-from-larger-image.
         * 
         */

        public Texture2D GetProp(Rectangle box) 
        {
            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            props.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }

        public Texture2D GetTile(Rectangle box) 
        {
            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            texture.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }
    }
}
