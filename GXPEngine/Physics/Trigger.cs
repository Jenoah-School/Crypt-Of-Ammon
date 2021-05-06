using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Trigger : Entity
{
    private bool isPressed = false;
    private bool previousState = false;
    private bool isPermanent = false;

    private bool isPermanentAndTriggered = false;
    private Action untriggerEvent = null;

    public Trigger(string _filename, Vec2 _position, int _width, int _height = -1, bool _isPermanent = false) : base(_filename, _position, _width, _height, false, true, float.PositiveInfinity, 0f)
    {
        isPermanent = _isPermanent;
        //MyGame.Instance.currentLevel.pressureTriggers.Add(this);
    }

    public void SetTriggerEvent(Action _triggerEvent)
    {
        _collisionEvent = _triggerEvent;
    }

    public void SetUntriggerEvent(Action _untriggerEvent)
    {
        untriggerEvent = _untriggerEvent;
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
