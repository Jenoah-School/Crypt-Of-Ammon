using System;
using System.Collections.Generic;
using System.Linq;
using GXPEngine;
using System.Text;
using System.Threading.Tasks;

class Door : Entity
{
    int levelDestination;
    public bool isOpened;
    public bool isTransitioning;
    public Sound doorOpenSound;
    private Sprite transition;

    public Door(Vec2 position, int width, int height, int levelDestination, bool isOpened) : base("Assets/Sprites/door.png", position, width, height, false, false, float.PositiveInfinity, 1, 2, 1, 2)
    {
        SetXY(position.x, position.y);
        if(isOpened == true) SetCycle(1, 1, 255, true);
        if(isOpened == false) SetCycle(0, 1, 255, true);
        this.isOpened = isOpened;
        this.levelDestination = levelDestination;
        doorOpenSound = new Sound("Assets/Sounds/fa_sfx_door.mp3");

        transition = new Sprite("Assets/Sprites/transition.png", false);
        transition.SetOrigin(transition.width /2, transition.height /2);
        AddChild(transition);
        transition.scale *= 80;
    }

    void Update()
    {
        Transition();
        CheckIfPlayerIsNear();
    }

    void Transition()
    {
        if (isTransitioning)
        {
            if (transition.scale > 0.6f)
            {
                transition.scale *= 0.96f;
            }
            if (transition.scale < 0.61f)
            {
                MyGame.Instance.levelManager.SwitchLevel(levelDestination);             
                isTransitioning = false;
                transition.scale = 80;
            }
        }
    }

    void CheckIfPlayerIsNear()
    {
       if((MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 100)
       {
            if(Input.GetKeyUp(Key.ENTER) && isOpened == true)
            {
                isTransitioning = true;            
            }
        }
    }
}

