using System.Collections.Generic;
using Model;
using Model.Repository;
using static System.Console;

IRepository<Aluno> AlunoRepository = null;
IRepository<Professor> ProfessorRepository = null;
IRepository<Disciplina> DisciplinaRepository = null;
IRepository<Turma> TurmaRepository = null;

ProfessorRepository = new ProfessorRepository();
AlunoRepository = new AlunoRepository();
DisciplinaRepository = new DisciplinaRepository();
TurmaRepository = new TurmaRepository();


while (true)
{
    try
    {
        Clear();
        WriteLine("\n 1- Cadastrar professor\n 2- Cadastrar aluno\n 3- Ver professores\n 4- Ver alunos\n 5- Cadastrar disciplinas\n 6- Ver disciplinas\n 7- Cadastrar turma\n 8- Ver turmas\n 9- Sair");
        int option = int.Parse(ReadLine());

        switch (option)
        {

            case 1:

                var profe = ProfessorRepository.All;

                int idProf = profe.Count > 0 ? profe[profe.Count - 1].ID + 1 : 1;

                Clear();
                Professor professor = new();
                WriteLine("Insira o nome do professor");
                professor.Nome = ReadLine();
                WriteLine("Insira a formação do professor");
                professor.Formacao = ReadLine();
                professor.ID = idProf;
                ProfessorRepository.Add(professor);

                break;

            case 2:

                Clear();
                Aluno aluno = new();
                WriteLine("Insira o RA do aluno: ");
                int RAaluno = int.Parse(ReadLine());

                var alunos = AlunoRepository.All;
                Aluno alunoExistente = Aluno.FindByRA(alunos, RAaluno);

                if (alunoExistente != null)
                {
                    WriteLine("Já existe um aluno com esse RA!");
                    break;
                }

                aluno.RA = RAaluno;
                WriteLine("Insira o nome do aluno: ");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno: ");
                aluno.Idade = int.Parse(ReadLine());
                AlunoRepository.Add(aluno);

                WriteLine("Aluno adicionado com sucesso!");
                break;

            case 3:

                var profs = ProfessorRepository.All;
                foreach (var profes in profs)
                {
                    WriteLine($"{profes.ID} - {profes.Formacao} - {profes.Nome}");
                }

                break;

            case 4:

                var alunosFind = AlunoRepository.All;
                foreach (var alun in alunosFind)
                {
                    WriteLine($"{alun.RA} - {alun.Nome} - {alun.Idade}");
                }

                break;

            case 5:
                Clear();
                Disciplina addDisciplina = new();
                WriteLine("Insira o nome da disciplina: ");
                addDisciplina.Nome = ReadLine();
                WriteLine("Insira o ID do professor responsável pela disciplina: ");
                int professorID = int.Parse(ReadLine());

                var professorDisc = ProfessorRepository.All;

                Professor professorExistente = Professor.FindByID(professorDisc, professorID);

                if (professorExistente == null)
                {
                    WriteLine("Professor não encontrado!");
                    continue;
                }

                var disci = DisciplinaRepository.All;
                int idDisc = disci.Count > 0 ? disci[disci.Count - 1].ID + 1 : 1;
                addDisciplina.ID = idDisc;
                addDisciplina.IDProfessor = professorID;  
                DisciplinaRepository.Add(addDisciplina);

                WriteLine("Disciplina cadastrada com sucesso!");
                break;


            case 6:

                var disciplinas = DisciplinaRepository.All;
                foreach (var disciplina in disciplinas)
                {
                    WriteLine($"{disciplina.Nome} - {disciplina.IDProfessor}");
                }

                break;

            case 7:

                Clear();
                Turma turma = new();
                WriteLine("Insira o nome da turma: ");
                turma.Nome = ReadLine();

                var alunosTurma = AlunoRepository.All;
                var disciplinasTurma = DisciplinaRepository.All;

                WriteLine("Insira a quantidade de alunos da turma");
                int qtdAluno = int.Parse(ReadLine());

                WriteLine("-----> ALUNOS");

                foreach (var alun in alunosTurma)
                {
                    WriteLine($"{alun.RA} - {alun.Nome} - {alun.Idade}");
                }

                for (int i = 0; i < qtdAluno; i++)
                {
                    WriteLine("Insira o RA do aluno: ");
                    int RAalunoTurma = int.Parse(ReadLine());

                    Aluno alunoExistenteTurma = Aluno.FindByRA(alunosTurma, RAalunoTurma);

                    if (alunoExistenteTurma == null)
                    {
                        WriteLine("Não existe um aluno com esse RA!");
                        i--;
                        continue;
                    }

                    turma.RAalunos.Add(RAalunoTurma);

                }

                WriteLine("Insira a quantidade de disciplinas da turma");
                int qtdDisc = int.Parse(ReadLine());

                WriteLine("-----> DISCIPLINAS");

                foreach (var disc in disciplinasTurma)
                {
                    WriteLine($"{disc.ID} - {disc.Nome} - {disc.IDProfessor}");
                }

                for (int i = 0; i < qtdDisc; i++)
                {
                    WriteLine("Insira o ID do disciplina: ");
                    int IDDiscTurma = int.Parse(ReadLine());

                    Disciplina discExistenteTurma = Disciplina.FindByID(disciplinasTurma, IDDiscTurma);

                    if (discExistenteTurma == null)
                    {
                        WriteLine("Não existe uma disciplina com esse ID!");
                        i--;
                        continue;
                    }

                    turma.IDdisciplinas.Add(IDDiscTurma);

                }

                TurmaRepository.Add(turma);
                break;

            case 8:

                var turmas = TurmaRepository.All;
                
                for (int i = 0; i < turmas.Count; i++)
                {
                    foreach (var tur in turmas)
                    {
                        for (int j = 0; j < turmas.Count; j++)
                        {
                            WriteLine($"{tur.Nome}\n");
                            WriteLine($"Alunos:\n{tur.RAalunos[j]} - {tur.IDdisciplinas[j]}");
                        }
                    }
                }

                break;

        }

    }
    catch
    {
        WriteLine("Erro na aplicação!");
    }

    WriteLine("Pressione qualquer tecla para continuar...");
    ReadKey(true);
}