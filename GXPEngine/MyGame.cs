using System;									
using GXPEngine;                               
using GXPEngine.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;
using GXPEngine.Core;

public class MyGame : Game
{
	public static MyGame Instance;
	public static List<Collider> collisionObjects = new List<Collider>();
	public LevelManager levelManager;
	public UIManager UserInterfaceManager;

	public MyGame() : base(1280, 720, false, false)	
	{
		Instance = this;

		GL.glfwSetWindowPos((Screen.PrimaryScreen.Bounds.Width - width) / 2, (10));
		GL.glfwSetWindowTitle("Crypt of Ammon");
		

		RenderMain = false;
		levelManager = new LevelManager();
		UserInterfaceManager = new UIManager();

		targetFps = 60;

		AddChild(levelManager);
		AddChild(UserInterfaceManager);
	}

	void Update()
    {
        SetChildIndex(UserInterfaceManager, 10000);
        if (Input.GetKeyUp(Key.R))
        {
			UserInterfaceManager.AddInterface(5);
        }
	}

	static void Main()
	{
		new MyGame().Start();
	}	
}