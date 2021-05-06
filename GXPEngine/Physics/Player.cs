using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Entity
{
    private float speed = 5f;
    private float thrustSpeed = 960f;
    private float reachDistance = 1000f;

    private IK leftArm, rightArm;
    private Entity pole;
    private GameObject leftHandTarget, rightHandTarget;

    public Player(Vec2 _position, int _width, int _height = -1) : base("Assets/Sprites/Player/torso.png", _position, _width, _height, true, true, 1, 0)
    {
        pole = new Entity("Assets/Sprites/Player/staff_and_hands.png", new Vec2(0, 0), 256, 1536, false, false, 1, 0); ;

        leftHandTarget = new Sprite("Assets/Sprites/transparency.png", true, false);
        rightHandTarget = new Sprite("Assets/Sprites/transparency.png", true, false);

        leftArm = new IK("Assets/Sprites/Gradient.png", "Assets/Sprites/Gradient.png", new Vec2(-96, -300), 0, leftHandTarget, 768, 384);
        rightArm = new IK("Assets/Sprites/Gradient.png", "Assets/Sprites/Gradient.png", new Vec2(192, -300), 180, rightHandTarget, 768, 384);


        AddChild(leftHandTarget);
        AddChild(rightHandTarget);

        AddChild(leftArm);
        AddChild(rightArm);
        AddChild(pole);
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

        Vec2 poleTargetPos = new Vec2(1f, 0f);

        float poleTargetRotation = Mathf.Atan2(y - Input.mouseY, x - Input.mouseX) * Vec2.Rad2Deg + 180f;
        float distanceFromMouse = Mathf.Clamp((position - new Vec2(Input.mouseX, Input.mouseY)).Length() * 12f, 0, reachDistance);
        poleTargetPos.RotateDegrees(poleTargetRotation);
        poleTargetPos *= distanceFromMouse;

        pole.SetXY(poleTargetPos.x, poleTargetPos.y);
        pole.rotation = poleTargetRotation - 90;

        Vec2 leftHandTargetPos = poleTargetPos - new Vec2(pole.TransformDirection(-960, 4096));
        Vec2 rightHandTargetPos = poleTargetPos - new Vec2(pole.TransformDirection(960, 4096));

        leftHandTarget.SetXY(leftHandTargetPos.x, leftHandTargetPos.y);
        rightHandTarget.SetXY(rightHandTargetPos.x, rightHandTargetPos.y);

        Gizmos.DrawCross(leftHandTargetPos.x, leftHandTargetPos.y, 64, this, 0x000000, 2);
        Gizmos.DrawPlus(rightHandTargetPos.x, rightHandTargetPos.y, 64, this, 0x000000, 2);

        leftArm.Step();
        rightArm.Step();

        if (IsGrounded() && Input.GetMouseButtonDown(0))
        {
            position += new Vec2(0, 5f);
            skipResolve = true;
            Vec2 thrustForce = new Vec2(0, -thrustSpeed);
            thrustForce.RotateDegrees(pole.rotation);
            rigidbody.AddForce(thrustForce);
        }
    }
}
