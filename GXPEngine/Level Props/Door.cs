using System;
using System.Collections.Generic;
using System.Linq;
using GXPEngine;
using System.Text;
using System.Threading.Tasks;

public class Door : Entity
{
    int levelDestination;
    public bool isOpened;
    public Sound doorOpenSound;
    public float previousTime = 0;

    bool canPlaySound;

    public bool isOpening;
    public bool isClosing;

    public Door(Vec2 position, int width, int height, int levelDestination, bool isOpened) : base("Assets/Sprites/LevelProps/Door_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 1, 5, 5)
    {
        SetXY(position.x, position.y);
        SetCycle(0, 10, 255, false);
        this.isOpened = isOpened;
        this.levelDestination = levelDestination;
        doorOpenSound = new Sound("Assets/Sounds/fa_sfx_door.mp3");
    }

    void Update()
    {
        CheckIfPlayerIsNear();
        if(isClosing)
        {
            CloseDoorSlowly();
        }
        if (isOpening)
        {
            OpenDoorSlowly();
        }
        if(currentFrame == 4)
        {
            isOpened = true;
            if (canPlaySound) doorOpenSound.Play(false, 0, 0.5f, 0); canPlaySound = false;
        }
        else
        {
            isOpened = false;
            canPlaySound = true;
        }
    }

    void CheckIfPlayerIsNear()
    {
       if((MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 300)
       {
            if(Input.GetKeyUp(Key.ENTER) && isOpened == true)
            {
                MyGame.Instance.levelManager.SwitchLevel(levelDestination);
            }
        }
    }

    public void OpenDoorSlowly()
    {
        if (Time.time > previousTime + 500)
        {
            currentFrame++;
            previousTime = Time.time;
        }
    }

    public void CloseDoorSlowly()
    {
        if (Time.time > previousTime + 100)
        {
            currentFrame--;
            previousTime = Time.time;
        }
    }
}

