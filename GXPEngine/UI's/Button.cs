using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Button : Sprite
{
    public Button() : base("Assets/Images/ButtonTransparent.png")
    {

    }

    public bool IsClicked()
    {
        int mousePosX = Input.mouseX;
        int mousePosY = Input.mouseY;

        if (Input.GetMouseButtonUp(0))
        {
            if (mousePosX > x && mousePosX < x + width && mousePosY > y && mousePosY < y + height)
            {
                return true;
            }
        }

        return false;
    }
}

