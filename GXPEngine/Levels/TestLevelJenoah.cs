using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestLevelJenoah : Level
{
    public TestLevelJenoah() : base("Assets/Sprites/Backgrounds/TempBackground.jpg")
    {
        Player tempEnt = new Player(new Vec2(game.width / 2, game.height / 2), 64);
        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height - 32), game.width - 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2(game.width - 32, game.height / 2), 64, game.height, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(32, game.height / 2), 64, game.height, false, true, float.PositiveInfinity, 0f);
        Entity centerPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2 + 128), 128, 32, false, true, float.PositiveInfinity, 0f);

        sceneObjects.Add(tempEnt);
        sceneObjects.Add(floor);
        sceneObjects.Add(rightWall);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(centerPiece);

        AddChild(tempEnt);
        AddChild(floor);
        AddChild(rightWall);
        AddChild(leftWall);
        AddChild(centerPiece);
    }
}
