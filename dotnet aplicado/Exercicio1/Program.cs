using System;

public class UsuarioBiblioteca
{
    public string Nome { get; set; }
    public int QuantidadeEmprestimosAtivos { get; set; }
}

public class Aluno : UsuarioBiblioteca
{
    public string Matricula { get; set; }
}

public class Professor : UsuarioBiblioteca
{
    public string Departamento { get; set; }
}

public class Visitante : UsuarioBiblioteca
{
    public string Documento { get; set; }
}

class Program
{
    public static string VerificarEmprestimo(object obj)
    {
        return obj switch
        {
            null => "Usuário inválido",
            Aluno { QuantidadeEmprestimosAtivos: < 3 } => "Empréstimo autorizado para aluno",
            Aluno { QuantidadeEmprestimosAtivos: >= 3 } => "Limite de empréstimos atingido para aluno",
            Professor { QuantidadeEmprestimosAtivos: < 5 } => "Empréstimo autorizado para professor",
            Professor { QuantidadeEmprestimosAtivos: >= 5 } => "Limite de empréstimos atingido para professor",
            Visitante => "Visitantes não podem realizar empréstimos",
            _ => "Usuário não classificado"
        };
    }

    static void Main()
    {
        var alunoAutorizado = new Aluno { Nome = "João", QuantidadeEmprestimosAtivos = 2 };
        var alunoBloqueado = new Aluno { Nome = "Maria", QuantidadeEmprestimosAtivos = 4 };
        var professorAutorizado = new Professor { Nome = "Carlos", QuantidadeEmprestimosAtivos = 3 };
        var visitante = new Visitante { Nome = "Ana" };
        var outroObj = new { Nome = "Teste" };
        var professorBloqueado = new Professor { Nome = "Marta", QuantidadeEmprestimosAtivos = 6 };
        
        Console.WriteLine(VerificarEmprestimo(alunoAutorizado));
        Console.WriteLine(VerificarEmprestimo(alunoBloqueado));
        Console.WriteLine(VerificarEmprestimo(professorAutorizado));
        Console.WriteLine(VerificarEmprestimo(visitante));
        Console.WriteLine(VerificarEmprestimo(null));
        Console.WriteLine(VerificarEmprestimo(outroObj));
        Console.WriteLine(VerificarEmprestimo(professorBloqueado));
    }
}