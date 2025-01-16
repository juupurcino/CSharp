using System.Collections.Generic;

namespace Model.Repository;

public class AlunoFakeRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    public AlunoFakeRepository()
    {
        alunos.Add(new (){
            RA = 1233,
            Nome = "Adrian",
            Idade = 18
        });

        alunos.Add(new (){
            RA = 5466,
            Nome = "Juliana",
            Idade = 21 
        });
    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

}