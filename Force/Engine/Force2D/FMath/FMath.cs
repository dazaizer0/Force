using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Force.Engine.Force2D.FMath
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
    }
}
