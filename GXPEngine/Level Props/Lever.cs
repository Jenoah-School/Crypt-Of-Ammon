using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Lever : Entity
{
    private bool isTriggered = false;

    private Sound triggerSound = null;

    public Lever(string _filename, Vec2 _position, int _width) : base(_filename, _position, _width, -1, false, false, float.PositiveInfinity, 0f)
    {
        SetOrigin(width / 2, height);
        triggerSound = new Sound("Assets/Audio/SoundFX/fa_lever.mp3");
        rotation = 45f;
    }

    public void SetTriggerEvent(Action _triggerEvent)
    {
        _collisionEvent = _triggerEvent;
    }

    private void PlayTriggerSound()
    {
        if (triggerSound != null)
        {
            triggerSound.Play();
        }
    }

    void Update()
    {
        if (!isTriggered && Input.GetKeyUp(Key.ENTER))
        {
            if ((MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 256)
            {
                isTriggered = true;
                _collisionEvent.Invoke();
                rotation = -45f;
                PlayTriggerSound();
            }
        }
    }
}
