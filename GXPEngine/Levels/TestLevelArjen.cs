using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class TestLevelArjen : Level
{
    Background background;

    private Door door1;

    public TestLevelArjen()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/Level1/Back.png", "Assets/Sprites/Backgrounds/Level1/Middle1.png", "Assets/Sprites/Backgrounds/Level1/Middle2.png", "Assets/Sprites/Backgrounds/Level1/Front.png" });
        
        player = new Player(new Vec2(2300, 2000), 64);

        cam.SetXY(player.x + (game.width / 2.19f), player.y);

        currentLevelSize = new Vec2(3840, 2160);

        Entity floor = new Entity("Assets/Sprites/empty.png", new Vec2(2000, 2100), 4000, 64, false, true, float.PositiveInfinity, 0);
        door1 = new Door(new Vec2(2000, 2000), 75, 100, 1, false);

        AddChild(background);
        AddChild(door1);
        AddChild(player);
        AddChild(cam);

        door1.ignoreColliders.Add(player.collider);
        door1.SetCycle(0, 1, 255, true);

        sceneObjects.Add(player);
        sceneObjects.Add(floor);         
        sceneObjects.Add(door1);     
    }

    void Update()
    {       
        base.Update();
        MoveBackgrounds();
        SetInteractibleStates();
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

        background.MoveLayersWithDistance(new float[] { 0.8f, 1.6f, 2f, 0 }, player.rigidbody.velocity);
    }

    void SetInteractibleStates()
    {
        if(Input.GetKey(Key.H))
        {
            door1.isOpened = true;
            door1.SetCycle(1, 1, 255, true);
            door1.doorOpenSound.Play(false, 0, 0.05f);
        }
    }
}

