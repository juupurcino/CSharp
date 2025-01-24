

public class Caixa<T> where T : class
{
    public T Item { get; set; }
    
    public Caixa(T item)
    {
        Item = item;
    }

    public void MostrarItem()
    {
        Console.WriteLine($"Item: {Item}");
    }
}

// Usando a classe com tipos de referência:
Caixa<string> caixaDeTexto = new Caixa<string>("Texto Exemplo");
caixaDeTexto.MostrarItem(); // Funciona normalmente

// Caixa<int> caixaDeInteiro = new Caixa<int>(5); // Erro! 'int' não é uma classe, é um tipo valor

public class CaixaDeValor<T> where T : struct
{
    public T Item { get; set; }

    public CaixaDeValor(T item)
    {
        Item = item;
    }

    public void MostrarItem()
    {
        Console.WriteLine($"Item: {Item}");
    }
}

// Usando a classe com tipos de valor:
CaixaDeValor<int> caixaDeInteiro = new CaixaDeValor<int>(10);
caixaDeInteiro.MostrarItem(); // Funciona normalmente

// CaixaDeValor<string> caixaDeTexto = new CaixaDeValor<string>("Texto"); // Erro! 'string' não é um tipo valor

public class Fabrica<T> where T : new()
{
    public T Criar()
    {
        return new T(); // Cria uma nova instância de T
    }
}

// Usando a classe com tipos que têm construtor sem parâmetros:
Fabrica<List<int>> fabricaDeLista = new Fabrica<List<int>>();
List<int> lista = fabricaDeLista.Criar(); // Funciona, pois 'List<int>' tem um construtor padrão
Console.WriteLine(lista.GetType()); // Imprime "System.Collections.Generic.List`1[System.Int32]"

// Fabrica<int> fabricaDeInt = new Fabrica<int>(); // Erro! 'int' não tem construtor sem parâmetros


public class Animal { }

public class Cachorro : Animal { }

public class CaixaDeAnimal<T, U> where T : U
{
    public T Animal { get; set; }
    
    public CaixaDeAnimal(T animal)
    {
        Animal = animal;
    }

    public void MostrarAnimal()
    {
        Console.WriteLine($"Animal: {Animal.GetType().Name}");
    }
}

// Usando a classe com tipos que herdam de Animal:
CaixaDeAnimal<Cachorro, Animal> caixaDeCachorro = new CaixaDeAnimal<Cachorro, Animal>(new Cachorro());
caixaDeCachorro.MostrarAnimal(); // Funciona, pois 'Cachorro' herda de 'Animal'

// CaixaDeAnimal<string, Animal> caixaDeString = new CaixaDeAnimal<string, Animal>("Gato"); // Erro! 'string' não herda de 'Animal'

public class Pessoa
{
    public string Nome { get; set; }
}

public class Funcionario : Pessoa { }

public class Aprendiz : Funcionario { }

public interface B<out T>  // 'out' significa que o tipo T pode ser mais específico
{
    T GetValue();
}

public class C<T> : B<T>  // C implementa B<T>
{
    public T GetValue()
    {
        return default(T);  // Apenas para exemplo
    }
}

public class Program
{
    public static void Main()
    {
        // Aqui, C<Funcionario> pode ser tratado como B<Pessoa>
        B<Pessoa> bPessoa = new C<Funcionario>(); // Funciona, porque Funcionario é uma Pessoa

        // Mesmo que você tenha um Funcionario, ele pode ser usado como uma Pessoa.
        Pessoa p = bPessoa.GetValue();
        Console.WriteLine(p);  // Vai mostrar 'null', porque GetValue apenas retorna o valor default de T
    }
}
