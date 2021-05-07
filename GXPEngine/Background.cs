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
        foreach (string _layer in _layers)
        {
            layers.Add(new UVOffsetSprite(_layer));
        }

        foreach (Sprite layer in layers)
        {
            AddChild(layer);
        }
    }

    public void MoveLayersWithDistance(float[] _layerDistances, Vec2 playerVelocity)
    {
        for (int i = 0; i < _layerDistances.Length; i++)
        {
            layers[i].AddOffset(((playerVelocity.x *= _layerDistances[i]) / 10000), (playerVelocity.y *= _layerDistances[i]) / 5000);
        }
    }
}

