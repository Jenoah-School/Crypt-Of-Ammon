using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameBehaviour
{
    public static float gravity = 9.81f;

    public static float GetHorizontalAxis()
    {
        float horizontalInput = 0f;

        if (Input.GetKey(Key.A) || Input.GetKey(Key.LEFT))
        {
            horizontalInput -= 1;
        }

        if (Input.GetKey(Key.D) || Input.GetKey(Key.RIGHT))
        {
            horizontalInput += 1;
        }

        return horizontalInput;
    }

    public static float GetVerticalAxis()
    {
        float verticalInput = 0f;

        if (Input.GetKey(Key.W) || Input.GetKey(Key.UP))
        {
            verticalInput -= 1;
        }

        if (Input.GetKey(Key.S) || Input.GetKey(Key.DOWN))
        {
            verticalInput += 1;
        }

        return verticalInput;
    }
}
