using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class PlayingUI : UI
{
    Sprite blackImage;
    bool transitionBack;

    public PlayingUI()
    {
        blackImage = new Sprite("Assets/Images/black.png", false);
        blackImage.alpha = 0;
        AddChild(blackImage);
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Empty);

        if (MyGame.Instance.levelManager.isEnteringDoor && transitionBack == false)
        {
            blackImage.alpha += 0.01f;
        }
        if(blackImage.alpha > 1)
        {
            MyGame.Instance.levelManager.SwitchLevel(MyGame.Instance.levelManager.levelDestination);
            transitionBack = true;                      
        }
        if(transitionBack == true)
        {            
            blackImage.alpha -= 0.01f;
        }
        if(blackImage.alpha < 0)
        {
            transitionBack = false;
            MyGame.Instance.levelManager.isEnteringDoor = false;
            blackImage.alpha = 0;
        }
    }
}
