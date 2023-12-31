using Force.Engine.ForceAll.StaticManager;
using System;

// PROPERTIES
SceneManager.ActualScene = 2;

// PROGRAM
if (SceneManager.ActualScene == 0)
{
    using var scene1 = new Force.Game.Examples.Platformer();
    scene1.Run();
}
else if (SceneManager.ActualScene == 1)
{
    using var scene1 = new Force.Game.Examples.Physics();
    scene1.Run();
}
else if (SceneManager.ActualScene == 2)
{
    using var scene1 = new Force.Game.GameScene();
    scene1.Run();
}