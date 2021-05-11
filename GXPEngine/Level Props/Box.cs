using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box : Entity
{
    SoundChannel boxMoveChannel;
    Sound boxMoveSound;

    float audioAdjustTime = 1500f;

    public Box(Vec2 _position, int _size) : base("Assets/Sprites/Box_01.png", _position, _size, -1, true, true, 1, 0)
    {
        boxMoveSound = new Sound("Assets/Audio/SoundFX/fa_boxMove.mp3", true);
        boxMoveChannel = boxMoveSound.Play(false, 0, 0, 0);

        audioAdjustTime = Time.time + 1500;
    }

    void Update()
    {
        if (Time.time > audioAdjustTime)
        {
            float volume = Mathf.Clamp(rigidbody.velocity.Length() / 5f, 0f, 1f);
            boxMoveChannel.Volume = volume;
        }
    }

}
