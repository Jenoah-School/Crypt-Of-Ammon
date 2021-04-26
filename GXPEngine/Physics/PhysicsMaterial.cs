using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhysicsMaterial
{
    public float bounciness = 0.975f;
    public float drag = 0.98f;

    public PhysicsMaterial(float _bounciness = 0.975f, float _drag = 0.98f)
    {
        bounciness = _bounciness;
        drag = _drag;
    }
}
