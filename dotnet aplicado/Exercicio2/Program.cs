using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
public class ExibirAttribute : Attribute { }

public class Equipamento
{
    public int Id { get; set; }
    [Exibir] public string Nome { get; set; }
    [Exibir] public string Fabricante { get; set; }
    public string NumeroSerie { get; set; }
    [Exibir] public double Valor { get; set; }
    [Exibir] public string Localizacao { get; set; }
}

class Program
{
    public static void ExibirDadosAberto(object objeto)
    {
        Console.WriteLine("--- Reflection Aberta ---");
        foreach (var prop in objeto.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto)}");
        }
    }

    public static void ExibirDadosControlado(object objeto)
    {
        Console.WriteLine("--- Reflection Controlada ---");
        foreach (var prop in objeto.GetType().GetProperties())
        {
            if (prop.GetCustomAttribute<ExibirAttribute>() != null)
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto)}");
            }
        }
    }

    static void Main()
    {
        var equipamento = new Equipamento
        {
            Id = 1,
            Nome = "Notebook TUF A15",
            Fabricante = "Asus",
            NumeroSerie = "SN123456",
            Valor = 4499.99,
            Localizacao = "Laboratório 1"
        };

        ExibirDadosAberto(equipamento);
        Console.WriteLine();
        ExibirDadosControlado(equipamento);
    }
}