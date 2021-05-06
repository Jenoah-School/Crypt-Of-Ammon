using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Animation : AnimationSprite
    {
        public Animation(string animationSheet, int cols, int rows, Vec2 offset) : base(animationSheet, cols, rows, -1, false,false)
        {
            SetXY(offset.x, offset.y);
        }

        public void Update()
        {
            Animate();
        }

        public void SetAnimationCycle(int startFrame, int frameAmount, byte animationSpeed, bool switchFrame)
        {
            SetCycle(startFrame, frameAmount, animationSpeed, switchFrame);
        }
    }
}
