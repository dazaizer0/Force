using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Force.Source.Force2D.FMath
{
    // FORCE MATH 
    internal class FMath
    {
        // FORCE LERP ANGLE
        public static float LerpAngle(float from, float to, float amount)
        {
            from = (from + MathHelper.TwoPi) % MathHelper.TwoPi;
            to = (to + MathHelper.TwoPi) % MathHelper.TwoPi;

            float result = from + (to - from) * amount;
            result = (result + MathHelper.TwoPi) % MathHelper.TwoPi;

            return result;
        }

        // FORCE ABS
        public static float Abs(float number)
        {
            return (number < 0) ? -number : number;
        }

        public static Vector2 ConvertMovingVectorToGridVector(Vector2 screenPosition, int gridSize, Matrix inverseCameraTransform)
        {
            Vector2 worldPosition = Vector2.Transform(screenPosition, inverseCameraTransform);

            Vector2 gridPosition = new Vector2(
                (float)Math.Floor(worldPosition.X / gridSize) * gridSize,
                (float)Math.Floor(worldPosition.Y / gridSize) * gridSize
            );

            return gridPosition;
        }

        public static Vector2 ConvertVectorToGridVector(Vector2 vector, int gridSize)
        {
            Vector2 gridPosition = new Vector2(
                (float)Math.Floor(vector.X / gridSize) * gridSize,
                (float)Math.Floor(vector.Y / gridSize) * gridSize
            );

            return gridPosition;
        }
    }
}
