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
    SoundChannel channel;
    Sound sound;

    bool canPlaySound = true;

    public DeathScreen()
    {
        image = new Sprite("Assets/Images/youdied.png", false);
        sound = new Sound("Assets/Sounds/fa_fuckingDead.mp3");

        image.SetOrigin(image.width / 2, image.height / 2);

        image.width = (int)(game.height * ((float)image.width / (float)image.height) / 2);
        image.height = game.height / 2;

        image.SetXY(width / 2, height / 2);
        image.alpha = 0;
        image.scale = 0.5f;
        AddChild(image);
    }

    void Update()
    {
        base.Update();
        MyGame.Instance.levelManager.ingameMusic.Volume = 0.075f;
        MyGame.Instance.levelManager.currentLevel.player.canMove = false;

        if (canPlaySound) channel = sound.Play(false, 0, 0.5f); canPlaySound = false;

        image.scale += 0.0005f;

        if (timeMillis < 3000)
        {
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
            MyGame.Instance.UserInterfaceManager.RemoveInterface(5);
            MyGame.Instance.levelManager.RestartLevel();
            image.scale = 0.5f;
            canPlaySound = true;
            MyGame.Instance.levelManager.ingameMusic.Volume = 0.2f;
            MyGame.Instance.levelManager.currentLevel.player.canMove = true;
        }
        if (timeMillis > 4100)
        {
            MyGame.Instance.UserInterfaceManager.AddInterface(4);
        }
    }
}

