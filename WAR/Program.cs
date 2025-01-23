using System;
using System.Collections.Generic;
using System.Linq;

Random random = new Random();

int batalhas = 2;

List<int> ataqueList = [];
List<int> defesaList = [];
List<int> jogadasList = [];
int vitorias = 0;

int Dado() => random.Next(6) + 1;

for (int i = 0; i < batalhas; i++)
{
    int defesa = 500;
    int ataque = 1_000;

    int jogadas = 0;

    while (true)
    {

        if (defesa <= 0 || ataque <= 1)
            break;

        ataqueList.Clear();
        defesaList.Clear();
        jogadasList.Clear();
        jogadas = 0;

        // while (jogadas < 3)
        // {
        //     ataqueList.Add(Dado());
        //     defesaList.Add(Dado());
        //     jogadas++;
        // }

        for (int j = 0; j < (ataque <= 4 ? ataque -1 : 3); j++)
            ataqueList.Add(Dado());

        for (int j = 0; j < (defesa <= 4 ? defesa -1 : 3); j++)
            defesaList.Add(Dado());

        var ataqueOrder = ataqueList.OrderByDescending(x => x).ToList();
        var defesaOrder = defesaList.OrderByDescending(x => x).ToList();

        for (int j = 0; j < ataqueOrder.Count(); j++)
        {
            int venceu = defesaOrder[j] >= ataqueOrder[j] ? 0 : 1;
            jogadasList.Add(venceu);
        }

        int qtdDefesa = jogadasList.Count(x => x == 0);
        int qtdAtaque = jogadasList.Count(x => x == 1);

        Console.WriteLine(qtdAtaque);
        Console.WriteLine(qtdDefesa);

        ataque -= qtdAtaque;
        defesa -= qtdDefesa;

        Console.WriteLine($"Ataque: {ataque}");
        Console.WriteLine($"Defesa: {defesa}");

        // Console.WriteLine(ataque);
        // Console.WriteLine(defesa);
    }

    if (ataque > defesa)
    {
        vitorias++;
    }

    Console.WriteLine(vitorias);
}

Console.WriteLine($"Vitorias: {(vitorias * 100) / (float)batalhas}");