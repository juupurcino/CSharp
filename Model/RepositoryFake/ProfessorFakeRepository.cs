using System.Collections.Generic;

namespace Model.Repository;

public class ProfessorFakeRepository : IRepository<Professor>
{
    List<Professor> professor = [];

    public ProfessorFakeRepository()
    {
        professor.Add(new (){
            Nome = "Juliana",
            Formacao = "Doutor"
        });
    }
    public List<Professor> All => professor;

    public void Add(Professor obj) => this.professor.Add(obj);

}