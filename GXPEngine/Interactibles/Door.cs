using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Door : Entity
{
    public Door(Vec2 position, int width, int height) : base("Assets/Sprites/door.png", position, width, height, false, false, float.PositiveInfinity, 1)
    {
        SetXY(position.x, position.y);
    }

    void Update()
    {
        
    }
}

