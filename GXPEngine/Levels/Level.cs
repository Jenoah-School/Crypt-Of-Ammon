using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level : GameObject
{
    protected List<Entity> sceneObjects = new List<Entity>();

    public Level()
    {

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

    public virtual void Unload()
    {

    }
}
