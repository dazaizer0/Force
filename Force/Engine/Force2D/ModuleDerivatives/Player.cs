using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Engine.Force2D.Modules;

namespace Force.Engine.Force2D.ModuleDerivatives
{
    internal class Player : PhysicsStructure
    {
        // PROPERTIES
        public float Speed;
        public float BaseSpeed;
        public float SprintSpeed;

        // JUMP PROPERTIES
        private bool IsJumping = false;
        private float JumpForce = 900f;
        private float JumpTime = 0f;
        private const float MaxJumpTime = 0.5f;
        public bool JumpEnable = true;

        public Vector2 MoveDirection;

        public Player(Vector2 position, float rotation, Texture2D texture, float speed, Color object_color, bool enabled) :
            base(position, rotation, texture, object_color, enabled)
        {
            BaseSpeed = speed;
            SprintSpeed = speed;
        }

        // COLLISIONS
        public bool DetectCollisionWith(Structure object1)
        {
            Rectangle rect1 = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            Rectangle rect2 = new Rectangle((int)object1.Position.X, (int)object1.Position.Y, object1.Texture.Width, object1.Texture.Height);

            return rect1.Intersects(rect2) == true;
        }

        public void PlatformerCollideWith(Structure other, GameTime gameTime)
        {
            if (FMath.FMath.Abs(this.Position.Y - other.Position.Y) < 10)
            {
                Position -= other.PlayerMoveDirection * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                if (this.Position.Y > other.Position.Y - this.Texture.Height)
                {
                    this.JumpEnable = true;
                    this.Position.Y = other.Position.Y - this.Texture.Height;
                }
            }
        }

        public void SimpleCollideWith(Structure other, GameTime gameTime)
        {
            Position -= other.PlayerMoveDirection * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void AutomaticGetOn(Structure other, GameTime gameTime)
        {
            Position -= other.PlayerMoveDirection * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.Position.Y > other.Position.Y - this.Texture.Height)
            {
                this.JumpEnable = true;
                this.Position.Y = other.Position.Y - this.Texture.Height;
            }
        }

        public void AcceleratePlatformMovement(GameTime gameTime)
        {
            var keyboard_state = Keyboard.GetState();

            if (keyboard_state.IsKeyDown(Keys.D))
            {
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(1, 0);
            }

            if (keyboard_state.IsKeyDown(Keys.A))
            {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(-1, 0);
            }

            if (keyboard_state.IsKeyDown(Keys.Space) && JumpEnable && !IsJumping)
            {
                IsJumping = true;
                JumpTime = 0f;
            }

            if (IsJumping)
            {
                JumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (JumpTime < MaxJumpTime)
                {
                    Position += new Vector2(0, -JumpForce * (1 - JumpTime / MaxJumpTime)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    IsJumping = false;
                    JumpEnable = false;
                }
            }

            if (keyboard_state.IsKeyDown(Keys.LeftShift))
            {
                Speed = SprintSpeed;
            }
            else
            {
                Speed = BaseSpeed;
            }
        }

        public void AccelerateTopDownMovement(GameTime gameTime)
        {
            var keyboard_state = Keyboard.GetState();

            if (keyboard_state.IsKeyDown(Keys.D))
            {
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(1, 0);
            }

            else if (keyboard_state.IsKeyDown(Keys.A))
            {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(-1, 0);
            }

            else if (keyboard_state.IsKeyDown(Keys.W))
            {
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(0, -1);
            }

            else if (keyboard_state.IsKeyDown(Keys.S))
            {
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                MoveDirection = new Vector2(0, 1);
            }

            if (keyboard_state.IsKeyDown(Keys.LeftShift))
            {
                Speed = SprintSpeed;
            }
            else
            {
                Speed = BaseSpeed;
            }
        }
    }
}
