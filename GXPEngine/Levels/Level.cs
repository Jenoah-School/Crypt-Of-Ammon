using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level : GameObject
{
    protected List<Entity> sceneObjects = new List<Entity>();

    public Level(string _backgroundImage = "")
    {
        //_backgroundImage can be kept empty to use no background
        AddBackGround(_backgroundImage);
    }

    public virtual void Load()
    {
        //Start audio (again)
    }

    protected virtual void Update()
    {
        foreach(Entity _ent in sceneObjects)
        {
            _ent.Step();
        }
    }

    protected void AddBackGround(string _backgroundImage)
    {
        if (!string.IsNullOrEmpty(_backgroundImage))
        {
            Sprite backgroundImage = new Sprite(_backgroundImage, false, false);
            float aspectRatio = (float)backgroundImage.height / (float)backgroundImage.width;
            backgroundImage.width = game.width;
            backgroundImage.height = (int)(backgroundImage.width * aspectRatio);

            AddChild(backgroundImage);
        }
    }

    public virtual void Unload()
    {
        //Stop audio
    }
}
