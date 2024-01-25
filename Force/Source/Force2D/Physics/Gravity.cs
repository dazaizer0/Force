using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.ModuleDerivatives;
using Force.Source.Force2D.Modules;

namespace Force.Source.Force2D.Physics
{
    internal class Gravity
    {
        public static void ApplyGravity(PhysicsStructure object1, PhysicsStructure object2, float gravitationalConstant)
        {
            Vector2 direction = object2.Position - object1.Position;
            float distance = direction.Length();
            distance = MathHelper.Clamp(distance, object1.Radius, object2.Radius);

            float forceMagnitude = (gravitationalConstant * object1.Mass * object2.Mass) / (distance * distance);
            Vector2 force = direction * (forceMagnitude / distance);

            object1.ApplyForce(force);
            object2.ApplyForce(-force);
        }
    }
}
