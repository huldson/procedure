using bancoDedados_procedure;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IBancoDeDados, BancoDeDados>()
            .BuildServiceProvider();

        
        var bancoDeDados = serviceProvider.GetService<IBancoDeDados>();
        
        Console.WriteLine("primeiro"+bancoDeDados.PegarQuantidade());
        bancoDeDados.Unificar();
        Console.WriteLine("segundo:"+bancoDeDados.PegarQuantidade());
        Console.WriteLine(bancoDeDados.Exbir());

    }
}