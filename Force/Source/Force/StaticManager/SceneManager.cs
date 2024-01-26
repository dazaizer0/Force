using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Game.Examples;

namespace Force.Source.Force.SceneManager
{
    static class SceneManager
    {
        /// <summary>
        /// ActualScene = Running Scene Index (now)(0-3)
        /// </summary>

        public static int ActualScene;

        public static void ChangeScene()
        {
            if (ActualScene == 0)
            {
                using var actualGameScene = new Platformer();
                actualGameScene.Run();
            }

            if (ActualScene == 1)
            {
                using var actualGameScene = new Physics();
                actualGameScene.Run();
            }

            if (ActualScene == 2)
            {
                using var actualGameScene = new TopDown();
                actualGameScene.Run();
            }

            if (ActualScene == 3)
            {
                using var actualGameScene = new TopDown2();
                actualGameScene.Run();
            }
        }
    }
}