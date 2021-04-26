using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestLevel : Level
{
    public TestLevel() : base("Assets/Sprites/Backgrounds/TempBackground.jpg")
    {
        Entity tempEnt = new Entity("Assets/Sprites/square.png", new Vec2(game.width / 2, game.height / 2), 64, -1);
        sceneObjects.Add(tempEnt);
        AddChild(tempEnt);
    }
}
