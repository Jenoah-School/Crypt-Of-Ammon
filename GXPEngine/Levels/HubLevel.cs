using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HubLevel : Level
{
    Background background;
    Door door1;
    Lever staff;
    public Door door2 { get; private set; }

    private int pressurePlatesDown = 0;

    public HubLevel()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_04.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_03.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_02.png", "Assets/Sprites/Backgrounds/HubLevel/Hub_Layer_01.png" });
        currentLevelSize = new Vec2(3840, 2160);
        player = new Player(new Vec2(2000, 1900), 128);
        player.hasStaff = false;

        Entity floor = new Entity("Assets/Sprites/empty.png", new Vec2(1920, 2080), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0);
        Entity leftWall = new Entity("Assets/Sprites/empty.png", new Vec2(60, currentLevelSize.y / 2), 64, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0);
        Entity rightWall = new Entity("Assets/Sprites/empty.png", new Vec2((int)currentLevelSize.x - 60, currentLevelSize.y / 2), 64, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0);
        Entity ceiling = new Entity("Assets/Sprites/empty.png", new Vec2(1920, 300), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0);

        Entity rightPlatform1 = new Entity("Assets/Sprites/empty.png", new Vec2(3235, 1113), 1100, 64, false, true, float.PositiveInfinity, 0);
        Entity rightPlatform2 = new Entity("Assets/Sprites/empty.png", new Vec2(3700, 1055), 100, 64, false, true, float.PositiveInfinity, 0);
        Entity rightPlatform3 = new Entity("Assets/Sprites/empty.png", new Vec2(3250, 1350), 1170, 64, false, true, float.PositiveInfinity, 0);

        Entity middlePlatform1 = new Entity("Assets/Sprites/empty.png", new Vec2(1920, 1435), 385, 64, false, true, float.PositiveInfinity, 0);
        Entity middlePlatform2 = new Entity("Assets/Sprites/empty.png", new Vec2(1920, 1480), 300, 64, false, true, float.PositiveInfinity, 0);

        Entity leftPlatform1 = new Entity("Assets/Sprites/empty.png", new Vec2(690, 1113), 1300, 64, false, true, float.PositiveInfinity, 0);
        Entity leftPlatform2 = new Entity("Assets/Sprites/empty.png", new Vec2(185, 1055), 200, 64, false, true, float.PositiveInfinity, 0);
        Entity leftPlatform3 = new Entity("Assets/Sprites/empty.png", new Vec2(690, 1350), 1350, 64, false, true, float.PositiveInfinity, 0);

        Entity leftRandomBox = new Entity("Assets/Sprites/empty.png", new Vec2(340, 2030), 510, 64, false, true, float.PositiveInfinity, 0);

        Entity pushBox = new Entity("Assets/Sprites/Box_01.png", new Vec2(1900, 1300), 164, -1, true, true, 1, 0);

        Trigger pressurePlate = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(2450,2045), 256);

		staff = new Lever("Assets/Sprites/Player/handStaff.png", new Vec2(1042, currentLevelSize.y - 256f), 36);
        staff.rotation = 0;

        Torch torch1 = new Torch(new Vec2(500, 1750), 1920, 1580);
        Torch torch2 = new Torch(new Vec2(1265, 835), 1920, 1580);
        Torch torch3 = new Torch(new Vec2(2630, 1800), 1920, 1580);
        Torch torch4 = new Torch(new Vec2(3620, 1800), 1920, 1580);
        Torch torch5 = new Torch(new Vec2(2720, 840), 1920, 1580);
        Torch torch6 = new Torch(new Vec2(2060, 1150), 1920, 1580);

        door1 = new Door(new Vec2(3150, 1850), 472, 442, 1, true);
        door2 = new Door(new Vec2(3300, 880), 472, 442, 3, true);

        rightPlatform3.rotation = 20;
        leftPlatform3.rotation = -20;


        cam.SetXY(currentLevelSize.x / 1.333f, currentLevelSize.y / 2f);
        cam.scale = 2f;

        AddChild(background);       
        AddChild(cam);
      
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
        AddChild(torch2);
        AddChild(torch3);
        AddChild(torch4);
        AddChild(torch5);
        AddChild(torch6);
        AddChild(door1);
        AddChild(door2);
        AddChild(pushBox);
        AddChild(pressurePlate);
        AddChild(staff);
        AddChild(player);

        
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

        sceneObjects.Add(pushBox);

        sceneObjects.Add(player);

        sceneObjects.Add(door1);
        sceneObjects.Add(door2);
        sceneObjects.Add(pressurePlate);

        door1.ignoreColliders.Add(player.collider);
        door1.ignoreColliders.Add(floor.collider);
        door2.ignoreColliders.Add(player.collider);
        door2.ignoreColliders.Add(rightPlatform1.collider);

        pressurePlate.ignoreColliders.Add(pushBox.collider);
        pressurePlate.ignoreColliders.Add(player.collider);
        pressurePlate.ignoreColliders.Add(floor.collider);

        floor.ignoreColliders.Add(leftWall.collider);
        pushBox.ignoreColliders.Add(door1.collider);
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

        pressureTriggers.Add(pressurePlate);
        pressureSenders.Add(pushBox);
        pressureSenders.Add(player);

        pressurePlate.SetTriggerEvent(new Action(() => ActivatePressurePlate(pressurePlate)));
        pressurePlate.SetUntriggerEvent(new Action(() => DeactivatePressurePlate(pressurePlate)));

        staff.SetTriggerEvent(new Action(() => ActivateStaff()));
        staff.AddUIText(this);
        door1.AddUIText(this);
        door2.AddUIText(this);
    }

    void Update()
    {
        base.Update();
        door2.currentFrame = 4;
        MoveBackgrounds();
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.4f, 0.8f, 0.2f, 0 }, player.rigidbody.velocity);
    }

    void ActivateStaff()
    {
        player.hasStaff = true;
        staff.visible = false;
    }

    void ActivatePressurePlate(Trigger _pressurePlate)
    {
        _pressurePlate.SetColor(0.3f, 0.3f, 0.3f);
        pressurePlatesDown++;
        HandlePressurePlates();
    }

    void DeactivatePressurePlate(Trigger _pressurePlate)
    {
        _pressurePlate.SetColor(0.9f, 0.9f, 0.9f);
        pressurePlatesDown--;
        HandlePressurePlates();
    }

    void HandlePressurePlates()
    {
        
        if (pressurePlatesDown == 1)
        {
            door1.isOpening = true;
            door1.isClosing = false;
        }
        else
        {
            door1.isOpening = false;
            door1.isClosing = true;
        }
    }

    public override void SetCameraPosition()
    {
        Vec2 lerp = Vec2.Lerp(new Vec2(cam.x, cam.y), new Vec2(player.x, player.y), 0.9f);

        if (player.x > 256 && player.x < (currentLevelSize.x - 256))
        {
            cam.SetXY(lerp.x, lerp.y);
        }
        else
        {
            cam.SetXY(cam.x, lerp.y);
        }
        if (cam.x < cam._renderTarget.width * cam.scale / 2f)
        {
            cam.x = cam._renderTarget.width * cam.scale / 2f;
        }
        else if (cam.x > currentLevelSize.x - cam._renderTarget.width * cam.scale / 2f)
        {
            cam.x = currentLevelSize.x - cam._renderTarget.width * cam.scale / 2f;
        }
        if (cam.y < cam._renderTarget.height * cam.scale / 2f)
        {
            cam.y = cam._renderTarget.height * cam.scale / 2f;
        }
        else if (cam.y > currentLevelSize.y - cam._renderTarget.height * cam.scale / 2f)
        {
            cam.y = currentLevelSize.y - cam._renderTarget.height * cam.scale / 2f;
        }
    }
}

