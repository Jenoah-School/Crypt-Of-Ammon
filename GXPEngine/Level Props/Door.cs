using System;
using System.Collections.Generic;
using System.Linq;
using GXPEngine;
using System.Text;
using System.Threading.Tasks;

class Door : Entity
{
    SoundChannel channel;

    int levelDestination;
    public bool isOpened;
    public Sound doorOpenSound;
    public Sound doorCloseSound;
    public float previousTime = 0;

    bool canPlayOpenSound;
    bool canPlayCloseSound;

    public bool isOpening;
    public bool isClosing;

    public Door(Vec2 position, int width, int height, int levelDestination, bool isOpened) : base("Assets/Sprites/LevelProps/Door_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 1, 5, 5)
    {
        SetXY(position.x, position.y);
        SetCycle(0, 10, 255, false);
        this.isOpened = isOpened;
        this.levelDestination = levelDestination;
        doorOpenSound = new Sound("Assets/Sounds/fa_doorOpen.mp3");
        doorCloseSound = new Sound("Assets/Sounds/fa_doorClose_short.mp3");
    }

    void Update()
    {
        CheckIfPlayerIsNear();
        if(isClosing && currentFrame > 0)
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
        }
        else
        {
            isOpened = false;          
        }
        if(currentFrame == 0)
        {
            canPlayOpenSound = true;
            canPlayCloseSound = true;
        }
    }

    void CheckIfPlayerIsNear()
    {
       if((MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 300)
       {
            Console.WriteLine("hoi");
            if(Input.GetKeyUp(Key.ENTER) && isOpened == true)
            {
                MyGame.Instance.levelManager.SwitchLevel(levelDestination);
            }
        }
    }

    public void OpenDoorSlowly()
    {     
        if (canPlayOpenSound) channel = doorOpenSound.Play(); canPlayOpenSound = false;
        if (Time.time > previousTime + 500)
        {
            currentFrame++;
            previousTime = Time.time;
        }
    }

    public void CloseDoorSlowly()
    {
        if (canPlayCloseSound) channel = doorCloseSound.Play(); canPlayCloseSound = false;
        if (Time.time > previousTime + 100)
        {
            currentFrame--;
            previousTime = Time.time;
        }
    }
}

