using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubLineCollider : GameObject
{
    private readonly Entity _owner;
    private readonly Vec2 _startPos, _endPos;

    public SubLineCollider(Entity _owner, Vec2 _start, Vec2 _end)
    {
        this._owner = _owner;
        _startPos = _start;
        _endPos = _end;

        _collider = createCollider();
    }

    void Update()
    {
        if (collider != null)
        {
            LineCollider lineCollider = (LineCollider)_collider;
            lineCollider.SetOffset(_owner.position);
            Gizmos.DrawLine(lineCollider.start.x + 1, lineCollider.start.y + 1, lineCollider.end.x + 1, lineCollider.end.y + 1, null, 0xffffffff, 2);
            Gizmos.DrawLine(lineCollider.start.x + 1, lineCollider.start.y + 1, lineCollider.end.x + 1, lineCollider.end.y + 1, null, 0xffffffff, 2);
        }
    }

    protected override Collider createCollider()
    {
        return new LineCollider(_owner, _startPos, _endPos);
    }
}
