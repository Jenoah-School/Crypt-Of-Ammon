using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Entity
{
    private float speed = 400f;
    private Camera cam;
    Animation playerAnimations;
    public Player(Vec2 _position, int _width) : base("Assets/Sprites/empty.png", _position, _width, -1, true, true, 1, 0)
    {
        cam = new Camera(0,0, 1920, 1080);
        playerAnimations = new Animation("Assets/Sprites/animationTest.png", 4, 4, new Vec2(-30,-60));
        playerAnimations.SetAnimationCycle(8, 4, 255, true);
       
        AddChild(cam);
        AddChild(playerAnimations);
        //cam.scale *= 5;
        cam.SetXY(game.width / 3.3f, game.height / 10);
    }

    public void Update()
    {
        rigidbody.velocity.x *= 0.1f;
        HandleInput();
        SetCameraBoundaries();
        SetPlayerAnimations();
    }

    public void HandleInput()
    {
        rigidbody.AddForce(new Vec2(speed, 0) * GameBehaviour.GetHorizontalAxis());
        if (Input.GetKeyDown(Key.SPACE))
        {
            rigidbody.AddForce(new Vec2(0, -1000f), false);
        }
        if(Input.GetKeyDown(Key.P))
        {
            playerAnimations.SetAnimationCycle(4, 4, 255, true);
        }
    }

    public void SetCameraBoundaries()
    {
        if (x < 600 || x > 3275)
        {
            cam.x -= rigidbody.velocity.x;
        }
    }

    public void SetPlayerAnimations()
    {
        if ((position - previousPosition).x < 0)
        {
            playerAnimations.SetAnimationCycle(8, 4, 255, true);
        }
        if ((position - previousPosition).x > 0)
        {
            playerAnimations.SetAnimationCycle(12, 4, 255, true);
        }
        if ((position - previousPosition).x == 0 && rigidbody.velocity.y == 0)
        {
            playerAnimations.SetAnimationCycle(0, 4, 255, true);
        }
    }
}
