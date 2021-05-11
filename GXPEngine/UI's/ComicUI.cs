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

    SoundChannel channel;
    Sound music;

    public ComicUI()
    {
        comic = new AnimationSprite("Assets/Sprites/Comic/comic.png", 7, 1, 7, false, false);
        music = new Sound("Assets/Sounds/fa_awakening.mp3");
        AddChild(comic);
        comic.width = game.width;
        comic.height = game.height;
        channel = music.Play(false, 0, 0.5f);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);
        if(timeMillis > previousTime + 6000)
        {
            comic.currentFrame++;
            previousTime = timeMillis;
        }      
    }
}
