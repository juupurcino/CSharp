namespace Models;
using BoschClicker.Config;
public class Machine2 : Machine
{
    public Machine2() : base("Machine B", GameConfig.machine2const, GameConfig.machine2production)
    {
    }
}
