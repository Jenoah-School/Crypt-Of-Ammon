using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level : GameObject
{
    protected List<Entity> sceneObjects = new List<Entity>();

    public Player player;
    public Camera cam;
    private bool _isLoaded;
    public Vec2 currentLevelSize;

    public Level()
    {
        cam = new Camera(0, 0, 1920, 1080);
        cam.scale *= 1.5f;
    }

    public virtual void Load()
    {
        _isLoaded = true;
        MyGame.collisionObjects.Clear();
        for (int i = 0; i < sceneObjects.Count; i++)
        {
            MyGame.collisionObjects.Add(sceneObjects[i].collider);
        }
    }

    protected virtual void Update()
    {
        if (_isLoaded == false) return;
        foreach (Entity _ent in sceneObjects)
        {          
            _ent.Step();
        }
        SetCameraPosition();
    }

    public virtual void Unload()
    {
        MyGame.Instance.RemoveChild(this);
        _isLoaded = false;
    }

    void SetCameraPosition()
    {
        Vec2 lerp = Vec2.Lerp(new Vec2(cam.x, cam.y), new Vec2(player.x + (game.width / 2.19f), player.y), 0.9f);

        if (player.x > 900 && player.x < (currentLevelSize.x - 900))
        {
            cam.SetXY(lerp.x, lerp.y);
        }
        else
        {
            cam.SetXY(cam.x, lerp.y);
        }
    }
}
