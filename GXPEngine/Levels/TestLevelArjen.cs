using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TestLevelArjen : Level
{
    Background background;
    Player player;

    public TestLevelArjen()
    {
        background = new Background(new string[] { "Assets/Sprites/Backgrounds/Level1Back.png", "Assets/Sprites/Backgrounds/Level1Middle.png", "Assets/Sprites/Backgrounds/Level1Middle2.png", "Assets/Sprites/Backgrounds/level1Front.png"});
        player = new Player(new Vec2(2300, 2000), 64);
        Entity floor = new Entity("Assets/Sprites/empty.png", new Vec2(2000, 2100), 4000, 64, false, true, float.PositiveInfinity, 0);
        Door door = new Door(new Vec2(2000, 2000), 75, 100);    

        AddChild(background);
        AddChild(floor);
        AddChild(door);
        AddChild(player);


        sceneObjects.Add(player);
        sceneObjects.Add(floor);         
        sceneObjects.Add(door);         
    }

    void Update()
    {
        base.Update();
        background.MoveLayersWithDistance(new float[] { 0.8f, 1.6f, 2f, 0 }, player.rigidbody.velocity.x);
    }
}

