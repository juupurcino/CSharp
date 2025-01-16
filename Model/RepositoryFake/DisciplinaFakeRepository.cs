using System;
using System.Collections.Generic;
using Model;
using Model.Repository;

public class DisciplinaFakeRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplina = new List<Disciplina>();  

    public List<Disciplina> All => disciplina;

    public void Add(Disciplina obj) => disciplina.Add(obj);
}
