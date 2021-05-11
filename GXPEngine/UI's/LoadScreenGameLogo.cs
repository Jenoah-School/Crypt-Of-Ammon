using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class LoadScreenGameLogo : UI
{
    Sprite logo;
    public LoadScreenGameLogo()
    {
        logo = new Sprite("Assets/Images/Logo.jfif", false);
        logo.SetOrigin(logo.width / 2, logo.height / 2);

        logo.SetXY(width / 2 , height / 2);
        logo.height = (int)(game.width * ((float)logo.height / (float)logo.width));
        logo.width = game.width;
        logo.alpha = 0;
        AddChild(logo);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        if (timeMillis < 3000 && timeMillis > 500)
        {
            if (logo.alpha < 1)
            {
                logo.alpha += 0.01f;
            }
        }
        if (timeMillis > 3000)
        {
            if (logo.alpha > 0)
            {
                logo.alpha -= 0.02f;
            }
        }

        if (logo.alpha > 1)
        {
            logo.alpha = 1;
        }
        if (logo.alpha < 0)
        {
            logo.alpha = 0;
        }

        if (timeMillis > 5000)
        {
            MyGame.Instance.UserInterfaceManager.AddInterface(2);          
        }
        if(timeMillis > 5100)
        {
            MyGame.Instance.UserInterfaceManager.RemoveInterface(1);
        }
    }
}

