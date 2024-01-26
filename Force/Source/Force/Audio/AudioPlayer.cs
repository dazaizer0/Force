using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;

namespace Force.Source.Force.Audio
{
    internal class AudioPlayer
    {
        public SoundEffect Audio { get; set; }

        private SoundEffectInstance AudioInstance { get; set; }
        public bool AudioPlaying { get; private set; }

        public void Initialize()
        {
            AudioInstance = Audio.CreateInstance();
        }

        public void Play()
        {
            if (AudioInstance != null)
            {
                AudioInstance.Play();
                AudioPlaying = true;
            }
        }

        public void Stop()
        {
            if (AudioInstance != null && AudioPlaying)
            {
                AudioInstance.Stop();
                AudioPlaying = false;
            }
        }
    }
}