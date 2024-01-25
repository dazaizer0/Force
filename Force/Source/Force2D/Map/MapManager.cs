using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.Modules;

namespace Force.Engine.Force2D.Map
{
    internal class MapManager : Aught
    {
        // PROPERTIES
        public Vector2 Size;
        public int GridSize;
        public string Path;

        public MapManager(Vector2 position, float rotation, bool enabled) : base(position, rotation, enabled)
        {

        }

        public void GenerateMap()
        {

        }

        public void DrawMap(SpriteBatch spriteBatch)
        {

        }
    }
}
