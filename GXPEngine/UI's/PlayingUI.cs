using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;

class PlayingUI : UI
{
    public PlayingUI()
    {
            
    }

    void Update()
    {
        base.Update();
        graphics.Clear(Color.Empty);
        graphics.DrawString(timeSeconds.ToString() + " scene 1", new Font("Arial", 40), Brushes.White, 0, 0);
        if(timeSeconds == 5)
        {
            //MyGame.Instance.UserInterfaceManager.SwitchInterface(1);
        }
    }
}

