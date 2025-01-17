using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoDBRepository : IRepository<Aluno>
{

    protected DBsqlServer<Aluno> db;

    public AlunoDBRepository(){
        
        db = new DBsqlServer<Aluno>("CA-C-0065F\\SQLEXPRESS", "SchoolSystem");
    }

    public List<Aluno> All => db.All;
    

    public void Add(Aluno obj)
    {
        db.Save(obj);
    }
}