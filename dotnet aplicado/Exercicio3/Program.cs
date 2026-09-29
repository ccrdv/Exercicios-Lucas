using System;

public class Reserva
{
    public int Id { get; set; }
    public string NomeHospede { get; set; }
    public int NumeroQuarto { get; set; }
    public int QuantidadeDiarias { get; set; }
    public decimal ValorDiaria { get; set; }
    public string StatusInterno { get; set; }
    public string ObservacaoInterna { get; set; }
}

public record RelatorioReservaDto(string NomeHospede, int NumeroQuarto, int QuantidadeDiarias, decimal ValorTotal, string Situacao);

class Program
{
    public static RelatorioReservaDto Mapear(Reserva reserva)
    {
        return new RelatorioReservaDto(
            reserva.NomeHospede,
            reserva.NumeroQuarto,
            reserva.QuantidadeDiarias,
            reserva.QuantidadeDiarias * reserva.ValorDiaria,
            "Reserva confirmada"
        );
    }

    public static void ExibirRelatorio(RelatorioReservaDto relatorio)
    {
        Console.WriteLine("--- Relatório da Reserva ---");
        Console.WriteLine($"Hóspede: {relatorio.NomeHospede}");
        Console.WriteLine($"Quarto: {relatorio.NumeroQuarto}");
        Console.WriteLine($"Quantidade de Diárias: {relatorio.QuantidadeDiarias}");
        Console.WriteLine($"Valor Total: {relatorio.ValorTotal:C}");
        Console.WriteLine($"Situação: {relatorio.Situacao}");
    }

    static void Main()
    {
        var reserva = new Reserva
        {
            Id = 101,
            NomeHospede = "Tiago Silva",
            NumeroQuarto = 42,
            QuantidadeDiarias = 3,
            ValorDiaria = 120.00m,
            StatusInterno = "Pendente Verificação",
            ObservacaoInterna = "Hóspede frequente"
        };

        var dto = Mapear(reserva);
        ExibirRelatorio(dto);
    }
}