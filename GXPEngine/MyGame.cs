using System;									
using GXPEngine;                               
using GXPEngine.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;
using GXPEngine.Core;

public class MyGame : Game
{
	public static List<Collider> collisionObjects = new List<Collider>();
	public static MyGame Instance;
	public LevelManager levelManager;
	public UIManager UserInterfaceManager;

	public MyGame() : base(1180, 600, false, false)	
	{
		GL.glfwSetWindowPos((Screen.PrimaryScreen.Bounds.Width - width) / 2, (10));
		GL.glfwSetWindowTitle("Final Approach");
		RenderMain = false;
		levelManager = new LevelManager();
		UserInterfaceManager = new UIManager();
		Instance = this;

		targetFps = 60;

		AddChild(levelManager);
		AddChild(UserInterfaceManager);		
	}

	void Update()
    {
		SetChildIndex(UserInterfaceManager, 10000);
	}

	static void Main()
	{
		new MyGame().Start();
	}	
}