using GXPEngine;
class IK : GameObject
{
    IKSegment upperArm, lowerArm;
    GameObject target;

    int halfWidth = 0;
    public IK(string _upperArmfilename, string _lowerArmfilename, Vec2 _position, float _startAngle, GameObject _target, int _width, int _height = -1)
    {
        halfWidth = (int)(_width / 2f);
        //position = _position;
        //SetOrigin(_width, height / 2);

        target = _target;

        upperArm = new IKSegment(_upperArmfilename, new Vec2(0, 0), _startAngle);
        lowerArm = new IKSegment(_lowerArmfilename, upperArm);
        //upperArm.SetColor(1, 0, 0);

        SetXY(_position.x, _position.y);

        AddChild(upperArm);
        AddChild(lowerArm);

    }

    public void Step()
    {
        //Lower is 1; Upper is 0;
        upperArm.Follow(new Vec2(target.x, target.y));
        upperArm.Step();

        lowerArm.Follow();
        lowerArm.Step();

        lowerArm.SetStartPos(new Vec2(0,0));
        upperArm.SetStartPos(lowerArm.targetPos);

        //Gizmos.DrawPlus(upperArm.startPos.x, upperArm.startPos.y, 64, this, 0x000000, 2);
        //Gizmos.DrawPlus(upperArm.targetPos.x, upperArm.targetPos.y, 128, this, 0x000000, 2);

        //Gizmos.DrawCross(lowerArm.startPos.x, lowerArm.startPos.y, 64, this, 0x000000, 2);
        //Gizmos.DrawCross(lowerArm.targetPos.x, lowerArm.targetPos.y, 128, this, 0x000000, 2);
    }
}

class IKSegment : Sprite
{
    IKSegment parentSegment = null;
    public Vec2 startPos;
    public Vec2 targetPos;
    public float angle = 0;

    public IKSegment(string _fileName, Vec2 _startPos, float _startAngle) : base(_fileName, false, false)
    {
        SetOrigin(0, height / 2f);
        rotation = _startAngle;
        angle = _startAngle * Vec2.Deg2Rad;
        startPos = _startPos;
        CalculateTargetPosition();
        SetXY(startPos.x, startPos.y);
    }

    public IKSegment(string _fileName, IKSegment _parent) : base(_fileName, false, false)
    {
        SetOrigin(0, height / 2f);
        parentSegment = _parent;
        angle = _parent.angle;
        startPos = parentSegment.targetPos;
        CalculateTargetPosition();
        SetXY(startPos.x, startPos.y);
    }

    public void Step()
    {
        rotation = angle * Vec2.Rad2Deg;
        CalculateTargetPosition();
        SetXY(startPos.x, startPos.y);
    }

    public void SetStartPos(Vec2 _startPos)
    {
        startPos = _startPos;
        CalculateTargetPosition();
    }

    public void Follow()
    {
        Follow(parentSegment.startPos);
    }

    public void Follow(Vec2 _targetPosition)
    {
        Vec2 direction = _targetPosition - startPos;
        direction.Normalize();
        angle = direction.GetAngleRadians();
        direction *= width;
        startPos = _targetPosition - direction;
    }

    private void CalculateTargetPosition()
    {
        targetPos = new Vec2(Mathf.Cos(angle), Mathf.Sin(angle)) * width - startPos;
        Gizmos.DrawPlus(targetPos.x, targetPos.y, 15);
    }
}