using System;
using GXPEngine; // Allows using Mathf functions
using GXPEngine.Core;

public struct Vec2
{
    public float x;
    public float y;

    public static float Deg2Rad = Mathf.PI / 180f;
    public static float Rad2Deg = 180f / Mathf.PI;

    public Vec2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }

    public Vec2(Vector2 vec)
    {
        x = vec.x;
        y = vec.y;
    }

    public float Length()
    {
        float length = Mathf.Sqrt(x * x + y * y);
        length = float.IsNaN(length) ? 1 : length;

        return length;
    }

    public float SqrLength()
    {
        float squaredLength = x * x + y * y;
        squaredLength = float.IsNaN(squaredLength) ? 1 : squaredLength;
        return squaredLength;
    }

    public void Normalize()
    {
        float length = Length();
        length = float.IsNaN(length) || length == 0 ? 1 : length;
        this = new Vec2(x, y) / length;
    }

    public Vec2 Normalized()
    {
        float length = Length();
        length = float.IsNaN(length) || length == 0 ? 1 : length;
        Vec2 normalizedVector = new Vec2(x, y) / length;

        return normalizedVector;
    }

    public void SetXY(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    public static Vec2 Lerp(Vec2 _A, Vec2 _B, float t)
    {
        return _A * t + _B * (1f - t);
    }

    // TODO: Implement subtract, scale operators

    public static Vec2 operator *(Vec2 _A, Vec2 _B)
    {
        _A.x *= _B.x;
        _A.y *= _B.y;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static Vec2 operator *(Vec2 _A, float _B)
    {
        _A.x *= _B;
        _A.y *= _B;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static Vec2 operator *(float _A, Vec2 _B)
    {
        _B.x *= _A;
        _B.y *= _A;

        _B.x = float.IsNaN(_B.x) ? 0 : _B.x;
        _B.y = float.IsNaN(_B.y) ? 0 : _B.y;

        return _B;
    }

    public static Vec2 operator -(Vec2 _A, Vec2 _B)
    {
        _A.x -= _B.x;
        _A.y -= _B.y;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static Vec2 operator -(Vec2 _A, float _B)
    {
        _A.x -= _B;
        _A.y -= _B;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static Vec2 operator /(Vec2 _A, Vec2 _B)
    {
        _A.x /= _B.x;
        _A.y /= _B.y;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static Vec2 operator /(Vec2 _A, float _B)
    {
        _A.x /= _B;
        _A.y /= _B;

        _A.x = float.IsNaN(_A.x) ? 0 : _A.x;
        _A.y = float.IsNaN(_A.y) ? 0 : _A.y;

        return _A;
    }

    public static bool operator ==(Vec2 _A, Vec2 _B)
    {

        return _A.Equals(_B);
    }

    public static bool operator !=(Vec2 _A, Vec2 _B)
    {
        return !_A.Equals(_B);
    }

    public static Vec2 operator +(Vec2 _left, Vec2 _right)
    {
        return new Vec2(_left.x + _right.x, _left.y + _right.y);
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }

    public void RotateDegrees(float _angle)
    {
        _angle *= Deg2Rad;

        RotateRadians(_angle);
    }

    public void RotateRadians(float _angle)
    {
        float sin = Mathf.Sin(_angle);
        float cos = Mathf.Cos(_angle);

        //this = new Vec2(x * cos - y * sin, x * sin + y * cos);
        this = new Vec2(x * cos - y * sin, x * sin + y * cos);
    }

    public void RotateAroundDegrees(Vec2 _rotationPoint, float _angleDeg)
    {
        RotateDegrees(_angleDeg);
        this -= _rotationPoint;
    }

    public void RotateAroundRadians(Vec2 _rotationPoint, float _angleRad)
    {
        RotateRadians(_angleRad);
        this -= _rotationPoint;
    }

    public float LookAt(Vec2 _target)
    {
        float deltaX = _target.x - x;
        float deltaY = _target.y - y;

        return Mathf.Atan2(deltaY, deltaX) * Rad2Deg;
    }

    public static Vec2 GetUnitVectorDeg(float _angleDeg)
    {
        Vec2 inputVector = new Vec2(1, 0);

        inputVector.RotateDegrees(_angleDeg);

        return inputVector;
    }

    public static Vec2 GetUnitVectorRad(float _angleRad)
    {
        Vec2 inputVector = new Vec2(1, 0);

        inputVector.RotateRadians(_angleRad);

        return inputVector;
    }

    public static Vec2 RandomUnitVector()
    {
        Random rand = new Random();
        Vec2 inputVector = new Vec2(1, 0);

        inputVector.RotateDegrees(rand.Next(0, 360));
        return inputVector;
    }

    public void SetAngleDegrees(float _angleDeg)
    {
        SetAngleRadians(_angleDeg * Deg2Rad);
    }

    public void SetAngleRadians(float _angleRad)
    {
        float magnitude = Length();

        x = Mathf.Cos(_angleRad);
        y = Mathf.Sin(_angleRad);

        this *= magnitude;
    }

    public float GetAngleDegrees()
    {
        return GetAngleRadians() * Vec2.Rad2Deg;
    }

    public float GetAngleRadians()
    {
        return Mathf.Atan2(y, x);
    }

    public Vec2 Normal()
    {
        return new Vec2(-y, x).Normalized();
    }

    public float Dot(Vec2 _normal)
    {
        return Length() * _normal.Length() * Mathf.Cos(GetAngleRadians() - _normal.GetAngleRadians());
    }

    public void Reflect(Vec2 _normal, float _bounciness = 1)
    {
        _normal.Normalize();
        this -= (1 + _bounciness) * Dot(_normal) * _normal;
    }

    public override string ToString()
    {
        return String.Format("({0}, {1})", x, y);
    }
}

