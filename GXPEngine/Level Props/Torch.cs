using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class Torch : Entity
{
    public float previousTime = 0;

    public Torch(Vec2 position, int width, int height) : base("Assets/Sprites/LevelProps/Torch_Fire_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 2, 5, 10)
    {
        SetXY(position.x, position.y);
    }

    void Update()
    {
        
        if(Time.time > previousTime + 75)
        {
            currentFrame = new Random().Next(0, 10);
            previousTime = Time.time;
        }
    }
}

