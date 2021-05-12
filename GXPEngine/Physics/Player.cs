
using GXPEngine;
using System;

public class Player : Entity
{
    public Vec2 levelOffset = new Vec2();

    private float speed = 5f;
    private float thrustSpeed = 2256f;
    private float reachDistance = 260f;
    private float lastThrustTime = 0f;
    private float thrustDelay = 750f;

    public bool hasStaff = true;
    public bool canMove = true;

    private IK leftArm, rightArm;
    private Entity pole;
    private GameObject leftHandTarget, rightHandTarget;

    private Sound thurstSound = null;
    private Vec2 mousePlayerPosition;

    public Player(Vec2 _position, int _width, int _height = -1) : base("Assets/Sprites/Player/torso.png", _position, _width, _height, true, true, 1, 0)
    {
        pole = new Entity("Assets/Sprites/Player/handStaff.png", new Vec2(0, 0), 96, 576, false, false, 1, 0);
        pole.SetOrigin(pole.width / 2, pole.height / 2f);

        leftHandTarget = new Sprite("Assets/Sprites/transparency.png", true, false);
        rightHandTarget = new Sprite("Assets/Sprites/transparency.png", true, false);

        leftArm = new IK("Assets/Sprites/Player/leftHand.png", "Assets/Sprites/Player/leftArm.png", new Vec2(-128, -128), 0, leftHandTarget, 1, -1);
        rightArm = new IK("Assets/Sprites/Player/leftHand.png", "Assets/Sprites/Player/leftArm.png", new Vec2(128, -128), 0, rightHandTarget, 1, -1);

        thurstSound = new Sound("Assets/Audio/SoundFX/thrust.wav");

        AddChild(leftHandTarget);
        AddChild(rightHandTarget);

        AddChild(leftArm);
        AddChild(rightArm);
        AddChild(pole);

        lastThrustTime = Time.time - thrustDelay;
    }

    public void Update()
    {
        if (MyGame.Instance.HasChild(MyGame.Instance.UserInterfaceManager) && !MyGame.Instance.UserInterfaceManager.HasChild(MyGame.Instance.UserInterfaceManager.UserInterfaces[4]) || canMove == false)
        {
            return;
        }
        pole.visible = hasStaff;

        if (IsGrounded())
            rigidbody.velocity.x *= 0.96f;
        HandleInput();
        PositionArms();

        Camera myCamera = MyGame.Instance.levelManager.currentLevel.cam;
        Window myWindow = myCamera._renderTarget;

        float windowCenterX = myWindow.windowX + myWindow.width / 2f;
        float windowCenterY = myWindow.windowY + myWindow.height / 2f;

        Vec2 mousePosition = new Vec2(Input.mouseX, Input.mouseY);
        Vec2 camSpacePosition = mousePosition - new Vec2(windowCenterX, windowCenterY);
        Vec2 worldSpacePosition = new Vec2(myCamera.TransformPoint(camSpacePosition.x, camSpacePosition.y));
        mousePlayerPosition = new Vec2(InverseTransformPoint(worldSpacePosition.x, worldSpacePosition.y));
    }

    public void HandleInput()
    {
        if (!((Level)parent).canMove)
                return;

        if (Input.GetKeyDown(Key.SPACE))
        {
            rigidbody.AddForce(new Vec2(0, -382f), false);
        }

        if (IsGrounded())
        {
            rigidbody.AddForce(new Vec2(speed, 0) * GameBehaviour.GetHorizontalAxis());
            if (Input.GetMouseButtonDown(0) && hasStaff)
            {
                Thrust();
            }
        }
        else
        {
            rigidbody.AddForce(new Vec2(speed / 4f, 0) * GameBehaviour.GetHorizontalAxis());
        }
    }

    private void PositionArms()
    {
        Vec2 poleTargetPos = new Vec2(1f, 0f);

        float poleTargetRotation = Mathf.Atan2(mousePlayerPosition.y, mousePlayerPosition.x) * Vec2.Rad2Deg;
        float distanceFromMouse = Mathf.Clamp(new Vec2(mousePlayerPosition.x, mousePlayerPosition.y).Length() * 1f, 0, reachDistance);
        poleTargetPos.RotateDegrees(poleTargetRotation);
        poleTargetPos *= distanceFromMouse;

        pole.SetXY(poleTargetPos.x, poleTargetPos.y);
        pole.rotation = poleTargetRotation + 90;

        Vec2 leftHandTargetPos = new Vec2(pole.x, pole.y) - new Vec2(TransformDirection(-256, 0));
        Vec2 rightHandTargetPos = new Vec2(pole.x, pole.y) - new Vec2(TransformDirection(256, 0));

        leftHandTarget.SetXY(leftHandTargetPos.x, leftHandTargetPos.y);
        rightHandTarget.SetXY(rightHandTargetPos.x, rightHandTargetPos.y);

        //Gizmos.DrawCross(leftHandTargetPos.x, leftHandTargetPos.y, 64, this, 0x000000, 2);
        //Gizmos.DrawPlus(rightHandTargetPos.x, rightHandTargetPos.y, 64, this, 0x000000, 2);

        leftArm.Step();
        rightArm.Step();
    }

    private void Thrust()
    {
        if (lastThrustTime + thrustDelay < Time.time)
        {
            lastThrustTime = Time.time;
            position += new Vec2(0, 5f);
            skipResolve = true;
            Vec2 thrustForce = new Vec2(0, thrustSpeed);
            thrustForce.RotateDegrees(pole.rotation);
            rigidbody.AddForce(thrustForce);
            if (thurstSound != null)
            {
                thurstSound.Play();
            }
        }
    }
}
