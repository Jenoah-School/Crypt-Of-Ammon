using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestLevel : Level
{ 
    public TestLevel()
    {
        Entity tempEnt = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2), 128, -1);
        sceneObjects.Add(tempEnt);
        AddChild(tempEnt);
    }
}
