using System;

class TestLevelJenoah1 : Level
{
    Background background;
    public TestLevelJenoah1()
    {
        //backgroundImage.scale = 1f;
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/thumbnail.png" });
        currentLevelSize = new Vec2(1280, game.height);
        

        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height - 16), game.width, 48, false, true, float.PositiveInfinity, 0f);
        Entity leftFloorBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 13.75f, game.height - 48), 156, 24, false, true, float.PositiveInfinity, 0f);
        Entity leftPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5.35f, game.height / 2), 416, 32, false, true, float.PositiveInfinity, 0f);
        Entity leftBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 20f, game.height / 2 - 30), 64, 24, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceSlope = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5.85f, game.height / 2 + 54), 416, 32, false, true, float.PositiveInfinity, 0f);
        Entity centerPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2 + 112), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightCenterPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2 + 320, game.height / 2 - 90), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.11f, game.height / 2 + 252), 256, 148, false, true, float.PositiveInfinity, 0f);
        Entity rightSlope = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.41f, game.height + 20), 312, 148, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(8, game.height / 2), 16, game.height, false, true, float.PositiveInfinity, 0f);
        Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5f, game.height / 2 - 64f), 48, -1, true, true, 1, 0);
        //Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 1.3f, game.height / 2 - 136f), 48, -1, true, true, 1, 0);

        //floor.visible = false;
        //leftFloorBlockPiece.visible = false;
        //leftWall.visible = false;
        //leftPiece.visible = false;
        //leftPieceSlope.visible = false;
        //rightCenterPiece.visible = false;
        //centerPiece.visible = false;
        //rightSlope.visible = false;
        //rightPiece.visible = false;

        Trigger pressurePlate1 = new Trigger("Assets/Sprites/square.png", new Vec2(game.width / 1.1f, rightPiece.position.y - rightPiece.height / 2f), 64, 8);
        player = new Player(new Vec2(game.width / 2, game.height / 2), 64, 127);

        pushBox.SetColor(1f, .9f, 0.3f);
        pressurePlate1.SetColor(1f, .6f, 0.3f);

        rightSlope.rotation = 330f;
        leftPieceSlope.rotation = 165f;

        rightSlope.ignoreColliders.Add(rightPiece.collider);
        rightSlope.ignoreColliders.Add(floor.collider);
        rightPiece.ignoreColliders.Add(floor.collider);
        leftFloorBlockPiece.ignoreColliders.Add(floor.collider);
        leftFloorBlockPiece.ignoreColliders.Add(leftWall.collider);
        leftWall.ignoreColliders.Add(floor.collider);
        leftPiece.ignoreColliders.Add(leftWall.collider);
        leftPiece.ignoreColliders.Add(leftBlockPiece.collider);
        leftBlockPiece.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftPiece.collider);

        pressurePlate1.ignoreColliders.Add(pushBox.collider);
        pressurePlate1.ignoreColliders.Add(player.collider);
        
        sceneObjects.Add(floor);
        sceneObjects.Add(leftFloorBlockPiece);
        sceneObjects.Add(leftPiece);
        sceneObjects.Add(centerPiece);
        sceneObjects.Add(rightCenterPiece);
        sceneObjects.Add(rightPiece);
        sceneObjects.Add(rightSlope);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(leftPieceSlope);
        sceneObjects.Add(leftBlockPiece);

        pressureTriggers.Add(pressurePlate1);
        pressureSenders.Add(pushBox);

        sceneObjects.Add(pushBox);
        sceneObjects.Add(player);
        sceneObjects.Add(pressurePlate1);

        pressurePlate1.SetTriggerEvent(new Action(() => pressurePlate1.SetColor(0.3f, 0.3f, 0.3f)));
        pressurePlate1.SetUntriggerEvent(new Action(() => pressurePlate1.SetColor(0.9f, 0.9f, 0.9f)));

        AddChild(background);
        AddChild(floor);
        AddChild(leftFloorBlockPiece);
        AddChild(leftPiece);
        AddChild(centerPiece);
        AddChild(rightCenterPiece);
        AddChild(rightPiece);
        AddChild(rightSlope);
        AddChild(leftWall);
        AddChild(leftPieceSlope);
        AddChild(leftBlockPiece);

        AddChild(pressurePlate1);
        AddChild(pushBox);
        AddChild(player);
        AddChild(cam);

        cam.SetXY(game.width / 1.25f, game.height / 2f);
        cam.scale *= 0.65f;
    }

    public override void SetCameraPosition()
    {
        Vec2 lerp = Vec2.Lerp(new Vec2(cam.x, cam.y), new Vec2(player.x + (game.width / 2.19f), 534), 0.9f);

        if (player.x > 900 && player.x < (currentLevelSize.x - 900))
        {
            cam.SetXY(lerp.x, lerp.y);
        }
        else
        {
            cam.SetXY(cam.x, lerp.y);
        }
    }
}
