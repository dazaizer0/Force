using Force.Engine.ForceAll.StaticManager;

// PROPERTIES
using var scene1 = new Force.Game.Examples.Platformer();
SceneManager.ActualScene = 0;

// PROGRAM
if (SceneManager.ActualScene == 0)
    scene1.Run();