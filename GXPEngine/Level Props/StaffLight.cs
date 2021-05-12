using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StaffLight : Entity
{
    public float previousTime = 0;
    private Random rand;

    public StaffLight(Vec2 position, int width, int height) : base("Assets/Sprites/LevelProps/Staff_Light_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 2, 5, 10)
    {
        rand = new Random((int)(position.x + position.y));
        SetXY(position.x, position.y);
    }

    void Update()
    {

        if (Time.time > previousTime + 75)
        {
            currentFrame = rand.Next(0, 10);
            previousTime = Time.time;
        }
    }
}