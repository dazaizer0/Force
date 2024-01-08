using Force.Engine.ForceAll.StaticManager;
using System;

// PROPERTIES
SceneManager.ActualScene = 0;

// PROGRAM
if (SceneManager.ActualScene == 0)
{
    using var actualGameScene = new Force.Game.Examples.Platformer();
    actualGameScene.Run();
}
else if (SceneManager.ActualScene == 1)
{
    using var actualGameScene = new Force.Game.Examples.Physics();
    actualGameScene.Run();
}
else if (SceneManager.ActualScene == 2)
{
    using var actualGameScene = new Force.Game.Examples.TopDown();
    actualGameScene.Run();
}
else if (SceneManager.ActualScene == 3)
{
    using var actualGameScene = new Force.Game.Examples.TopDown2();
    actualGameScene.Run();
}