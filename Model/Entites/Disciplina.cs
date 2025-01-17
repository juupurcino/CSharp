using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataBase;
namespace Model;

public class Disciplina : DataBaseObject
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public int IDProfessor { get; set; } 

    protected override void LoadFrom(string[] data)
    {
        this.ID = int.Parse(data[0]);  
        this.Nome = data[1];
        this.IDProfessor = int.Parse(data[2]);
    }
        
    protected override string[] SaveTo() => new string[]
    {
        this.ID.ToString(), 
        this.Nome, 
        this.IDProfessor.ToString()
    };

    public static Disciplina FindByID(List<Disciplina> disciplinas, int id)
        {
            return disciplinas.FirstOrDefault(a => a.ID == id);
        }

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}