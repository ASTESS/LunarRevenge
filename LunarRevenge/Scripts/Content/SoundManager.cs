using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace LunarRevenge.Scripts.Content
{
    public class SoundManager
    {
        public List<SoundEffect> sfx;

        public SoundManager(ContentManager content)
        {
            sfx = new List<SoundEffect>();
            loadSounds(content);
        }

        public void loadSounds(ContentManager content)
        {
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_1"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_2"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_3"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_4"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_5"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_6"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_7"));
            sfx.Add(content.Load<SoundEffect>("Sound/Player/footstep_8"));
        }

        public void PlaySound(string sound)
        {
            int index = sfx.FindIndex(a => a.Name.Equals(sound));
        }


    }
}
