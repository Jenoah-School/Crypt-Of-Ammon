using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class EndScreen : UI
{
    AnimationSprite comic;
    float previousTime;

    bool canPlaySound = true;

    SoundChannel channel;
    Sound music;

    public EndScreen()
    {
        comic = new AnimationSprite("Assets/Sprites/Comic/comic2.png", 3, 1, 3, false, false);
        music = new Sound("Assets/Sounds/fa_lullaby_loop.mp3");
        AddChild(comic);
        comic.width = game.width;
        comic.height = game.height;
    }

    void Update()
    {
        MyGame.Instance.levelManager.ingameMusic.IsPaused = true;
        base.Update();
        graphics.Clear(Color.Black);

        if (canPlaySound) channel = music.Play(false, 0, 0.5f); canPlaySound = false;
        Console.WriteLine(channel.Volume);

        if (timeMillis > previousTime + 5000)
        {
            comic.currentFrame++;
            previousTime = timeMillis;
        }
        if (timeMillis > 15000)
        {
            comic.alpha -= 0.001f;
            channel.Volume -= 0.0005f;
        }
        Console.WriteLine($"Volume: {channel.Volume}");
        if(channel.Volume < 0)
        {
            Console.WriteLine("Transitioning");
            MyGame.Instance.UserInterfaceManager.RemoveInterface(6);
            MyGame.Instance.UserInterfaceManager.AddInterface(2);
            ((MainMenu)MyGame.Instance.UserInterfaceManager.UserInterfaces[2]).backgroundImage.alpha = 1f;
            ((MainMenu)MyGame.Instance.UserInterfaceManager.UserInterfaces[2]).isTransitioning = false;
            ((MainMenu)MyGame.Instance.UserInterfaceManager.UserInterfaces[2]).canPlaySound = true;
            ((MainMenu)MyGame.Instance.UserInterfaceManager.UserInterfaces[2]).channel.Volume = 0.5f;
            channel.Volume = 0;
        }
        if(comic.alpha < 0)
        {
            comic.alpha = 0;         
        }
    }
}
