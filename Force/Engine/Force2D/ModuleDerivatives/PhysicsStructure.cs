using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Engine.Force2D.Modules;

namespace Force.Engine.Force2D.ModuleDerivatives
{
    internal class PhysicsStructure : Structure
    {
        // PROPERTIES
        public float Mass { get; set; }
        public float Radius { get; set; }
        public Vector2 Velocity { get; set; }

        public PhysicsStructure(Vector2 position, float rotation, Texture2D texture, Color object_color, bool enabled) :
            base(position, rotation, texture, object_color, enabled)
        {

        }

        public void SimplePhysics(GameTime gameTime, Vector2 gravity)
        {
            Position += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds * new Vector2(Mass, Mass);
        }

        public void ApplyGravity(PhysicsStructure other, float gravitationalConstant)
        {
            if (!CheckCollision(other))
            {
                Vector2 direction = other.Position - Position;
                float distance = direction.Length();

                if (distance == 0)
                    return;

                float forceMagnitude = gravitationalConstant * Mass * other.Mass / (distance * distance);
                Vector2 force = direction * (forceMagnitude / distance);

                ApplyForce(force);
            }
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public bool CheckCollision(PhysicsStructure other)
        {
            float distance = Vector2.Distance(Position, other.Position);
            float sumRadii = Radius + other.Radius;

            return distance < sumRadii;
        }
        public bool IfCollision(PhysicsStructure object1)
        {
            Rectangle rect1 = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            Rectangle rect2 = new Rectangle((int)object1.Position.X, (int)object1.Position.Y, object1.Texture.Width, object1.Texture.Height);

            return rect1.Intersects(rect2) == true;
        }

        public void ApplyForce(Vector2 force)
        {
            Velocity += force / Mass;
        }
    }
}
