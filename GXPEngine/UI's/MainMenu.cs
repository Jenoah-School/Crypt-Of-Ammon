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

    Sound sound;

    Button startButton;
    Button endButton;
    bool canPlaySound = true;

    public MainMenu()
    {
        MyGame.Instance.levelManager.currentLevel.canMove = true;

        backgroundImage = new Sprite("Assets/Images/mainMenuTheme.jpg", false, false);
        backgroundImage.height = (int)(game.width * ((float)backgroundImage.height / (float)backgroundImage.width));
        backgroundImage.width = game.width;

        startButton = new Button();
        startButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 2.35f);

        endButton = new Button();
        endButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 3.35f);

        sound = new Sound("Assets/Sounds/mainMenu.mp3");

        AddChild(backgroundImage);
        AddChild(startButton);
        AddChild(endButton);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        //if (canPlaySound) sound.Play(false, 0, 0.5f,0); canPlaySound = false;

        if (startButton.IsClicked())
        {
            Console.WriteLine("CLICK");  
            MyGame.Instance.UserInterfaceManager.RemoveInterface(2);
            MyGame.Instance.UserInterfaceManager.AddInterface(3);
            MyGame.Instance.levelManager.currentLevel.canMove = true;
        }

        if(endButton.IsClicked())
        {
            game.Destroy();
        }

        UpdateElements();
    }

    void UpdateElements()
    {
        if (game.width < game.height)
        {
            backgroundImage.height = (int)(game.width * ((float)backgroundImage.height / (float)backgroundImage.width));
            backgroundImage.width = game.width;
        }
        else
        {
            backgroundImage.width = (int)(game.height * ((float)backgroundImage.width / (float)backgroundImage.height));
            backgroundImage.height = game.height;
        }
        startButton.height = (int)(backgroundImage.width * ((float)startButton.height / (float)startButton.width) * 0.05f);
        startButton.width = (int)(backgroundImage.width * 0.05f);
        startButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 2.28f);

        endButton.height = (int)(backgroundImage.width * ((float)startButton.height / (float)startButton.width) * 0.05f);
        endButton.width = (int)(backgroundImage.width * 0.05f);
        endButton.SetXY((game.width / 5.9f) - startButton.width / 2, game.height / 1.95f);
    }
}

