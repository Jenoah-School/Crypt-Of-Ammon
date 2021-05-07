using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Threading.Tasks;


public class TestLevelArjen2 : Level
{
    Background background;
    Door door1;
    Door door2;

    public TestLevelArjen2()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/Level2/test.png" });
        player = new Player(new Vec2(100, 2000), 64);
        
        cam.SetXY(1450, player.y);

        currentLevelSize = new Vec2(1920, 1500);

        Entity floor = new Entity("Assets/Sprites/empty.png", new Vec2(2000, 2100), 4000, 64, false, true, float.PositiveInfinity, 0);

        door1 = new Door(new Vec2(100, 2000), 75, 100, 0, true);
        door2 = new Door(new Vec2(1500, 2000), 75, 100, 0, false);

        door1.ignoreColliders.Add(player.collider);
        door2.ignoreColliders.Add(player.collider);

        AddChild(background);
        AddChild(floor);
        AddChild(door1);
        AddChild(door2);
        AddChild(player);
        AddChild(cam);

        sceneObjects.Add(player);
        sceneObjects.Add(floor);
        sceneObjects.Add(door1);
        sceneObjects.Add(door2);
    }

    void Update()
    {
        base.Update();
        MoveBackgrounds();
    }

    void MoveBackgrounds()
    {
        for (int i = 0; i < sceneObjects.Count; i++)
        {
            if (sceneObjects[i].frameCount > 1)
            {
                sceneObjects[i].Animate();
            }
        }
        background.MoveLayersWithDistance(new float[] { 0 }, player.rigidbody.velocity);
    }
}

