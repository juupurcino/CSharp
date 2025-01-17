using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataBase;
namespace Model;

public class Professor : DataBaseObject
{   
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Formacao { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.ID = int.Parse(data[0]);
        this.Nome = data[1];
        this.Formacao = data[2];
    }

    protected override string[] SaveTo() => new string[] 
    {
        this.ID.ToString(), this.Nome, this.Formacao
    };

    public static Professor FindByID(List<Professor> professor, int id)
        {
            return professor.FirstOrDefault(a => a.ID == id);
        }

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new System.NotImplementedException();
    }

    protected override string SaveToSql()
    {
        throw new System.NotImplementedException();
    }
}
