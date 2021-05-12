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
        public List<Level> levels { get; private set; }

        MyGame myGame;

        public SoundChannel ingameMusic;
        private Sound ingameBackgroundMusic;

        public bool isEnteringDoor;
        public int levelDestination;

        public LevelManager()
        {
            levels = new List<Level>();
            myGame = (MyGame)game;

            levels.Add(new HubLevel());
            levels.Add(new HorizontalLevel());
            levels.Add(new VerticalLevel());
            levels.Add(new EndLevelScreen());


            levels.Add(new TestLevelArjen());
            levels.Add(new TestLevelArjen2());
            levels.Add(new TestLevelJenoah1());

            SwitchLevel(0);

            ingameBackgroundMusic = new Sound("Assets/Audio/Music/fa_ammon_loop.mp3", true, false);
            ingameMusic = ingameBackgroundMusic.Play(true, 0, 0.2f, 0);
        }

        public void RestartLevel()
        {
            int levelIndex = levels.IndexOf(currentLevel);
            Level newLevel = (Level)Activator.CreateInstance(currentLevel.GetType());

            currentLevel.Unload();
            levels[levelIndex] = newLevel;
            RemoveChild(currentLevel);
            currentLevel = levels[levelIndex];
            currentLevel.Load();
            myGame.AddChild(currentLevel);
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
                if (!myGame.HasChild(currentLevel))
                {
                    myGame.AddChild(currentLevel);
                }
            }
            else
            {
                Console.WriteLine($"Level ID ({_levelId}) does not correspond to an existing level (from {levels.Count} levels)");
            }
        }
    }
}
