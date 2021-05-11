using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class ComicUI : UI
{
    AnimationSprite comic;
    float previousTime;

    bool canPlaySound = true;

    SoundChannel channel;
    Sound music;

    public ComicUI()
    {
        comic = new AnimationSprite("Assets/Sprites/Comic/comic.png", 7, 1, 7, false, false);
        music = new Sound("Assets/Sounds/fa_awakening_short.mp3");
        AddChild(comic);
        comic.width = game.width;
        comic.height = game.height;
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        if (canPlaySound) channel = music.Play(false, 0, 0.5f); canPlaySound = false;

        if (timeMillis > previousTime + 3000)
        {
            comic.currentFrame++;
            previousTime = timeMillis;
        }      
        if(timeMillis > 20000)
        {
            comic.alpha -= 0.005f;
        }
        if(comic.alpha < 0)
        {
            channel.Volume -= 0.05f;
            MyGame.Instance.UserInterfaceManager.RemoveInterface(3);
            MyGame.Instance.UserInterfaceManager.AddInterface(4);
        }
    }
}
