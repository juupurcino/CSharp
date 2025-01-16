using System.Collections.Generic;
using System.Threading.Tasks;
using DataBase;

namespace Model.Repository;

public class DisciplinaRepository : IRepository<Disciplina>
{
    private DB<Disciplina> database = DB<Disciplina>.App;

    public List<Disciplina> All => database.All;

    public void Add(Disciplina obj) {

        List<Disciplina> list = database.All;
        list.Add(obj);
        database.Save(list);

    }
    
}
