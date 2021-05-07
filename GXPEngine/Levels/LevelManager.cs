using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        public Level currentLevel { get; private set; }
        private List<Level> levels = new List<Level>();
        

        MyGame myGame;

        public LevelManager()
        {
            myGame = (MyGame)game;

            levels.Add(new TestLevelArjen());
            levels.Add(new TestLevelArjen2());
            levels.Add(new TestLevelJenoah());

            SwitchLevel(0);
        }

        public void SwitchLevel(int _levelId)
        {
            if (_levelId < levels.Count)
            {
                
                if (currentLevel != null)
                {
                    currentLevel.Unload();
                    //currentLevel.LateDestroy();
                    currentLevel = null;
                }
                currentLevel = levels[_levelId];
                currentLevel.Load();
                myGame.AddChild(currentLevel);
            }
            else
            {
                Console.WriteLine($"Level ID ({_levelId}) does not correspond to an existing level (from {levels.Count} levels)");
            }
        }
    }
}
