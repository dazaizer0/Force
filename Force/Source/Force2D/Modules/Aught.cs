using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.FMath;

namespace Force.Source.Force2D.Modules
{
    internal class Aught
    {
        // PROPERTIES
        public Vector2 Position;
        public float Rotation;
        public bool Enabled;

        public Aught(Vector2 position, float rotation, bool enabled)
        {
            Position = position;
            Enabled = enabled;
            Rotation = rotation;
        }
    }

    internal class ForceAught
    {
        // PROPERTIES
        public vector2float Position;
        public float Rotation;
        public bool Enabled;

        public ForceAught(vector2float position, float rotation, bool enabled)
        {
            Position = position;
            Rotation = rotation;
            Enabled = enabled;
        }
    }
}
