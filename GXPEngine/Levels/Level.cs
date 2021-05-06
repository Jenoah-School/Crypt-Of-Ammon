using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level : GameObject
{
    public List<Entity> sceneObjects = new List<Entity>();

    public List<Entity> pressureTriggers = new List<Entity>();
    public List<Entity> pressureSenders = new List<Entity>();

    public Player player = null;

    public Sprite backgroundImage;

    public Level(string _backgroundImage = "")
    {
        //_backgroundImage can be kept empty to use no background
        AddBackGround(_backgroundImage);
    }

    public virtual void Load()
    {
        MyGame.collisionObjects.Clear();
        for (int i = 0; i < sceneObjects.Count; i++)
        {
            MyGame.collisionObjects.Add(sceneObjects[i].collider);
        }
        //Start audio (again)
    }

    protected virtual void Update()
    {
        foreach (Entity _ent in sceneObjects.ToList())
        {
            _ent.Step();
        }
    }

    protected void AddBackGround(string _backgroundImage)
    {
        if (!string.IsNullOrEmpty(_backgroundImage))
        {
            backgroundImage = new Sprite(_backgroundImage, false, false);
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
