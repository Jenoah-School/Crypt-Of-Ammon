using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class MainMenu : UI
{
    Sprite titleImage;
    Sprite backgroundImage;

    Sound sound;
    bool canPlaySound = true;

    public MainMenu()
    {
        titleImage = new Sprite("Assets/Images/logoSimple.png", false);
        backgroundImage = new Sprite("Assets/Images/mainMenu.jpg", false);
        titleImage.SetOrigin(titleImage.width / 2, titleImage.height / 2);
        titleImage.SetXY(width / 2, height / 5);

        sound = new Sound("Assets/Sounds/mainMenu.mp3");

        AddChild(backgroundImage);
        AddChild(titleImage);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        if (canPlaySound) sound.Play(false, 0, 0.5f,0); canPlaySound = false;

        if (timeSeconds == 5)
        {
            //MyGame.Instance.UserInterfaceManager.SwitchInterface(0);
        }
    }
}

