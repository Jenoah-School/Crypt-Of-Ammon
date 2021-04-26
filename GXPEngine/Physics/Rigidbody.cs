using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rigidbody
{
    private readonly Entity _owner;

    public float mass = 1;

    public bool useGravity = true;
    public bool checkForCollision = true;

    public Vec2 velocity = new Vec2();
    Vec2 _acceleration = new Vec2();

    public PhysicsMaterial physicsMaterial;

    public Rigidbody(Entity owner, PhysicsMaterial _physicsMaterial)
    {
        _owner = owner;
        physicsMaterial = _physicsMaterial;
    }

    public void Step()
    {
        if (useGravity)
        {
            AddForce(new Vec2(0, GameBehaviour.gravity), false);
        }

        velocity *= physicsMaterial.drag;
        _owner.position += velocity;
    }

    public void AddForce(Vec2 _force, bool _isAffectedByMass = true)
    {
        _acceleration = _isAffectedByMass ? _force / mass : _force;
        velocity += _acceleration / 75;
    }
}
