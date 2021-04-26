using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Line : GameObject
{
    public Vec2 start = new Vec2();
    public Vec2 end = new Vec2();
    public readonly Vec2 normal = new Vec2();

    private readonly Vec2 originalStart = new Vec2();
    private readonly Vec2 originalEnd = new Vec2();

    private Line inversedLine = null;

    public Vec2 velocity = new Vec2();
    public float mass = 1f;
    private Vec2 previousOffset = new Vec2();


    public Line(Vec2 _lineStart, Vec2 _lineEnd, bool _isInversed = false)
    {
        start = _lineStart;
        end = _lineEnd;

        originalStart = _lineStart;
        originalEnd = _lineEnd;

        normal = (end - start).Normal();

        if(!_isInversed) inversedLine = new Line(_lineEnd, _lineStart, true);
    }

    override protected void RenderSelf(GLContext glContext)
    {
        if (game != null)
        {
            Gizmos.RenderLine(start.x + 1, start.y + 1, end.x + 1, end.y + 1, 0xffffffff, 2, true);
        }
    }

    public void SetOffset(Vec2 _offset)
    {
        start = originalStart + _offset;
        end = originalEnd + _offset;

        velocity = previousOffset - _offset;

        previousOffset = _offset;

        if (inversedLine != null) inversedLine.SetOffset(_offset);
    }
}
