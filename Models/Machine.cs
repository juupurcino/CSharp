namespace Models;

public abstract class Machine
{
    public string Name { get;}
    public int Cost { get; private set;}
    public int Production { get; private set;}
    public int Level { get; private set;}

    protected Machine(string name, int cost, int production){

        Name = name;
        Cost = cost;
        Production = production;
    }

    public void Upgrade(){
        Level ++;
        Production += Production /2;
        Cost += Cost /2;
    }

    public int UpgradeCost => Cost;
}