using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Button : Sprite
{
    public Button() : base("Assets/Images/buttonPlaceholder.png", false, true)
    {

    }

    public bool IsPressed()
    {
        return HitTestPoint(Input.mouseX, Input.mouseY);
    }

    public bool IsClicked()
    {
        bool isClicked = false;

        int mousePosX;
        int mousePosY;

        mousePosX = (int)(2920 / (float)((UI)parent).width * (float)Input.mouseX);
        mousePosY = (int)(1620 / (float)((UI)parent).height * (float)Input.mouseY);


        if (Input.GetMouseButtonUp(0))
        {
            if(mousePosX > x && mousePosX < x + width && mousePosY > y && mousePosY < y + height)
            {
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
        }

        return isClicked;
    }
}

