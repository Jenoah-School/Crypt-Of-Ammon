using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using GXPEngine.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;
using GXPEngine.Core;

public class MyGame : Game
{
	public static List<Collider> collisionObjects = new List<Collider>();

	public MyGame() : base(1280, 720, false, false)	
	{
		GL.glfwSetWindowPos((Screen.PrimaryScreen.Bounds.Width - width) / 2, (Screen.PrimaryScreen.Bounds.Height - height) / 2);
		GL.glfwSetWindowTitle("Final Approach");

		targetFps = 60;
	}

	static void Main()
	{
		new MyGame().Start();
	}
}