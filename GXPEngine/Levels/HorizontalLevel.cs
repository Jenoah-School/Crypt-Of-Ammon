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
        Entity leftPieceSlope = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 560, currentLevelSize.y / 2 + 148), 1200, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftBlockPiece = new Entity("Assets/Sprites/square.png", new Vec2(leftWall.x + leftWall.width / 2f + 128, currentLevelSize.y / 2 - 96), 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterPiece = new Entity("Assets/Sprites/square.png", new Vec2(1916, currentLevelSize.y / 2f + 376), 384, 96, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece = new Entity("Assets/Sprites/square.png", new Vec2(2872, currentLevelSize.y / 2 - 248), 378, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece1 = new Entity("Assets/Sprites/square.png", new Vec2(2832, currentLevelSize.y / 2 - 292), 300, 64, false, true, float.PositiveInfinity, 0f);
        Entity leftCenterChainedPiece2 = new Entity("Assets/Sprites/square.png", new Vec2(2730, currentLevelSize.y / 2 - 348), 96, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerBottomPiece = new Entity("Assets/Sprites/square.png", new Vec2(4226, currentLevelSize.y - 290), 2296, 512, false, true, float.PositiveInfinity, 0f);
        Entity centerSlope = new Entity("Assets/Sprites/square.png", new Vec2(2762, currentLevelSize.y - 69), 1024, 512, false, true, float.PositiveInfinity, 0f);
        Entity centerTopPiece = new Entity("Assets/Sprites/square.png", new Vec2(4072, 464), 1636, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock = new Entity("Assets/Sprites/square.png", new Vec2(4762, 400), 256, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock1 = new Entity("Assets/Sprites/square.png", new Vec2(4796, 336), 190, 64, false, true, float.PositiveInfinity, 0f);
        Entity centerTopBlock2 = new Entity("Assets/Sprites/square.png", new Vec2(4848, 264), 84, 84, false, true, float.PositiveInfinity, 0f);
        Entity rightPiece = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 472, currentLevelSize.y / 2 + 554), 768, 46, false, true, float.PositiveInfinity, 0f);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity roof = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, 32), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0f);
        
        bridge = new Entity("Assets/Sprites/Bridge_01.png", new Vec2(currentLevelSize.x - currentLevelSize.x / 4f + 328, currentLevelSize.y / 2 + 579), 1484, -1, false, true, float.PositiveInfinity, 0f);
        gate = new Entity("Assets/Sprites/Gate_01.png", new Vec2(816, currentLevelSize.y / 2 - 248), 98, -1, false, true, float.PositiveInfinity, 0f);

        Entity pushBox1 = new Entity("Assets/Sprites/Box_01.png", new Vec2(512, currentLevelSize.y / 2 - 256), 164, -1, true, true, 1, 0);
        Entity pushBox2 = new Entity("Assets/Sprites/Box_01.png", new Vec2(1536, currentLevelSize.y - 256), 164, -1, true, true, 1, 0);
        Entity pushBox3 = new Entity("Assets/Sprites/Box_01.png", new Vec2(currentLevelSize.x / 2 + 384, 256), 164, -1, true, true, 1, 0);

        hubDoor = new Door(new Vec2(512, floor.y - floor.height / 2f - 192), 256, -1, 1, false);

        Trigger pressurePlate1 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 - 196, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        Trigger pressurePlate2 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 + 236, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        Trigger pressurePlate3 = new Trigger("Assets/Sprites/Pressure_Plate_01.png", new Vec2(currentLevelSize.x / 2 + 664, centerBottomPiece.y - centerBottomPiece.height / 2f), 256);
        Entity lever = new Entity("Assets/Sprites/Handle_01.png", new Vec2(currentLevelSize.x - 484, currentLevelSize.y / 2 + 424), 14, -1, false, false, 1, 0);

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

        centerSlope.rotation = 330;

        leftPieceSlope.rotation = 345;

        sceneObjects.Add(floor);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(leftFloorBlockPiece);
        sceneObjects.Add(leftPiece);
        sceneObjects.Add(leftPieceSlope);
        sceneObjects.Add(leftBlockPiece);
        sceneObjects.Add(leftCenterPiece);
        sceneObjects.Add(centerBottomPiece);
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
        sceneObjects.Add(roof);
        sceneObjects.Add(pushBox1);
        sceneObjects.Add(pushBox2);
        sceneObjects.Add(pushBox3);
        sceneObjects.Add(bridge);
        sceneObjects.Add(gate);
        //sceneObjects.Add(hubDoor);

        sceneObjects.Add(player);

        floor.visible = false;
        leftWall.visible = false;
        leftFloorBlockPiece.visible = false;
        leftPiece.visible = false;
        leftPieceSlope.visible = false;
        leftBlockPiece.visible = false;
        leftCenterPiece.visible = false;
        centerBottomPiece.visible = false;
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

        leftWall.ignoreColliders.Add(floor.collider);
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
        AddChild(leftPieceSlope);
        AddChild(leftBlockPiece);
        AddChild(leftCenterPiece);
        AddChild(centerBottomPiece);
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
        AddChild(bridge);
        AddChild(lever);
        AddChild(gate);

        AddChild(pressurePlate1);
        AddChild(pressurePlate2);
        AddChild(pressurePlate3);

        AddChild(pushBox1);
        AddChild(pushBox2);
        AddChild(pushBox3);

        AddChild(player);
        AddChild(cam);

        cam.SetXY(currentLevelSize.x / 1.333f, currentLevelSize.y / 2f);
        cam.scale = 2f;

        HandlePressurePlates();
    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
        UseDoor();
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.8f, 1.6f, 2f, 0 }, player.rigidbody.velocity);
    }

    void UseDoor()
    {
        if (Input.GetKey(Key.H))
        {
            hubDoor.isOpened = true;
            hubDoor.SetCycle(1, 1, 255, true);
            hubDoor.doorOpenSound.Play(false, 0, 0.05f);
        }
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
        if(pressurePlatesDown >= 3)
        {
            bridge.visible = true;
            if (!MyGame.collisionObjects.Contains(bridge.collider))
            {
                MyGame.collisionObjects.Add(bridge.collider);
            }
        }
        else
        {
            bridge.visible = false;
            if (MyGame.collisionObjects.Contains(bridge.collider))
            {
                MyGame.collisionObjects.Remove(bridge.collider);
            }
        }

        if(pressurePlatesDown >= 1)
        {
            gate.visible = false;
            if (sceneObjects.Contains(gate))
            {
                sceneObjects.Remove(gate);
            }
        }
        else
        {
            gate.visible = true;
            if (!sceneObjects.Contains(gate))
            {
                sceneObjects.Add(gate);
            }
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

