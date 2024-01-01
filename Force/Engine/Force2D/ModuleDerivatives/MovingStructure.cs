using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Engine.Force2D.Modules;

namespace Force.Engine.Force2D.ModuleDerivatives
{
    internal class MovingStructure : Structure
    {
        public Vector2 Direction;
        public float Speed;

        public MovingStructure(Vector2 position, float rotation, Texture2D texture, Color object_color, bool enabled) :
            base(position, rotation, texture, object_color, enabled)
        {
        }

        public void Move(GameTime gameTime)
        {
            this.Position += Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}