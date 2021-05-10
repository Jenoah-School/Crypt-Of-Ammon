using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class UIManager : GameObject
{
    public List<UI> UserInterfaces = new List<UI>();

    public UIManager()
    {
        UserInterfaces.Add(new LoadScreenTeamLogo());
        UserInterfaces.Add(new LoadScreenGameLogo());
        UserInterfaces.Add(new MainMenu());
        UserInterfaces.Add(new PlayingUI());

        AddInterface(2);
    }

    public void AddInterface(int number)
    {    
        AddChild(UserInterfaces[number]);
    }

    public void RemoveInterface(int number)
    {
        RemoveChild(UserInterfaces[number]);
        UserInterfaces[number].timeMillis = 0;
    }
}
