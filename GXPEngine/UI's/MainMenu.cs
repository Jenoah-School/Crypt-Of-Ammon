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

    Button startButton;
    bool canPlaySound = true;

    public MainMenu()
    {
        MyGame.Instance.levelManager.currentLevel.canMove = true;

        backgroundImage = new Sprite("Assets/Images/mainMenu.jpg", false, false);
        backgroundImage.height = (int)(game.width * ((float)backgroundImage.height / (float)backgroundImage.width));
        backgroundImage.width = game.width;

        titleImage = new Sprite("Assets/Images/logoSimple.png", false, false);
        titleImage.SetOrigin(titleImage.width / 2, titleImage.height / 2);
        titleImage.SetXY(width / 2, height / 5);

        startButton = new Button();
        startButton.SetXY((width / 2) - startButton.width / 2, height / 1.5f);

        sound = new Sound("Assets/Sounds/mainMenu.mp3");

        AddChild(backgroundImage);
        AddChild(startButton);
        AddChild(titleImage);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Black);

        if (canPlaySound) sound.Play(false, 0, 0.5f,0); canPlaySound = false;

        if (startButton.IsClicked())
        {
            Console.WriteLine("CLICK");  
            MyGame.Instance.UserInterfaceManager.RemoveInterface(2);
            MyGame.Instance.UserInterfaceManager.AddInterface(3);
            MyGame.Instance.levelManager.currentLevel.canMove = true;
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

        titleImage.height = (int)(game.width * ((float)titleImage.height / (float)titleImage.width) * 0.5f);
        titleImage.width = (int)(game.width * 0.5f);
        titleImage.SetXY(game.width / 2, game.height / 5);

        startButton.height = (int)(backgroundImage.width * ((float)startButton.height / (float)startButton.width) * 0.125f);
        startButton.width = (int)(backgroundImage.width * 0.125f);
        startButton.SetXY((game.width / 2) - startButton.width / 2, game.height / 1.5f);
    }
}

