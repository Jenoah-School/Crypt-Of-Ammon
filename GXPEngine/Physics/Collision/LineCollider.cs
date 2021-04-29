using GXPEngine;
using GXPEngine.Core;
class LineCollider : Collider
{

    public Vec2 start = new Vec2();
    public Vec2 end = new Vec2();
    public readonly Vec2 normal = new Vec2();

    private readonly Vec2 _originalStart = new Vec2();
    private readonly Vec2 _originalEnd = new Vec2();

    private readonly LineCollider _inversedLine = null;

    public LineCollider(Entity _owner, Vec2 _lineStart, Vec2 _lineEnd, bool _isInversed = false)
    {
        owner = _owner;

        start = _lineStart;
        end = _lineEnd;

        _originalStart = _lineStart;
        _originalEnd = _lineEnd;

        normal = (end - start).Normal();

        if (!_isInversed) _inversedLine = new LineCollider(_owner, _lineEnd, _lineStart, true);

        MyGame.collisionObjects.Add(this);
    }

    public override bool HitTest(Collider other)
    {
        //FIX THIS
        if (other is CircleCollider otherCircleCollider)
        {
            if (Mathf.Abs((owner.position - otherCircleCollider.owner.position).Length()) < otherCircleCollider.radius)
            {
                return true;
            }

        }
        return false;
    }

    public override bool HitTestPoint(float x, float y)
    {
        //FIX THIS
        if (Mathf.Abs((owner.position - new Vec2(x, y)).Length()) < 0)
        {
            return true;
        }

        return false;
    }

    public override float TimeOfImpact(Collider other, float vx, float vy, out Vector2 normal)
    {
        normal = new Vector2();
        return float.MaxValue;
    }

    public override Collision GetCollisionInfo(Collider other)
    {
        if (other is CircleCollider otherCircleCollider)
        {
            Vec2 diffVec = otherCircleCollider.owner.previousPosition - start;

            float a = normal.Dot(diffVec) - otherCircleCollider.radius;
            float b = -normal.Dot(otherCircleCollider.owner.rigidbody.velocity);

            if (b <= 0) return null;

            float t;
            if (a >= 0)
            {
                t = a / b;
                //Console.WriteLine($"Calculated time of {t} where A is {a} and B is {b}");
            }
            else if (a >= -otherCircleCollider.radius)
            {
                t = 0;
            }
            else
            {
                return null;
            }


            if (t <= 1)
            {
                Vec2 POI = otherCircleCollider.owner.previousPosition + otherCircleCollider.owner.rigidbody.velocity * t;

                Vec2 unitLineVector = (start - end).Normalized();
                float distance = unitLineVector.Dot(start - POI);

                if (distance >= 0 && distance <= (start - end).Length())
                {
                    return new Collision(otherCircleCollider, this, normal.ToVector2(), t);
                }
            }

            return null;
        }

        return null;
    }

    public override void ResolveCollision(Collision collision)
    {
        if (collision.self is CircleCollider otherCircleCollider)
        {
            Rigidbody rigidbody = owner.rigidbody;
            Rigidbody otherRigidbody = ((CircleCollider)collision.self).owner.rigidbody;
            otherCircleCollider.owner.position = otherCircleCollider.owner.previousPosition + otherRigidbody.velocity * collision.timeOfImpact;

            Vec2 centerOfMassVel = (rigidbody.mass * rigidbody.velocity + otherRigidbody.mass * otherRigidbody.velocity) / (rigidbody.mass + otherRigidbody.mass);
            Vec2 outputVelocity = rigidbody.velocity - (1f + owner.rigidbody.physicsMaterial.bounciness) * (rigidbody.velocity - centerOfMassVel).Dot(normal) * normal;
            Vec2 otherOutputVelocity = otherRigidbody.velocity - (1f + otherRigidbody.physicsMaterial.bounciness) * ((otherRigidbody.velocity - centerOfMassVel).Dot(normal)) * normal;
            
            rigidbody.velocity = outputVelocity;
            otherRigidbody.velocity = otherOutputVelocity;

            //rigidbody.velocity.Reflect(normal, rigidbody.physicsMaterial.bounciness);
            //otherRigidbody.velocity.Reflect(normal, otherRigidbody.physicsMaterial.bounciness);

        }
    }

    /// <summary>
    /// Sets the offset from of the line relative to the starting positions
    /// </summary>
    /// <param name="_offset">The amount of offset the line should get</param>
    public void SetOffset(Vec2 _offset)
    {
        start = _originalStart + _offset;
        end = _originalEnd + _offset;

        if (_inversedLine != null) _inversedLine.SetOffset(_offset);
    }
}
