using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Threading.Tasks;
using System.Drawing;

public class UI : Canvas
{
    public float timeMillis = 0;
    public float timeSeconds = 0;
    public UI() : base(1920, 1080, false)
    {
        
    }

    protected virtual void Update()
    {
        width = Mathf.Round(game.width * 1.51f);
        height = Mathf.Round(game.height * 1.51f);

        x = MyGame.Instance.levelManager.currentLevel.cam.x - 1443;
        y = MyGame.Instance.levelManager.currentLevel.cam.y - 810;

        timeMillis += Time.deltaTime;
        timeSeconds = Mathf.Round(timeMillis / 1000);
    }
}

