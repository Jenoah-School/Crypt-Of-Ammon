using GXPEngine;
using System.Collections.Generic;
using System.Linq;

public class Level : GameObject
{
    public List<Entity> sceneObjects = new List<Entity>();

    public List<Entity> pressureTriggers = new List<Entity>();
    public List<Entity> pressureSenders = new List<Entity>();

    public Player player = null;

    public Sprite backgroundImage;

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

        //Start audio (again)
    }

    protected virtual void Update()
    {
        foreach (Entity _ent in sceneObjects.ToList())
        {
            if (_isLoaded == false) return;
            foreach (Entity _ent in sceneObjects)
            {
                _ent.Step();
            }
        }
        SetCameraPosition();

    public virtual void Unload()
    {
        //if (!string.IsNullOrEmpty(_backgroundImage))
        //{
        //    backgroundImage = new Sprite(_backgroundImage, false, false);
        //    float aspectRatio = (float)backgroundImage.height / (float)backgroundImage.width;
        //    backgroundImage.width = game.width;
        //    backgroundImage.height = (int)(backgroundImage.width * aspectRatio);

        //    AddChild(backgroundImage);
        //}

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
