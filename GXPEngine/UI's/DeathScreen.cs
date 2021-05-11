using System;
using System.Collections.Generic;
using System.Linq;
using GXPEngine;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

class DeathScreen : UI
{
    Sprite image;
    Sound sound;
    bool canPlaySound = true;

    public DeathScreen()
    {
        image = new Sprite("Assets/Images/youdied.png", false);
        sound = new Sound("Assets/Sounds/teamLogo.wav");

        image.SetOrigin(image.width / 2, image.height / 2);

        image.width = (int)(game.height * ((float)image.width / (float)image.height) / 2);
        image.height = game.height / 2;

        image.SetXY(width / 2, height / 2);
        loimagego.alpha = 0;
        AddChild(image);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        image.scale += 0.001f;

        if (timeMillis < 3000 && timeMillis > 500)
        {
            if (canPlaySound) sound.Play(); canPlaySound = false;

            if (image.alpha < 1)
            {
                image.alpha += 0.01f;
            }
        }
        if (timeMillis > 3000)
        {
            if (image.alpha > 0)
            {
                image.alpha -= 0.02f;
            }
        }

        if (image.alpha > 1)
        {
            image.alpha = 1;
        }
        if (image.alpha < 0)
        {
            image.alpha = 0;
        }

        if (timeMillis > 4000)
        {
            MyGame.Instance.UserInterfaceManager.AddInterface(1);
        }
        if (timeMillis > 4100)
        {
            MyGame.Instance.UserInterfaceManager.RemoveInterface(0);
        }
    }
}

