using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestLevelJenoah : Level
{
    public TestLevelJenoah() : base("Assets/Sprites/Backgrounds/TempBackground.jpg")
    {
        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2 + 128, game.height - 32), game.width - 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2(game.width - 32, game.height / 2), 64, game.height, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(32, game.height / 2), 64, game.height, false, true, float.PositiveInfinity, 0f);
        Entity centerPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2 + 128), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.25f, game.height / 2), 128, 32, false, true, float.PositiveInfinity, 0f);

        Trigger pressurePlate1 = new Trigger("Assets/Sprites/square.png", new Vec2(game.width / 1.2f, game.height - 64), 64, 8);

        Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.25f, game.height / 2 - 64f), 32, -1, true, true, 3, 0);
        Player player = new Player(new Vec2(game.width / 2, game.height / 2), 64);

        player.SetColor(0.1f, 0.8f, 0.7f);
        pushBox.SetColor(1f, .9f, 0.3f);
        pressurePlate1.SetColor(.9f, .9f, .9f);

        floor.ignoreColliders.Add(rightWall.collider);
        rightPiece.ignoreColliders.Add(rightWall.collider);
        pressurePlate1.ignoreColliders.Add(player.collider);

        pressurePlate1.SetTriggerEvent(new Action(() => pressurePlate1.SetColor(0.3f, 0.3f, 0.3f)));
        pressurePlate1.SetUntriggerEvent(new Action(() => pressurePlate1.SetColor(0.9f, 0.9f, 0.9f)));

        sceneObjects.Add(floor);
        sceneObjects.Add(rightWall);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(centerPiece);
        sceneObjects.Add(rightPiece);

        sceneObjects.Add(pushBox);
        sceneObjects.Add(pressurePlate1);
        sceneObjects.Add(player);

        pressureTriggers.Add(pressurePlate1);
        pressureSenders.Add(pushBox);

        AddChild(floor);
        AddChild(rightWall);
        AddChild(leftWall);
        AddChild(centerPiece);
        AddChild(rightPiece);

        AddChild(pushBox);
        AddChild(pressurePlate1);
        AddChild(player);
    }
}
