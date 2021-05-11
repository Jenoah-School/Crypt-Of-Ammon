using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class LoadScreenTeamLogo : UI
{
    Sprite logo;
    Sound sound;
    bool canPlaySound = true;

    public LoadScreenTeamLogo()
    {
        logo = new Sprite("Assets/Images/TeamLogoPlaceholder.png", false);
        sound = new Sound("Assets/Sounds/teamLogo.wav");
        
        logo.SetOrigin(logo.width / 2, logo.height / 2);

        logo.width = (int)(game.height * ((float)logo.width / (float)logo.height) / 2);
        logo.height = game.height / 2;

        logo.SetXY(width / 2, height / 2);
        logo.alpha = 0;
        AddChild(logo);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        logo.scale += 0.001f;

        if (timeMillis < 3000 && timeMillis > 500)
        {
            if(canPlaySound) sound.Play(); canPlaySound = false;

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

        if (timeMillis > 4000)
        {
            MyGame.Instance.UserInterfaceManager.AddInterface(1);         
        }
        if(timeMillis > 4100)
        {
            MyGame.Instance.UserInterfaceManager.RemoveInterface(0);
        }
    }
}

