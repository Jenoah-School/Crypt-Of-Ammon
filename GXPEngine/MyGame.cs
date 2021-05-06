using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using GXPEngine.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;
using GXPEngine.Core;

public class MyGame : Game
{
	public static MyGame Instance;
	public static List<Collider> collisionObjects = new List<Collider>();

	public Level currentLevel { get; private set; }
	private List<Level> levels = new List<Level>();

	public MyGame() : base(1280, 720, false, false)	
	{
		GL.glfwSetWindowPos((Screen.PrimaryScreen.Bounds.Width - width) / 2, (Screen.PrimaryScreen.Bounds.Height - height) / 2);
		GL.glfwSetWindowTitle("Final Approach");
		Instance = this;

		targetFps = 60;

		//Just temp to test
		levels.Add(new TestLevelJenoah1());

		SwitchLevel(0);
	}

	static void Main()
	{
		new MyGame().Start();
	}

	public void SwitchLevel(int _levelId)
    {
		if(_levelId < levels.Count) 
        {
			if (currentLevel != null)
			{
				currentLevel.Unload();
				currentLevel.LateDestroy();
				currentLevel = null;
			}
			currentLevel = levels[_levelId];
			currentLevel.Load();
			AddChild(currentLevel);
        }
        else
        {
			Console.WriteLine($"Level ID ({_levelId}) does not correspond to an existing level (from {levels.Count} levels)");
        }
    }
}