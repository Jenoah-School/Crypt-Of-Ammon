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

    public Door(Vec2 position, int width, int height, int levelDestination, bool isOpened) : base("Assets/Sprites/LevelProps/Door_Sprite_Sheet_01.png", position, width, height, false, false, float.PositiveInfinity, 1, 1, 5, 5)
    {
        SetXY(position.x, position.y);  
        this.isOpened = isOpened;
        this.levelDestination = levelDestination;
        doorOpenSound = new Sound("Assets/Sounds/fa_sfx_door.mp3");
    }

    void Update()
    {
        CheckIfPlayerIsNear();
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

