using System.Collections.Generic;
using Model;
using Model.Repository;
using static System.Console;

IRepository<Aluno> AlunoRepository = null;
IRepository<Professor> ProfessorRepository = null;
IRepository<Disciplina> DisciplinaRepository = null;
IRepository<Turma> TurmaRepository = null;

AlunoRepository = new AlunoFakeRepository();
ProfessorRepository = new ProfessorFakeRepository();
DisciplinaRepository = new DisciplinaFakeRepository();
TurmaRepository = new TurmaFakeRepository();

while (true)
{
    try
    {
        Clear();
        WriteLine("\n 1- Cadastrar professor\n 2- Cadastrar aluno\n 3- Ver professores\n 4- Ver alunos\n 5- Cadastrar disciplinas\n 6- Ver disciplinas\n 7-Cadastrar turma\n 8- Ver turmas\n 9- Sair");
        int option = int.Parse(ReadLine());

        switch (option)
        {

            case 1:

                Clear();
                Professor professor = new();
                WriteLine("Insira o nome do professor");
                professor.Nome = ReadLine();
                WriteLine("Insira a formação do professor");
                professor.Formacao = ReadLine();
                ProfessorRepository.Add(professor);

                break;
            case 2:

                Clear();
                Aluno aluno = new();
                WriteLine("Insira o nome do aluno");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno");
                aluno.Idade = int.Parse(ReadLine());
                AlunoRepository.Add(aluno);

                break;

            case 3:

                var profs = ProfessorRepository.All;
                foreach (var profe in profs)
                {
                    WriteLine($"{profe.Formacao} - {profe.Nome}");
                }

                break;

            case 4:

                var alunos = AlunoRepository.All;
                foreach (var alun in alunos)
                {
                    WriteLine($"{alun.Nome} - {alun.Idade}");
                }

                break;

            case 5:

                Clear();
                Disciplina addDisciplina = new();
                WriteLine("Insira o nome da disciplina: ");
                addDisciplina.Nome = ReadLine();
                WriteLine("Insira o nome do professor responsável pela disciplina: ");
                string prof = ReadLine();

                var professorDisciplina = ProfessorRepository.All;

                foreach (var profDisciplina in professorDisciplina)
                {
                    if (profDisciplina.Nome == null)
                    {
                        WriteLine("Professor não encontrado!");
                    }
                    else
                    {
                        addDisciplina.professor = profDisciplina;
                    }
                }

                DisciplinaRepository.Add(addDisciplina);

                break;

            case 6:

                var disciplinas = DisciplinaRepository.All;
                foreach (var disciplina in disciplinas)
                {
                    WriteLine($"{disciplina.Nome} - {disciplina.professor.Nome}");
                }

                break;

            case 7:

                Clear();
                Turma turma = new();
                WriteLine("Insira o nome da turma: ");
                turma.Nome = ReadLine();

                var alunosTurma = AlunoRepository.All;
                var disciplinasTurma = DisciplinaRepository.All;

                while (true)
                {
                    List<int> idDisciplinas = new();
                    List<string> nomeDisciplinas = new();

                    WriteLine("Insira o nome das disciplinas: ");
                    string nomeDisc = ReadLine();

                    WriteLine("Insira o nome das disciplinas: ");
                    string nomeDisc1 = ReadLine();

                    idDisciplinas.Add(0);
                    idDisciplinas.Add(1);
                    nomeDisciplinas.Add(nomeDisc);
                    nomeDisciplinas.Add(nomeDisc1);
        
                }
        }

    }
    catch
    {
        WriteLine("Erro na aplicação!");
    }

    WriteLine("Pressione qualquer tecla para continuar...");
    ReadKey(true);
}