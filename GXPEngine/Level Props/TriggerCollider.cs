using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class TriggerCollider : Entity
{
    private bool isPressed = false;
    private bool previousState = false;

    private Action untriggerEvent = null;

    private Sound triggerSound = null;

    public TriggerCollider(string _filename, Vec2 _position, int _width, int _height = -1) : base(_filename, _position, _width, _height, false, true, float.PositiveInfinity, 0f)
    {

    }

    public void SetTriggerEvent(Action _triggerEvent)
    {
        _collisionEvent = _triggerEvent;
    }

    public void SetUntriggerEvent(Action _untriggerEvent)
    {
        untriggerEvent = _untriggerEvent;
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
        isPressed = false;
        if (HitTest(MyGame.Instance.levelManager.currentLevel.player))
        {
            isPressed = true;
        }

        if (isPressed != previousState)
        {
            if (isPressed)
            {
                _collisionEvent.Invoke();
                PlayTriggerSound();
            }
            else
            {
                untriggerEvent.Invoke();
            }
        }

        previousState = isPressed;
    }
}
