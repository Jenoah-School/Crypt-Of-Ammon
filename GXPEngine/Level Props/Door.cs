using System;
using System.Collections.Generic;
using System.Linq;
using GXPEngine;
using System.Text;
using System.Threading.Tasks;

public class Door : Entity
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

    private EasyDraw interactText = null;

    public Door(Vec2 position, int width, int height, int levelDestination, bool isOpened) : base("Assets/Sprites/LevelProps/Door_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 1, 5, 5)
    {
        SetXY(position.x, position.y);
        SetCycle(0, 10, 255, false);
        this.isOpened = isOpened;
        this.levelDestination = levelDestination;
        doorOpenSound = new Sound("Assets/Sounds/fa_doorOpen.mp3");
        doorCloseSound = new Sound("Assets/Sounds/fa_doorClose_short.mp3");

        interactText = new EasyDraw(384, 256, false);
    }

    public void AddUIText(GameObject _parentObject)
    {
        interactText.TextSize(36);
        interactText.NoStroke();
        interactText.TextAlign(CenterMode.Center, CenterMode.Center);
        interactText.Text("Press 'ENTER'\n    to advance", interactText.width / 2f, interactText.height / 2f);
        interactText.SetXY(position.x - 192, position.y - height);

        _parentObject.AddChild(interactText);
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
       if((MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 150)
       {
            if (isOpened)
            {
                interactText.visible = true;
                if (Input.GetKeyUp(Key.ENTER) && MyGame.Instance.levelManager.isEnteringDoor == false)
                {
                    MyGame.Instance.levelManager.isEnteringDoor = true;
                    MyGame.Instance.levelManager.levelDestination = levelDestination;
                }
            }
        }
        else
        {
            interactText.visible = false;
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

