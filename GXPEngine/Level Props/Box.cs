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

    public Box(Vec2 _position, int _size) : base("Assets/Sprites/Box_01.png", _position, _size, -1, true, true, 1, 0)
    {
        boxMoveSound = new Sound("Assets/Audio/SoundFX/fa_boxMove.mp3", true);
        boxMoveChannel = boxMoveSound.Play(false, 0, 0, 0);
    }

    void Update()
    {
        float volume = Mathf.Clamp(rigidbody.velocity.Length() / 7f, 0f, 1f);
        boxMoveChannel.Volume = volume;
    }

}
