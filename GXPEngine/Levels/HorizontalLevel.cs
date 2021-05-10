using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HorizontalLevel : Level
{
    Background background;

    public HorizontalLevel()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_04.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_03.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_02.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_01.png" });
        currentLevelSize = new Vec2(7680, 2160);

        player = new Player(new Vec2(game.width / 2, game.height / 2), 128);
        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, currentLevelSize.y - 52), (int)currentLevelSize.x, 104, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity leftFloorBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 96, floor.y - floor.height / 2f - 32), 192, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 580, currentLevelSize.y / 2 - 36), 1160, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceSlope = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 560, currentLevelSize.y / 2 + 148), 1200, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 128, currentLevelSize.y / 2 - 96), 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerPiece = new Entity("Assets/Sprites/square.png", new Vec2(1916, currentLevelSize.y / 2f + 376), 384, 96, false, true, float.PositiveInfinity, 0f);
        //Entity rightCenterPiece = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2 + 320, game.height / 2 - 90), 128, 32, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(3586, currentLevelSize.y - 290), 1024, 512, false, true, float.PositiveInfinity, 0f);
        Entity rightSlope = new Entity("Assets/Sprites/square.png", new Vec2(2762, currentLevelSize.y - 69), 1024, 512, false, true, float.PositiveInfinity, 0f);
        //Entity pushBox = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 5f, game.height / 2 - 64f), 48, -1, true, true, 1, 0);

        rightSlope.rotation = 330;

        leftPieceSlope.rotation = 345;

        sceneObjects.Add(floor);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(leftFloorBlockPiece);
        sceneObjects.Add(leftPiece);
        sceneObjects.Add(leftPieceSlope);
        sceneObjects.Add(leftBlockPiece);
        sceneObjects.Add(centerPiece);
        sceneObjects.Add(rightPiece);
        sceneObjects.Add(rightSlope);

        //sceneObjects.Add(centerPiece);
        //sceneObjects.Add(rightCenterPiece);
        //sceneObjects.Add(leftBlockPiece);

        sceneObjects.Add(player);

        leftWall.ignoreColliders.Add(floor.collider);
        leftFloorBlockPiece.ignoreColliders.Add(floor.collider);
        leftWall.ignoreColliders.Add(leftFloorBlockPiece.collider);
        leftPiece.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftWall.collider);
        leftPiece.ignoreColliders.Add(leftPieceSlope.collider);
        leftBlockPiece.ignoreColliders.Add(leftWall.collider);
        leftBlockPiece.ignoreColliders.Add(leftPiece.collider);
        rightPiece.ignoreColliders.Add(floor.collider);
        rightSlope.ignoreColliders.Add(floor.collider);
        rightPiece.ignoreColliders.Add(rightSlope.collider);


        AddChild(background);
        AddChild(floor);
        AddChild(leftWall);
        AddChild(leftFloorBlockPiece);
        AddChild(leftPiece);
        AddChild(leftPieceSlope);
        AddChild(leftBlockPiece);
        AddChild(centerPiece);
        AddChild(rightPiece);
        AddChild(rightSlope);
        //AddChild(rightCenterPiece);

        AddChild(player);
        AddChild(cam);

        //cam.SetXY(1424, 768);
        cam.SetXY(game.width * 1.5f, currentLevelSize.y / 2f);
        cam.scale = 3f;
    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.8f, 1.6f, 2f, 0 }, player.rigidbody.velocity);
    }

    public override void SetCameraPosition()
    {
        return;

        Vec2 lerp = Vec2.Lerp(new Vec2(cam.x, cam.y), new Vec2(player.x + (game.width / 2.19f), 2048), 0.9f);

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

