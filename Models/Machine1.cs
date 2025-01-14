namespace Models;
using BoschClicker.Config;
public class Machine1 : Machine
{
    public Machine1() : base("Machine A", GameConfig.machine1const, GameConfig.machine1production)
    {
    }
}

