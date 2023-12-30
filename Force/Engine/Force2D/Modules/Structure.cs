using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Force.Engine.Force2D.Modules
{
    internal class Structure : Aught
    {
        // PROPERTIES
        public Texture2D Texture;
        public Color ObjectColor;
        public Vector2 PlayerMoveDirection;

        public float RotationSpeed = 1f;

        public Structure(Vector2 position, float rotation, Texture2D texture, Color object_color, bool enabled) :
            base(position, rotation, enabled)
        {
            Texture = texture;
            ObjectColor = object_color;
        }

        public void DrawThis(SpriteBatch spriteBatch)
        {
            if (Enabled)
            {
                spriteBatch.Draw(Texture,
                    Position,
                    null,
                    ObjectColor,
                    Rotation,
                    Vector2.Zero,
                    1.0f, SpriteEffects.None,
                    0f);
            }
        }

        public void GetStructureMoveDirection(Structure structure)
        {
            PlayerMoveDirection = Position - structure.Position;
            PlayerMoveDirection.Normalize();
        }

        public void LookAt(Vector2 target, GameTime gameTime)
        {
            Vector2 direction = target - Position;
            float target_rotation = (float)System.Math.Atan2(direction.Y, direction.X);

            Rotation = FMath.FMath.LerpAngle(Rotation, target_rotation, RotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
