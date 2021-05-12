using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VerticalLevel : Level
{
    private Background background;
    private Door hubDoor;
    private Vec2 previousCameraPos = new Vec2();

    public VerticalLevel()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_04.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_03.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_02.png", "Assets/Sprites/Backgrounds/HorizontalLevel/Lvl01_Layer_01.png" });
        currentLevelSize = new Vec2(7680, 2160);

        player = new Player(new Vec2(512, currentLevelSize.y - 256), 128);
        Entity floor = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, currentLevelSize.y - 52), (int)currentLevelSize.x, 104, false, true, float.PositiveInfinity, 0f);
        Entity leftWall = new Entity("Assets/Sprites/square.png", new Vec2(48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity rightWall = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x - 48, currentLevelSize.y / 2f), 96, (int)currentLevelSize.y, false, true, float.PositiveInfinity, 0f);
        Entity roof = new Entity("Assets/Sprites/square.png", new Vec2(currentLevelSize.x / 2, 32), (int)currentLevelSize.x, 64, false, true, float.PositiveInfinity, 0f);

        hubDoor = new Door(new Vec2(512, floor.y - floor.height / 2f - 192), 472, -1, 0, false);

        sceneObjects.Add(floor);
        sceneObjects.Add(leftWall);
        sceneObjects.Add(rightWall);
        sceneObjects.Add(roof);

        sceneObjects.Add(player);

        //floor.visible = false;
        //leftWall.visible = false;
        //rightWall.visible = false;
        //roof.visible = false;

        leftWall.ignoreColliders.Add(floor.collider);
        leftWall.ignoreColliders.Add(roof.collider);
        rightWall.ignoreColliders.Add(floor.collider);
        rightWall.ignoreColliders.Add(roof.collider);
        hubDoor.ignoreColliders.Add(player.collider);


        AddChild(background);
        AddChild(hubDoor);
        AddChild(floor);
        AddChild(leftWall);
        
        AddChild(rightWall);
        AddChild(roof);

        AddChild(player);
        AddChild(cam);

        cam.SetXY(player.x, player.y);
        previousCameraPos = new Vec2(cam.x, cam.y);
        cam.scale = 2f;
        hubDoor.AddUIText(this);


        hubDoor.isOpened = true;
    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
        hubDoor.currentFrame = 4;
    }

    void MoveBackgrounds()
    {
        background.MoveLayersWithDistance(new float[] { 0.4f, 0.8f, 1f, 0 }, new Vec2(cam.x, cam.y) - previousCameraPos);
        previousCameraPos = new Vec2(cam.x, cam.y);
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

