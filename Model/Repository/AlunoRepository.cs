using System.Collections.Generic;
using System.Threading.Tasks;
using DataBase;

namespace Model.Repository;

public class AlunoRepository : IRepository<Aluno>
{
    private DB<Aluno> database = DB<Aluno>.App;

    public List<Aluno> All => database.All;

    public void Add(Aluno obj) {

        List<Aluno> list = database.All;
        list.Add(obj);
        database.Save(list);

    }
    
}
