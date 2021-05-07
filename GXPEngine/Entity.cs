using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;

public class Entity : AnimationSprite
{
    public readonly Rigidbody rigidbody;

    public Vec2 position = new Vec2();
    public Vec2 previousPosition = new Vec2();

    private float _previousCollisionTime = float.MaxValue;
    private bool initGravityState = true;
    private int groundCheckDistance = 1;

    public Action _collisionEvent = null;
    public Collision _collidedObject = null;
    protected Collider[] _subColliders = null;

    public List<Collider> ignoreColliders = new List<Collider>();
    public bool skipResolve = false;

    public Entity(string _fileName, Vec2 _position, int _width, int _height = -1, bool _useGravity = true, bool _checkForCollision = true, float _mass = 1f, float _bounciness = 0.5f, int _rows = 1, int _cols = 1, int _frames = 1) : base(_fileName, _cols, _rows, _frames, false, true)
    {
        SetOrigin(width / 2, height / 2);

        height = _height == -1 ? (int)(_width * ((float)height / (float)width)) : _height;
        width = _width;
        position = _position;

        initGravityState = _useGravity;

        rigidbody = new Rigidbody(this, new PhysicsMaterial(_bounciness))
        {
            useGravity = _useGravity,
            checkForCollision = _checkForCollision,
            mass = _mass
        };

        SetXY(_position.x, _position.y);

        if (_checkForCollision)
        {
            MyGame.collisionObjects.Add(collider);
        }

        _previousCollisionTime = Time.time;
        _collisionEvent = new Action(() => CollideEvent());
    }

    /// <summary>
    /// Adds a circle collider by default on all entities
    /// </summary>
    /// <returns></returns>
    protected override Collider createCollider()
    {
        return new BoxCollider(this);
    }

    /// <summary>
    /// Handles the movement and collision for this entity
    /// </summary>
    public void Step()
    {
        if (collider == null) return;
        previousPosition = position;

        if (!IsGrounded())
        {
            rigidbody.useGravity = initGravityState;
        }
        else
        {
            rigidbody.useGravity = false;
        }

        rigidbody.Step();

        if (!skipResolve)
        {
            CollisionManager.HandleCollision(collider);
        }

        skipResolve = false;
        SetXY(position.x, position.y);
    }

    public bool IsGrounded()
    {
        //return (position - previousPosition).y > -0.4f && (position - previousPosition).y < 0.4f;
        foreach(Entity _ent in MyGame.Instance.currentLevel.sceneObjects.ToList())
        {
            if(_ent == MyGame.Instance.currentLevel.player)
            {
                continue;
            }
            if(_ent.HitTestPoint(x, y + height / 2f + groundCheckDistance) || _ent.HitTestPoint(x - width / 2, y + height / 2f + groundCheckDistance) || _ent.HitTestPoint(x + width / 2, y + height / 2f + groundCheckDistance))
            {
                return true;
            }
        }

        return false;
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
