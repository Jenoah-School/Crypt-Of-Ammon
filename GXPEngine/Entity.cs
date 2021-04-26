using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Entity : Sprite
{
    public float drag = 0.97f;

    public readonly Rigidbody rigidbody;

    public Vec2 position = new Vec2();
    public Vec2 previousPosition = new Vec2();

    private float _previousCollisionTime = float.MaxValue;

    protected Action _collisionEvent = null;
    protected Collision _collidedObject = null;

    protected Collider[] _subColliders = null;

    public Entity(string _fileName, Vec2 _position, int _width, int _height = -1, bool _useGravity = true, bool _checkForCollision = true, float _mass = 1f, float _bounciness = 0.5f) : base(_fileName, false, true)
    {
        SetOrigin(width / 2, height / 2);

        height = _height == -1 ? _width * (width / height) : _height;
        width = _width;
        position = _position;

        rigidbody = new Rigidbody(this, new PhysicsMaterial())
        {
            useGravity = _useGravity,
            checkForCollision = _checkForCollision,
            mass = _mass
        };

        SetXY(_position.x, _position.y);

        MyGame.collisionObjects.Add(collider);

        _previousCollisionTime = Time.time;
        _collisionEvent = new Action(() => CollideEvent());
    }

    /// <summary>
    /// Adds a circle collider by default on all entities
    /// </summary>
    /// <returns></returns>
    protected override Collider createCollider()
    {
        return new CircleCollider(this);
    }

    /// <summary>
    /// Handles the movement and collision for this entity
    /// </summary>
    public void Step()
    {
        previousPosition = position;

        rigidbody.Step();

        CollisionManager.HandleCollision(collider);

        SetXY(position.x, position.y);
    }

    /// <summary>
    /// Executes the CollideEvent() method if an object is colliding for the first time after a given period
    /// </summary>
    /// <param name="_collision"></param>
    public void OnCollision(Collision _collision)
    {
        if (_previousCollisionTime < Time.time - 500 && _collisionEvent != null)
        {
            _collidedObject = _collision;
            _collisionEvent.Invoke();
            _collidedObject = null;
        }
        _previousCollisionTime = Time.time;
    }

    /// <summary>
    /// The event that should execute when a collision is happening
    /// </summary>
    protected virtual void CollideEvent()
    {
        return;
    }

    /// <summary>
    /// The event that should happen upon the receiving of damage
    /// </summary>
    /// <param name="_damage">The amount of damage that should be dealt</param>
    public virtual void DoDamage(float _damage)
    {
        return;
    }

    /// <summary>
    /// The action that should be executed when the entity is being destoyed
    /// </summary>
    public virtual void Eliminate()
    {
        for (int i = 0; i < _subColliders.Length; i++)
        {
            MyGame.collisionObjects.Remove(_subColliders[i]);
        }

        base.LateDestroy();
    }
}
