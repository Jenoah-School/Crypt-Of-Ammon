using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestLevelJenoah1 : Level
{
    public TestLevelJenoah1() : base("Assets/Sprites/Backgrounds/thumbnail.png")
    {
        backgroundImage.scale = 1f;

        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height - 12), game.width, 48, false, true, float.PositiveInfinity, 0f);
        Entity leftPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5.35f, game.height / 2), 416, 32, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceSlope = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5.85f, game.height / 2 + 54), 416, 32, false, true, float.PositiveInfinity, 0f);
        Entity centerPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2 + 96), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightCenterPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2 + 312, game.height / 2 - 96), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.11f, game.height / 2 + 256), 256, 148, false, true, float.PositiveInfinity, 0f);
        Entity rightSlope = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.38f, game.height - 42), 312, 148, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(16, game.height / 2), 32, game.height, false, true, float.PositiveInfinity, 0f);
        //Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5f, game.height / 2 - 64f), 48, -1, true, true, 1, 0);
        Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.2f, game.height / 2 - 64f), 48, -1, true, true, 1, 0);

        Trigger pressurePlate1 = new Trigger("Assets/Sprites/square.png", new Vec2(game.width / 1.1f, rightPiece.position.y - rightPiece.height / 2f), 64, 8);
        player = new Player(new Vec2(game.width / 2, game.height / 2), 64, 127);

        pushBox.SetColor(1f, .9f, 0.3f);
        pressurePlate1.SetColor(1f, .6f, 0.3f);

        rightSlope.rotation = 330f;
        leftPieceSlope.rotation = 165f;

        rightSlope.ignoreColliders.Add(rightPiece.collider);
        rightSlope.ignoreColliders.Add(floor.collider);
        leftWall.ignoreColliders.Add(floor.collider);
        leftPiece.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftPiece.collider);

        pressurePlate1.ignoreColliders.Add(pushBox.collider);
        pressurePlate1.ignoreColliders.Add(player.collider);

        rightSlope._collisionEvent = new Action(() => Console.WriteLine(rightSlope._collidedObject.other.owner));

        sceneObjects.Add(floor);
        sceneObjects.Add(leftPiece);
        sceneObjects.Add(centerPiece);
        sceneObjects.Add(rightCenterPiece);
        sceneObjects.Add(rightPiece);
        sceneObjects.Add(rightSlope);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(leftPieceSlope);

        pressureTriggers.Add(pressurePlate1);
        pressureSenders.Add(pushBox);

        sceneObjects.Add(pushBox);
        sceneObjects.Add(player);
        sceneObjects.Add(pressurePlate1);

        pressurePlate1.SetTriggerEvent(new Action(() => pressurePlate1.SetColor(0.3f, 0.3f, 0.3f)));
        pressurePlate1.SetUntriggerEvent(new Action(() => pressurePlate1.SetColor(0.9f, 0.9f, 0.9f)));

        AddChild(floor);
        AddChild(leftPiece);
        AddChild(centerPiece);
        AddChild(rightCenterPiece);
        AddChild(rightPiece);
        AddChild(rightSlope);
        AddChild(leftWall);
        AddChild(leftPieceSlope);

        AddChild(pressurePlate1);
        AddChild(pushBox);
        AddChild(player);
    }
}
