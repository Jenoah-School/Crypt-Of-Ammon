using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class MainMenu : UI
{
    Sprite backgroundImage;

    SoundChannel channel;
    Sound sound;

    Button startButton;
    Button endButton;

    bool canPlaySound = true;

    bool isTransitioning;


    public MainMenu()
    {
        MyGame.Instance.levelManager.currentLevel.canMove = true;

        backgroundImage = new Sprite("Assets/Images/mainMenuTheme.jpg", false, false);
        backgroundImage.height = (int)(game.width * ((float)backgroundImage.height / (float)backgroundImage.width));
        backgroundImage.width = game.width;
        backgroundImage.height = game.height;

        startButton = new Button();
        startButton.scale = 0.5f;
        startButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 2.35f);

        endButton = new Button();
        endButton.scale = 0.5f;
        endButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 2.05f);

        sound = new Sound("Assets/Sounds/mainMenu.mp3");

        AddChild(backgroundImage);
        AddChild(startButton);
        AddChild(endButton);
    }

    void Update()
    {
        base.Update();
        Transition();
        graphics.Clear(Color.Black);

        if (canPlaySound) channel = sound.Play(false, 0, 0.5f); canPlaySound = false;

        if (startButton.IsClicked())
        {
            isTransitioning = true;       
            
        }

        if(endButton.IsClicked())
        {
            game.Destroy();
        }     
    }

    void Transition()
    {
        if (isTransitioning)
        {
            backgroundImage.alpha *= 0.95f;
            channel.Volume *= 0.95f;
        }
        if(backgroundImage.alpha < 0.001f)
        {
            MyGame.Instance.UserInterfaceManager.AddInterface(3);            
            MyGame.Instance.levelManager.currentLevel.canMove = true;
        }
        if(backgroundImage.alpha < 0.0009f)
        {
            MyGame.Instance.UserInterfaceManager.RemoveInterface(2);
        }
    }
}

