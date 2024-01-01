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

        private bool Moving;

        public MovingStructure(Vector2 position, float speed, float rotation, Texture2D texture, Color object_color, bool enabled) :
            base(position, rotation, texture, object_color, enabled)
        {
            Speed = speed;
        }

        public void Move(GameTime gameTime)
        {
            this.Position += Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void MoveAlongX(GameTime gameTime, int xPos1, int xPos2)
        {
            if (this.Position.X < xPos1)
                this.Direction = new Vector2(this.Speed, 0);
            if (this.Position.X > xPos2)
                this.Direction = new Vector2(-this.Speed, 0);

            this.Position += Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}