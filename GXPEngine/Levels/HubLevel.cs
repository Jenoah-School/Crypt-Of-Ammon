using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HubLevel : Level
{
    Background background;
    Door door1;
    public HubLevel()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_04.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_03.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_02.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_01.png" });
        currentLevelSize = new Vec2(3840, 2160);
        player = new Player(new Vec2(2500, 1900), 128);

        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(1920, 2080), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(60, currentLevelSize.y / 2), 64, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2((int)currentLevelSize.x - 60, currentLevelSize.y / 2), 64, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0);
        Entity ceiling = new Entity("Assets/Sprites/square.png", new Vec2(1920, 300), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0);

        Entity rightPlatform1 = new Entity("Assets/Sprites/square.png", new Vec2(3235, 1113), 1100, 64, false, true, float.PositiveInfinity, 0);
        Entity rightPlatform2 = new Entity("Assets/Sprites/square.png", new Vec2(3700, 1055), 100, 64, false, true, float.PositiveInfinity, 0);
        Entity rightPlatform3 = new Entity("Assets/Sprites/square.png", new Vec2(3250, 1350), 1170, 64, false, true, float.PositiveInfinity, 0);

        Entity middlePlatform1 = new Entity("Assets/Sprites/square.png", new Vec2(1920, 1435), 385, 64, false, true, float.PositiveInfinity, 0);
        Entity middlePlatform2 = new Entity("Assets/Sprites/square.png", new Vec2(1920, 1480), 300, 64, false, true, float.PositiveInfinity, 0);

        Entity leftPlatform1 = new Entity("Assets/Sprites/square.png", new Vec2(690, 1113), 1300, 64, false, true, float.PositiveInfinity, 0);
        Entity leftPlatform2 = new Entity("Assets/Sprites/square.png", new Vec2(185, 1055), 200, 64, false, true, float.PositiveInfinity, 0);
        Entity leftPlatform3 = new Entity("Assets/Sprites/square.png", new Vec2(690, 1350), 1350, 64, false, true, float.PositiveInfinity, 0);

        Entity leftRandomBox = new Entity("Assets/Sprites/square.png", new Vec2(340, 2030), 510, 64, false, true, float.PositiveInfinity, 0);

        Torch torch1 = new Torch(new Vec2(500, 1750), 1920, 1580);
        door1 = new Door(new Vec2(3150, 1840), 472, 442, 0, false);

        rightPlatform3.rotation = 20;
        leftPlatform3.rotation = -20;

        cam.SetXY(player.x, player.y);

        AddChild(background);       
        AddChild(cam);

        AddChild(door1);

        AddChild(floor);
        AddChild(leftWall);
        AddChild(rightWall);
        AddChild(ceiling);
        AddChild(rightPlatform1);
        AddChild(rightPlatform2);
        AddChild(rightPlatform3);
        AddChild(middlePlatform1);
        AddChild(middlePlatform2);
        AddChild(leftPlatform1);
        AddChild(leftPlatform2);
        AddChild(leftPlatform3);
        AddChild(leftRandomBox);

        AddChild(torch1);

        AddChild(player);

        sceneObjects.Add(player);
        sceneObjects.Add(floor);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(rightWall);
        sceneObjects.Add(ceiling);
        sceneObjects.Add(rightPlatform1);
        sceneObjects.Add(rightPlatform2);
        sceneObjects.Add(rightPlatform3);
        sceneObjects.Add(middlePlatform1);
        sceneObjects.Add(middlePlatform2);
        sceneObjects.Add(leftPlatform1);
        sceneObjects.Add(leftPlatform2);
        sceneObjects.Add(leftPlatform3);
        sceneObjects.Add(leftRandomBox);

        sceneObjects.Add(door1);

        door1.ignoreColliders.Add(player.collider);

        floor.ignoreColliders.Add(leftWall.collider);
        floor.ignoreColliders.Add(rightWall.collider);
        ceiling.ignoreColliders.Add(leftWall.collider);
        ceiling.ignoreColliders.Add(rightWall.collider);

        rightWall.ignoreColliders.Add(rightPlatform1.collider);
        rightWall.ignoreColliders.Add(rightPlatform2.collider);

        rightPlatform1.ignoreColliders.Add(rightPlatform2.collider);
        rightPlatform3.ignoreColliders.Add(rightPlatform1.collider);
        rightPlatform3.ignoreColliders.Add(rightWall.collider);

        middlePlatform1.ignoreColliders.Add(middlePlatform2.collider);

        leftWall.ignoreColliders.Add(leftPlatform1.collider);
        leftWall.ignoreColliders.Add(leftPlatform2.collider);

        leftPlatform1.ignoreColliders.Add(leftPlatform2.collider);
        leftPlatform3.ignoreColliders.Add(leftPlatform1.collider);
        leftPlatform3.ignoreColliders.Add(leftWall.collider);

        leftRandomBox.ignoreColliders.Add(leftWall.collider);
        leftRandomBox.ignoreColliders.Add(floor.collider);

    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
        door1.Animate();
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.4f, 0.8f, 0.2f, 0 }, player.rigidbody.velocity);
    }
}

