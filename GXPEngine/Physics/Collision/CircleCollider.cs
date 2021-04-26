using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class CircleCollider : Collider
{
    public readonly Entity owner;
    public readonly int radius = 6;

    public CircleCollider(Entity owner, int radius = 6)
    {
        this.owner = owner;
        this.radius = radius;
    }

    public override bool HitTest(Collider other)
    {
        if (other is CircleCollider otherCircleCollider)
        {
            if (Mathf.Abs((owner.position - otherCircleCollider.owner.position).Length()) < radius + otherCircleCollider.radius)
            {
                return true;
            }

        }
        return false;
    }

    public override bool HitTestPoint(float x, float y)
    {
        if (Mathf.Abs((owner.position - new Vec2(x, y)).Length()) < radius)
        {
            return true;
        }

        return false;
    }

    public override float TimeOfImpact(Collider other, float vx, float vy, out Vector2 normal)
    {
        normal = new Vec2().ToVector2();
        if (other is CircleCollider otherCircleCollider)
        {
            Vec2 u = owner.previousPosition - otherCircleCollider.owner.previousPosition;

            float distance = u.Length();
            float minDistance = radius + otherCircleCollider.radius;

            if (distance > minDistance)
            {
                return float.MaxValue;
            }

            normal = u.Normalized().ToVector2();

            float a = owner.rigidbody.velocity.SqrLength();
            if (a <= 0.001f)
            {
                return float.MaxValue;
            }
            float b = (2f * u).Dot(owner.rigidbody.velocity);
            float c = u.SqrLength() - (minDistance * minDistance);
            float d = (b * b) - (4f * a * c);
            if (d < 0) return float.MaxValue;

            float t = (-b - Mathf.Sqrt(d)) / 2 * a;

            if (c < 0)
            {
                if (b < 0) return 0;
                return float.MaxValue;
            }

            if (0 <= t && t < 1)
            {
                return t;
            }
        }

        return float.MaxValue;
    }

    public override Collision GetCollisionInfo(Collider other)
    {
        if (other is CircleCollider otherCircleCollider)
        {
            Vec2 difference = owner.position - otherCircleCollider.owner.position;

            float distance = difference.Length();
            float minDistance = radius + otherCircleCollider.radius;

            if (distance > minDistance)
            {
                return null;
            }

            Vec2 collisionNormal = difference.Normalized();

            float a = owner.rigidbody.velocity.SqrLength();
            if (a <= 0.001f)
            {
                return null;
            }
            float b = (2f * difference).Dot(owner.rigidbody.velocity);
            float c = difference.SqrLength() - (minDistance * minDistance);
            float d = (b * b) - (4f * a * c);
            if (d < 0) return null;

            float t = (-b - Mathf.Sqrt(d)) / 2 * a;

            if (c < 0)
            {
                if (b < 0) return new Collision(this, otherCircleCollider, collisionNormal.ToVector2(), 0);
                return null;
            }

            if (0 <= t && t < 1)
            {
                return new Collision(this, otherCircleCollider, collisionNormal.ToVector2(), t);
            }

            return null;
        }
        else if (other is LineCollider lineCollider)
        {
            
            return lineCollider.GetCollisionInfo(this);
        }

        Console.WriteLine("Collider is not circle");

        return null;
    }

    public override void ResolveCollision(Collision collision)
    {
        if (collision.other is CircleCollider otherCircleCollider)
        {
            owner.position = owner.previousPosition + owner.rigidbody.velocity * collision.timeOfImpact;

            Vec2 centerOfMassVel = (owner.rigidbody.mass * owner.rigidbody.velocity + otherCircleCollider.owner.rigidbody.mass * otherCircleCollider.owner.rigidbody.velocity) / (owner.rigidbody.mass + otherCircleCollider.owner.rigidbody.mass);
            Vec2 outputVelocity = owner.rigidbody.velocity - (1f + owner.rigidbody.physicsMaterial.bounciness) * ((owner.rigidbody.velocity - centerOfMassVel).Dot(new Vec2(collision.normal))) * new Vec2(collision.normal);
            Vec2 otherOutputVelocity = otherCircleCollider.owner.rigidbody.velocity - (1f + otherCircleCollider.owner.rigidbody.physicsMaterial.bounciness) * ((otherCircleCollider.owner.rigidbody.velocity - centerOfMassVel).Dot(new Vec2(collision.normal))) * new Vec2(collision.normal);

            owner.rigidbody.velocity = outputVelocity;
            otherCircleCollider.owner.rigidbody.velocity = otherOutputVelocity;
        }
        else if (collision.other is LineCollider otherLineCollider)
        {
            otherLineCollider.ResolveCollision(collision);
        }
    }
}
