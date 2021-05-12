using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EndLevelScreen : Level
{
    bool startScreen = true;

    public EndLevelScreen()
    {
        currentLevelSize = new Vec2(3840, 2160);
        player = new Player(new Vec2(2000, 1900), 128);    

        cam.SetXY(currentLevelSize.x / 1.333f, currentLevelSize.y / 2f);
        cam.scale = 2f;

        AddChild(cam);

        sceneObjects.Add(player);      
    }

    void Update()
    {
        base.Update();
        //Console.WriteLine("hoi");
        if(startScreen)
        {
            startScreen = false;
            //MyGame.Instance.UserInterfaceManager.RemoveInterface(2);
            MyGame.Instance.UserInterfaceManager.AddInterface(6);
        }
    }
}

