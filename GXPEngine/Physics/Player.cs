using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Entity
{
    private float speed = 400f;
    public Player(Vec2 _position, int _width) : base("Assets/Sprites/playerTest.png", _position, _width, -1, true, true, 1, 0, 3, 3, 9)
    {    
        scale *= 2;       
        SetCycle(0, 3, 255, true);
    }

    public void Update()
    {
        rigidbody.velocity.x *= 0.1f;
        HandleInput();
        SetPlayerAnimations();
    }

    public void HandleInput()
    {
        rigidbody.AddForce(new Vec2(speed, 0) * GameBehaviour.GetHorizontalAxis());
        if (Input.GetKeyDown(Key.SPACE))
        {
            rigidbody.AddForce(new Vec2(0, -1000f), false);
        }
    }

    public void SetPlayerAnimations()
    {
        
    }
}
