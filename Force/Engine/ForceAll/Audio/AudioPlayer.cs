using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;

namespace Force.Engine.ForceAll.Audio
{
    internal class AudioPlayer
    {
        public SoundEffect Audio;

        public void Play()
        {
            Audio.Play();
        }
    }
}
