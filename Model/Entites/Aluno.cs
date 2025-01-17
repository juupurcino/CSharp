using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataBase;

namespace Model;

public class Aluno : DataBaseObject
{

    public int RA { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.RA = int.Parse(data[0]);
        this.Nome = data[1];
        this.Idade = int.Parse(data[2]);
    }

    protected override string[] SaveTo() => new string[]
    {   
        this.RA.ToString(),
        this.Nome,
        this.Idade.ToString()    
    };

    public static Aluno FindByRA(List<Aluno> alunos, int ra)
        {
            return alunos.FirstOrDefault(a => a.RA == ra);
        }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.RA = (int)data[0];
        this.Nome= data[1].ToString();
        this.Idade = (int)data[2];
        
    }

    protected override string SaveToSql() 
    => $"INSERT INTO [Aluno] VALUES ({this.RA}, '{this.Nome}', {this.Idade})";

}