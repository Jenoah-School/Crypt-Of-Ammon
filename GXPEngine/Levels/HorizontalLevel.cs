using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HorizontalLevel : Level
{
    private Background background;
    private Door hubDoor;
    private Entity bridge, gate;
    private Vec2 previousCameraPos = new Vec2();

    private int pressurePlatesDown = 0;

    public HorizontalLevel()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_04.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_03.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_02.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_01.png" });
        currentLevelSize = new Vec2(7680, 2160);

        player = new Player(new Vec2(512, currentLevelSize.y - 256), 128);
        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, currentLevelSize.y - 52), (int)currentLevelSize.x, 104, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity leftFloorBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 96, floor.y - floor.height / 2f - 32), 192, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 580, currentLevelSize.y / 2 - 36), 1160, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceCeiling = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 340, 360), 680, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceTop = new Entity("Assets/Sprites/square.png", new Vec2(816, 364), 98, 600, false, true, float.PositiveInfinity, 0f);
        Entity leftPieceSlope = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 560, currentLevelSize.y / 2 + 148), 1200, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 128, currentLevelSize.y / 2 - 96), 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterPiece = new Entity("Assets/Sprites/square.png", new Vec2(1916, currentLevelSize.y / 2f + 376), 384, 96, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece = new Entity("Assets/Sprites/square.png", new Vec2(2872, currentLevelSize.y / 2 - 192), 378, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece1 = new Entity("Assets/Sprites/square.png", new Vec2(2832, currentLevelSize.y / 2 - 236), 300, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece2 = new Entity("Assets/Sprites/square.png", new Vec2(2730, currentLevelSize.y / 2 - 292), 96, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerBottomPiece = new Entity("Assets/Sprites/square.png", new Vec2(4226, currentLevelSize.y - 290), 2296, 512, false, true, float.PositiveInfinity, 0f);
        Entity centerBottomBlock = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2f + 1352, centerBottomPiece.y - centerBottomPiece.height / 2f - 24), 96, 48, false, true, float.PositiveInfinity, 0f);
        Entity centerSlope = new Entity("Assets/Sprites/square.png", new Vec2(2762, currentLevelSize.y - 69), 1024, 512, false, true, float.PositiveInfinity, 0f);
        Entity centerTopPiece = new Entity("Assets/Sprites/square.png", new Vec2(4072, 572), 1636, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock = new Entity("Assets/Sprites/square.png", new Vec2(4762, 508), 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock1 = new Entity("Assets/Sprites/square.png", new Vec2(4796, 444), 190, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock2 = new Entity("Assets/Sprites/square.png", new Vec2(4848, 368), 84, 84, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 472, currentLevelSize.y / 2 + 554), 768, 46, false, true, float.PositiveInfinity, 0f);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity roof = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, 32), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0f);

        bridge = new Entity("Assets/Sprites/Bridge_01.png", new Vec2(currentLevelSize.x - currentLevelSize.x / 4f + 328, currentLevelSize.y / 2 + 579), 1484, -1, false, true, float.PositiveInfinity, 0f);
        gate = new Entity("Assets/Sprites/Gate_01.png", new Vec2(816, currentLevelSize.y / 2 - 248), 98, -1, false, true, float.PositiveInfinity, 0f);

        Box pushBox1 = new Box(new Vec2(512, currentLevelSize.y / 2 - 256), 164);
        Box pushBox2 = new Box(new Vec2(1536, currentLevelSize.y - 256), 164);
        Box pushBox3 = new Box(new Vec2(currentLevelSize.x / 2 + 384, 256), 164);

        hubDoor = new Door(new Vec2(512, floor.y - floor.height / 2f - 192), 472, -1, 0, false);

        Trigger pressurePlate1 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 - 196, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        Trigger pressurePlate2 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 + 236, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        Trigger pressurePlate3 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 + 664, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        TriggerCollider deathTrigger = new TriggerCollider("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 1224, currentLevelSize.y - 192), 2256, 256);
        Lever lever = new Lever("Assets/Sprites/Handle_01.png", new Vec2(currentLevelSize.x - 484, currentLevelSize.y / 2 + 512), 14);

        Torch torch1 = new Torch(new Vec2(148, 1750), 1920, 1580);
        Torch torch2 = new Torch(new Vec2(172, 718), 1920, 1580);
        Torch torch3 = new Torch(new Vec2(2242, 1792), 1920, 1580);
        Torch torch4 = new Torch(new Vec2(3018, 592), 1920, 1580);
        Torch torch5 = new Torch(new Vec2(3298, 272), 1920, 1580);
        Torch torch6 = new Torch(new Vec2(3146, 1364), 1920, 1580);
        Torch torch7 = new Torch(new Vec2(4652, 228), 1920, 1580);
        Torch torch8 = new Torch(new Vec2(5184, 1312), 1920, 1580);
        Torch torch9 = new Torch(new Vec2(currentLevelSize.x - 822, 1364), 1920, 1580);
        Torch torch10 = new Torch(new Vec2(currentLevelSize.x - 152, 1336), 1920, 1580);

        pressurePlate1.ignoreColliders.Add(pushBox1.collider);
        pressurePlate1.ignoreColliders.Add(pushBox2.collider);
        pressurePlate1.ignoreColliders.Add(pushBox3.collider);
        pressurePlate1.ignoreColliders.Add(player.collider);

        pressurePlate2.ignoreColliders.Add(pushBox1.collider);
        pressurePlate2.ignoreColliders.Add(pushBox2.collider);
        pressurePlate2.ignoreColliders.Add(pushBox3.collider);
        pressurePlate2.ignoreColliders.Add(player.collider);

        pressurePlate3.ignoreColliders.Add(pushBox1.collider);
        pressurePlate3.ignoreColliders.Add(pushBox2.collider);
        pressurePlate3.ignoreColliders.Add(pushBox3.collider);
        pressurePlate3.ignoreColliders.Add(player.collider);

        deathTrigger.ignoreColliders.Add(deathTrigger.collider);

        pressureTriggers.Add(pressurePlate1);
        pressureTriggers.Add(pressurePlate2);
        pressureTriggers.Add(pressurePlate3);
        pressureSenders.Add(pushBox1);
        pressureSenders.Add(pushBox2);
        pressureSenders.Add(pushBox3);
        pressureSenders.Add(player);

        pressurePlate1.SetTriggerEvent(new Action(() => ActivatePressurePlate(pressurePlate1)));
        pressurePlate2.SetTriggerEvent(new Action(() => ActivatePressurePlate(pressurePlate2)));
        pressurePlate3.SetTriggerEvent(new Action(() => ActivatePressurePlate(pressurePlate3)));
        pressurePlate1.SetUntriggerEvent(new Action(() => DeactivatePressurePlate(pressurePlate1)));
        pressurePlate2.SetUntriggerEvent(new Action(() => DeactivatePressurePlate(pressurePlate2)));
        pressurePlate3.SetUntriggerEvent(new Action(() => DeactivatePressurePlate(pressurePlate3)));

        lever.SetTriggerEvent(new Action(() => ((HubLevel)MyGame.Instance.levelManager.levels[0]).door2.isOpening = true));

        centerSlope.rotation = 330;
        leftPieceSlope.rotation = 345;

        sceneObjects.Add(floor);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(leftFloorBlockPiece);
        sceneObjects.Add(leftPiece);
        sceneObjects.Add(leftPieceTop);
        sceneObjects.Add(leftPieceCeiling);
        sceneObjects.Add(leftPieceSlope);
        sceneObjects.Add(leftBlockPiece);
        sceneObjects.Add(leftCenterPiece);
        sceneObjects.Add(centerBottomPiece);
        sceneObjects.Add(centerBottomBlock);
        sceneObjects.Add(centerSlope);
        sceneObjects.Add(centerTopPiece);
        sceneObjects.Add(leftCenterChainedPiece);
        sceneObjects.Add(leftCenterChainedPiece1);
        sceneObjects.Add(leftCenterChainedPiece2);
        sceneObjects.Add(centerTopBlock);
        sceneObjects.Add(centerTopBlock1);
        sceneObjects.Add(centerTopBlock2);
        sceneObjects.Add(rightPiece);
        sceneObjects.Add(rightWall);
        sceneObjects.Add(pushBox1);
        sceneObjects.Add(pushBox2);
        sceneObjects.Add(pushBox3);
        sceneObjects.Add(gate);
        sceneObjects.Add(bridge);
        sceneObjects.Add(roof);

        sceneObjects.Add(player);

        floor.visible = false;
        leftWall.visible = false;
        leftFloorBlockPiece.visible = false;
        leftPiece.visible = false;
        leftPieceCeiling.visible = false;
        leftPieceSlope.visible = false;
        leftBlockPiece.visible = false;
        leftPieceTop.visible = false;
        leftCenterPiece.visible = false;
        centerBottomPiece.visible = false;
        centerBottomBlock.visible = false;
        centerSlope.visible = false;
        centerTopPiece.visible = false;
        leftCenterChainedPiece.visible = false;
        leftCenterChainedPiece1.visible = false;
        leftCenterChainedPiece2.visible = false;
        centerTopBlock.visible = false;
        centerTopBlock1.visible = false;
        centerTopBlock2.visible = false;
        rightPiece.visible = false;
        rightWall.visible = false;
        roof.visible = false;
        deathTrigger.visible = false;

        leftWall.ignoreColliders.Add(floor.collider);
        leftWall.ignoreColliders.Add(leftPieceCeiling.collider);
        leftFloorBlockPiece.ignoreColliders.Add(floor.collider);
        leftWall.ignoreColliders.Add(leftFloorBlockPiece.collider);
        leftPiece.ignoreColliders.Add(leftWall.collider);
        leftPieceSlope.ignoreColliders.Add(leftWall.collider);
        leftPiece.ignoreColliders.Add(leftPieceSlope.collider);
        leftPiece.ignoreColliders.Add(gate.collider);
        leftBlockPiece.ignoreColliders.Add(leftWall.collider);
        leftBlockPiece.ignoreColliders.Add(leftPiece.collider);
        centerBottomPiece.ignoreColliders.Add(floor.collider);
        centerSlope.ignoreColliders.Add(floor.collider);
        centerBottomPiece.ignoreColliders.Add(centerSlope.collider);
        centerBottomPiece.ignoreColliders.Add(centerBottomBlock.collider);
        leftCenterChainedPiece.ignoreColliders.Add(leftCenterChainedPiece1.collider);
        leftCenterChainedPiece2.ignoreColliders.Add(leftCenterChainedPiece1.collider);
        centerTopPiece.ignoreColliders.Add(centerTopBlock.collider);
        centerTopBlock.ignoreColliders.Add(centerTopBlock1.collider);
        centerTopBlock1.ignoreColliders.Add(centerTopBlock2.collider);
        rightWall.ignoreColliders.Add(rightPiece.collider);
        rightWall.ignoreColliders.Add(floor.collider);
        rightWall.ignoreColliders.Add(roof.collider);
        leftWall.ignoreColliders.Add(roof.collider);
        bridge.ignoreColliders.Add(rightPiece.collider);
        bridge.ignoreColliders.Add(centerBottomPiece.collider);
        hubDoor.ignoreColliders.Add(player.collider);


        AddChild(background);
        AddChild(hubDoor);
        AddChild(floor);
        AddChild(leftWall);
        AddChild(leftFloorBlockPiece);
        AddChild(leftPiece);
        AddChild(leftPieceTop);
        AddChild(leftPieceCeiling);
        AddChild(leftPieceSlope);
        AddChild(leftBlockPiece);
        AddChild(leftCenterPiece);
        AddChild(centerBottomPiece);
        AddChild(centerBottomBlock);
        AddChild(centerSlope);
        AddChild(leftCenterChainedPiece);
        AddChild(leftCenterChainedPiece1);
        AddChild(leftCenterChainedPiece2);
        AddChild(centerTopPiece);
        AddChild(centerTopBlock);
        AddChild(centerTopBlock1);
        AddChild(centerTopBlock2);
        AddChild(rightPiece);
        AddChild(rightWall);
        AddChild(roof);
        AddChild(lever);

        AddChild(torch1);
        AddChild(torch2);
        AddChild(torch3);
        AddChild(torch4);
        AddChild(torch5);
        AddChild(torch6);
        AddChild(torch7);
        AddChild(torch8);
        AddChild(torch9);
        AddChild(torch10);

        AddChild(pressurePlate1);
        AddChild(pressurePlate2);
        AddChild(pressurePlate3);

        AddChild(gate);
        AddChild(bridge);
        AddChild(player);

        AddChild(pushBox1);
        AddChild(pushBox2);
        AddChild(pushBox3);

        AddChild(deathTrigger);

        AddChild(cam);

        cam.SetXY(player.x, player.y);
        previousCameraPos = new Vec2(cam.x, cam.y);
        cam.scale = 2f;
        lever.AddUIText(this);
        hubDoor.AddUIText(this);
        
        deathTrigger.SetTriggerEvent(new Action(() => TouchedSpikes()));

        hubDoor.isOpened = true;

        HandlePressurePlates();
    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
        hubDoor.currentFrame = 4;
    }

    void TouchedSpikes()
    {       
        MyGame.Instance.UserInterfaceManager.AddInterface(5);
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.4f, 0.8f, 1f, 0 }, new Vec2(cam.x, cam.y) - previousCameraPos);
        previousCameraPos = new Vec2(cam.x, cam.y);
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
        if (pressurePlatesDown > 0)
        {
            gate.visible = false;
            if (MyGame.collisionObjects.Contains(gate.collider))
                MyGame.collisionObjects.Remove(gate.collider);
            if (!player.ignoreColliders.Contains(gate.collider))
                player.ignoreColliders.Add(gate.collider);
        }
        else
        {
            gate.visible = true;
            if (!MyGame.collisionObjects.Contains(gate.collider))
                MyGame.collisionObjects.Insert(4, gate.collider);
            if (player.ignoreColliders.Contains(gate.collider))
                player.ignoreColliders.Remove(gate.collider);
        }

        if (pressurePlatesDown > 2)
        {
            bridge.visible = true;
            if (!MyGame.collisionObjects.Contains(bridge.collider))
                MyGame.collisionObjects.Insert(4, bridge.collider);
            if (player.ignoreColliders.Contains(bridge.collider))
                player.ignoreColliders.Remove(bridge.collider);
        }
        else
        {
            bridge.visible = false;
            if (MyGame.collisionObjects.Contains(bridge.collider))
                MyGame.collisionObjects.Remove(bridge.collider);
            if (!player.ignoreColliders.Contains(bridge.collider))
                player.ignoreColliders.Add(bridge.collider);
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

