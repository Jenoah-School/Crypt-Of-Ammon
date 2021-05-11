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
    private EasyDraw interactText = null;

    public Lever(string _filename, Vec2 _position, int _width) : base(_filename, _position, _width, -1, false, false, float.PositiveInfinity, 0f)
    {
        SetOrigin(width / 2, height);
        triggerSound = new Sound("Assets/Audio/SoundFX/fa_lever.mp3");
        rotation = 45f;

        interactText = new EasyDraw(384, 128, false);
    }

    public void AddUIText(GameObject _parentObject)
    {
        interactText.TextSize(36);
        interactText.NoStroke();
        interactText.TextAlign(CenterMode.Center, CenterMode.Center);
        interactText.Text("Press 'ENTER'\n   to interact", interactText.width / 2f, interactText.height / 2f);
        interactText.SetXY(position.x - 192, position.y - (height * 1.25f));

        _parentObject.AddChild(interactText);
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
        if (!isTriggered && (MyGame.Instance.levelManager.currentLevel.player.position - position).Length() < 256)
        {
            interactText.visible = true;
            if (Input.GetKeyUp(Key.ENTER))
            {
                isTriggered = true;
                _collisionEvent.Invoke();
                rotation = -45f;
                PlayTriggerSound();
            }
        }
        else
        {
            interactText.visible = false;
        }
    }
}
