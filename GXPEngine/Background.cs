using GXPEngine;
using System;
using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Background : GameObject
{
    public List<UVOffsetSprite> layers = new List<UVOffsetSprite>();

    public Background(string[] _layers)
    {        
        foreach(string _layer in _layers)
        {              
            layers.Add(new UVOffsetSprite(_layer));               
        }

        foreach(Sprite layer in layers)
        {
            AddChild(layer);
        }
    }

    public void MoveLayersWithDistance(float[] _layerDistances, float playerVelocityX)
    {
        for(int i = 0; i < _layerDistances.Length; i++)
        {
            layers[i].AddOffset(((playerVelocityX *= _layerDistances[i]) / 10000), 0f);
        }
    }
}

