using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Force.Engine.Force2D.FMath
{
    internal class FMath
    {
        public static float LerpAngle(float from, float to, float amount)
        {
            from = (from + MathHelper.TwoPi) % MathHelper.TwoPi;
            to = (to + MathHelper.TwoPi) % MathHelper.TwoPi;

            float result = from + (to - from) * amount;
            result = (result + MathHelper.TwoPi) % MathHelper.TwoPi;

            return result;
        }

        public static float Abs(float number)
        {
            return (number < 0) ? -number : number;
        }
    }
}
