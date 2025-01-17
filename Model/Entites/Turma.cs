using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
namespace Model;

public class Turma : DataBaseObject
{
    public string Nome { get; set; }
    public List<int> RAalunos { get; set;} = new List<int>();
    public List<int> IDdisciplinas { get; set;} = new List<int>();

    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.RAalunos = data[1].Split(',').Select(int.Parse).ToList();
        this.IDdisciplinas = data[2].Split(',').Select(int.Parse).ToList();

    }

    protected override void LoadFromSqlRow(System.Data.DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string[] SaveTo() => new string[] 
    {
        this.Nome, String.Join(",", this.RAalunos), String.Join(",", this.IDdisciplinas)
        
    };

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}