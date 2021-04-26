using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Metal : PhysicsMaterial
{
    public Metal()
    {
        bounciness = 0.8f;
        drag = 0.95f;
    }
}
