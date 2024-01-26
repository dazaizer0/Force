using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Media;

namespace Force.Source.Force.Audio
{
    internal class ForceSongPlayer
    {
        public Song SongAudio;
        public bool AudioPlaying { get; private set; }

        public void Play()
        {
            if (!this.AudioPlaying)
            {
                MediaPlayer.Play(this.SongAudio);
                this.AudioPlaying = true;
            }
        }
    }
}