using GXPEngine;
using System;
using System.Linq;

class Trigger : Entity
{
    private bool isPressed = false;
    private bool previousState = false;
    private bool isPermanent = false;

    private bool isPermanentAndTriggered = false;
    private Action untriggerEvent = null;

    private Sound triggerSound = null;

    public Trigger(string _filename, Vec2 _position, int _width, int _height = -1, bool _isPermanent = false) : base(_filename, _position, _width, _height, false, true, float.PositiveInfinity, 0f)
    {
        isPermanent = _isPermanent;
        //MyGame.Instance.currentLevel.pressureTriggers.Add(this);
        triggerSound = new Sound("Assets/Audio/SoundFX/plate-long.mp3");
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
        if (isPermanentAndTriggered)
        {
            return;
        }

        isPressed = false;
        foreach (Entity _sender in MyGame.Instance.currentLevel.pressureSenders.ToList())
        {
            if (HitTest(_sender))
            {
                isPressed = true;
                break;
            }
        }

        if (isPressed != previousState)
        {
            if (isPressed)
            {
                _collisionEvent.Invoke();
                    PlayTriggerSound();
                if (isPermanent)
                {
                    isPermanentAndTriggered = true;
                }
            }
            else
            {
                untriggerEvent.Invoke();
            }
        }

        previousState = isPressed;
    }
}
