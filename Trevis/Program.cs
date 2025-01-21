

// int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
// var result = array.Where(i => i % 2 == 0).Select(i => i*i);

// foreach (var item in result)
// {
//     Console.WriteLine(item);
// }

// public static class Enumerator
// {



//     public static IEnumerable<R> Select<T, R>(this IEnumerable<T> source, Func<T, R> map){

//         var it = source.GetEnumerator();

//         while (it.MoveNext()){

//             var item = it.Current;
//             yield return map(item);
//         }

//     }

//     public static IEnumerable<T> Where <T>(this IEnumerable<T> source, Func<T, bool> predicate){

//         foreach (T item in source)
//         {
//             if (predicate(item))
//             {
//                 yield return item;
//             }
//         }

//     }

//     public static T? FirstOrDefault<T>(this IEnumerable<T> coll)
//     {
//         if (coll == null)
//             return default;

//         var it = coll.GetEnumerator();

//         it.MoveNext();
//         return it.Current;
//     }

//     public static T? LastOrDefault<T>(this IEnumerable<T> coll)
//     {
//         var it = coll.GetEnumerator();

//         T? last = default;

//         while (it.MoveNext())

//             last = it.Current;

//         return last;

//     }

//     public static T[] ToArray<T>(this IEnumerable<T> coll)
//     {

//         T[] array = new T[coll.Count()];

//         var it = coll.GetEnumerator();

//         for (int i = 0; i < coll.Count() && it.MoveNext(); i++)
//         {
//             array[i] = it.Current;
//         }

//         return array;
//     }

//     public static List<T> ToList<T>(this IEnumerable<T> coll)
//     {
//         List<T> list = [.. coll];

//         return list;
//     }

//     public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int num)
//     {
//         var it = coll.GetEnumerator();

//         for (int i = 0; i < num && it.MoveNext(); i++)
//         {
//             yield return it.Current;

//         }
//     }

//     public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int num)
//     {
//         var it = coll.GetEnumerator();

//         for (int i = num; i < coll.Count(); i++)
//         {
//             if (it.MoveNext())
//                 yield return it.Current;
//         }
//     }

//     public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
//     {
//         var it = coll.GetEnumerator();

//         while (it.MoveNext())
//         {
//             yield return it.Current;
//         }

//         yield return item;

//     }

//     public static IEnumerable<T> Preppend<T>(this IEnumerable<T> coll, T item)
//     {
//         var it = coll.GetEnumerator();

//         yield return item;

//         while (it.MoveNext())
//         {
//             yield return it.Current;
//         }

//     }

//     public static int Count<T>(this IEnumerable<T> coll)
//     {
//         int size = 0;

//         var it = coll.GetEnumerator();

//         while (it.MoveNext())
//             size++;

//         return size;
//     }

//     // public static IEnumerable<int> PegaPar(this IEnumerable<int> coll)
//     // {
//     //     foreach (var val in coll)
//     //         if (val % 2 == 0)
//     //             yield return val;
//     // }

//     // public static IEnumerable<int> PegaQuadrado(this IEnumerable<int> coll)
//     // {
//     //     foreach (var x in coll)
//     //         yield return x * x;
//     // }

//     // public static IEnumerable<int> PegaTop4(this IEnumerable<int> coll)
//     // {
//     //     var it = coll.GetEnumerator();
//     //     for (int i = 0; i < 4; i++)
//     //     {
//     //         if (it.MoveNext())
//     //             yield return it.Current;
//     //     }
//     // }

//     // public static int Sum(this IEnumerable<int> array)
//     // {
//     //     int soma = 0;
//     //     var it = array.GetEnumerator();
//     //     while (it.MoveNext())
//     //     {
//     //         soma += it.Current;
//     //     }
//     //     return soma;
//     // }
// }

// // public interface IEnumberable<T>
// // {
// //     IEnumerator<T> GetEnumerator();
// // }

// // public interface IEnumerator<T>
// // {
// //     bool MoveNext();
// //     T Current { get; }
// // }



// ====================================================================

using System.Linq;

Pessoa[] pessoas = [
    new Pessoa("Don", "210430"),
    new Pessoa("Queila", "456"),
    new Pessoa("Trevis", "123"),
    new Pessoa("Fabio", "2"),
];
Transferencia[] transferencia = [
    new Transferencia("210430", 1000),
    new Transferencia("210430", 800),
    new Transferencia("123", 250),
    new Transferencia("2", 1000),
    new Transferencia("456", 800),
    new Transferencia("123", 250),
    new Transferencia("456", 3000)
];

var query = pessoas
    .Where(p => p.Cpf.Length < 4)
    .Select(p => p.Nome);

var quer2 = 
    from p in pessoas
    join t in transferencia
    on p.Cpf equals t.Cpf
    select new { p.Nome, t.Valor } into r
    group r by r.Nome into g
    let sum = g.Sum(x => x.Valor)
    where sum > 5000
    select new { Nome = g.Key, Valor = sum };


// var pagamentoDados = pessoas
//     .Join(transferencia, p => p.Cpf, p => p.Cpf,
//     (pessoa, pagamento) => new { pessoa.Nome, pagamento.Valor });

public record Pessoa(string Nome, string Cpf);
public record Transferencia(string Cpf, decimal Valor);
public record Resultado(string Nome, decimal ValorTotal);

public static class Enumerator
{
    public static IEnumerable<R> Join<T, U, K, R>(
        this IEnumerable<T> source, IEnumerable<U> other,
        Func<T, K> keyA, Func<U, K> keyB,
        Func<T, U, R> map
        )
    {
        throw new NotImplementedException();
    }
}

// public interface IEnumberable<T>
// {
//     IEnumerator<T> GetEnumerator();
// }

// public interface IEnumerator<T>
// {
//     bool MoveNext();
//     T Current { get; }
// }