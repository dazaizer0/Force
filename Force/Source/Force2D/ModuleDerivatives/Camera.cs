using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.Modules;

namespace Force.Source.Force2D.ModuleDerivatives
{
    internal class Camera : Aught
    {
        // PROPERTIES
        public Matrix Transform { get; private set; }
        public Vector2 CenterProperties;
        public Vector2 ActualCenterPosition;
        private Viewport Viewport;
        private float Zoom;

        public float ShakeDuration = 0;
        public float ShakeIntensity = 10.0f;

        public Vector2 OriginalPosition;
        public Random CameraRandom;

        public Camera(Vector2 position, float rotation, Viewport viewport, float zoom, bool enabled) :
            base(position, rotation, enabled)
        {
            Viewport = viewport;
            Zoom = zoom;
            CameraRandom = new Random();
        }

        public void Fallow(Vector2 targetVector2, GameTime gameTime)
        {
            OriginalPosition = new Vector2(targetVector2.X - Viewport.Width / 2, targetVector2.Y - Viewport.Height / 2);

            if (ShakeDuration > 0)
            {
                float xOffset = (float)(CameraRandom.NextDouble() * 2 - 1) * ShakeIntensity;
                float yOffset = (float)(CameraRandom.NextDouble() * 2 - 1) * ShakeIntensity;

                OriginalPosition += new Vector2(xOffset, yOffset);

                ShakeDuration -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            Position = OriginalPosition;

            Transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                        Matrix.CreateScale(Zoom, Zoom, 1) *
                        Matrix.CreateTranslation(new Vector3(Viewport.Width / 2, Viewport.Height / 2, 0));

            ActualCenterPosition = this.Position + this.CenterProperties;
        }

        public void Shake(float duration, float intensity)
        {
            ShakeDuration = duration;
            ShakeIntensity = intensity;
            OriginalPosition = Position;
        }
    }
}
