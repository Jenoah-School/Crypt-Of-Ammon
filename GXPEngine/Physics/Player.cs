using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player : Entity
{
    private float speed = 5f;
    public Player(Vec2 _position, int _width) : base("Assets/Sprites/square.png", _position, _width, -1, true, true, 1, 0)
    {

    }

    public void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        rigidbody.AddForce(new Vec2(speed, 0) * GameBehaviour.GetHorizontalAxis());
        if (Input.GetKeyDown(Key.SPACE)){
            rigidbody.AddForce(new Vec2(0, -382f), false);
        }
    }
}
