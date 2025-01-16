using System.Collections.Generic;

namespace Model.Repository;

public class TurmaFakeRepository : IRepository<Turma>
{
    List<Turma> turma = [];

    public TurmaFakeRepository()
    {
        turma.Add(new (){
            Nome = "DTA",
            RAalunos = [1,2,3,4,5,6],
            IDdisciplinas = [1,2,3]
        });
    }
    public List<Turma> All => turma;

    public void Add(Turma obj) => this.turma.Add(obj);

}