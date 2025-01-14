using Models;
using System.ComponentModel.Design;
public class Store
{
    private List<Machine> _machines;
    private int _cookies;

    public Store(List<Machine> machines, int cookies)
    {
        _machines = machines;
        _cookies = cookies;
    }

    public void OpenStore()
    {

        while (true)
        {
            NewConsole.Print("\n ------ STORE ------");
            NewConsole.Print("\n 1. Buy machine");
            NewConsole.Print(" 2. Upgrade machine");
            NewConsole.Print(" 3. Exit Store");
            NewConsole.Print("=> ");

            int? choice = NewConsole.ReadLineInt();
            switch (choice)
            {
                case 1:
                    BuyMachine();
                    break;
                case 2:
                    UpgradeMachine();
                    break;
                case 3:
                    //Aqui tem q fazer abrir o menu
                default:
                    NewConsole.Print("\n Invalid choice. Try again.");
                    break;
            }
        }
    }

    public void BuyMachine()
    {
        NewConsole.Print("\n ------ BUY MACHINES ------");
        NewConsole.Print($"\n 1. Machine A - {_machines[0].Cost}");
        NewConsole.Print($"\n 2. Machine B - {_machines[1].Cost}");
        NewConsole.Print($"\n 3. Machine C - {_machines[2].Cost}");
        NewConsole.Print("=> ");

        string choice = Console.ReadLine();

        int index = int.Parse(choice) - 1;

        if (_cookies >= _machines[index].Cost)
        {
            _cookies -= _machines[index].Cost;
        }
        else
        {
            NewConsole.Print("you do not have enough cookies to make this purchase");
        }

    }

    public void UpgradeMachine()
    {
        NewConsole.Print("\n ------ UPGRADE MACHINES ------");

        for (int i = 0; i < _machines.Count; i++)
        {
            NewConsole.Print($"\n {i}. {_machines[i].Name} - Level: {_machines[i].Level} - Upgrade Cost: {_machines[i].UpgradeCost}");
        }

        NewConsole.Print($"\n 1. Machine A - {_machines[0].UpgradeCost}");
        NewConsole.Print($"\n 2. Machine B - {_machines[1].UpgradeCost}");
        NewConsole.Print($"\n 3. Machine C - {_machines[2].UpgradeCost}");
        NewConsole.Print("Choose the machine to upgrade => ");

        string choice = Console.ReadLine();

        int index = int.Parse(choice) - 1;

        if (_cookies >= _machines[index].UpgradeCost)
        {
            _cookies -= _machines[index].UpgradeCost;
            _machines[index].Upgrade();
            NewConsole.Print($"\n{_machines[index].Name} - Level: {_machines[index].Level}");

        }
        else
        {

            NewConsole.Print("you do not have enough cookies to make this purchase");
        }

    }
}