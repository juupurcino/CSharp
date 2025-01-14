using Models;
using NewSystem;


internal class Program
{
    private static void Main(string[] args)
    {
        int cookies = 0;

        List<Machine> machines = new List<Machine> { new Machine1(), new Machine2(), new Machine3() };

        Store store = new Store(machines, cookies);

        while (true)
        {
            NewConsole.Print("=========> Welcome Bosch Clicker <=========");

            NewConsole.Print("\n ------ MENU ------");
            NewConsole.Print("\n PRESS SPACE TO ENLARGE COOKIES ");
            NewConsole.Print(" 2. Store");
            NewConsole.Print(" 3. Exit game");
            NewConsole.Print("=> ");

            int? choice = NewConsole.ReadLineInt();
            switch (choice)
            {
                case 1:
                    int? key = NewConsole.ReadKeyInt();

                    if (key == 32)
                    {
                        cookies ++;
                    }
                    break;
                case 2:
                    store.OpenStore();
                    break;
                case 3:
                    return;
                default:
                    NewConsole.Print("\n Invalid choice. Try again.");
                    break;
            }
        }
    }

}