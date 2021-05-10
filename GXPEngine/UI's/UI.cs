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

    public UI() : base(MyGame.Instance.width, MyGame.Instance.height, false)
    {

    }

    protected virtual void Update()
    {
        Camera myCamera = MyGame.Instance.levelManager.currentLevel.cam;
        Window myWindow = myCamera._renderTarget;

        width = (int)(myWindow.width * myCamera.scale);
        height = (int)(myWindow.height * myCamera.scale);

        x = myCamera.x - width / 2f;
        y = myCamera.y - height / 2f;

        //x = MyGame.Instance.levelManager.currentLevel.cam.x - 960 * MyGame.Instance.levelManager.currentLevel.cam.scale;
        //y = MyGame.Instance.levelManager.currentLevel.cam.y - 525 * MyGame.Instance.levelManager.currentLevel.cam.scale;

        timeMillis += Time.deltaTime;
        timeSeconds = Mathf.Round(timeMillis / 1000);
    }
}

