using Agendamento.Models;
using System;
using System.Linq;

namespace Agendamento.Data
{
    public class SeedingService
    {
        private readonly AppDbContext _context;

        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        public void Popula()
        {
            if (_context.Medicos.Any() && _context.Pacientes.Any())
            {
                return;
            }

            if (!_context.Medicos.Any())
            {
                Medico m1 = new Medico
                {
                    Nome = "Luiza",
                    Crm = "123456",
                    Especialidade = "Vascular"
                };

                Medico m2 = new Medico
                {
                    Nome = "João",
                    Crm = "456789",
                    Especialidade = "Ortopedista"
                };

                _context.Medicos.AddRange(m1, m2);
            }

            if (!_context.Pacientes.Any())
            {
                Paciente p1 = new Paciente
                {
                    Nome = "Carlos Andrade",
                    Cpf = "111.222.333-44",
                    Telefone = "(11) 99999-1234",
                    Endereco = "Rua das Laranjeiras, 100",
                    DataNascimento = new DateTime(1992, 4, 15)
                };

                Paciente p2 = new Paciente
                {
                    Nome = "Juliana Costa",
                    Cpf = "555.666.777-88",
                    Telefone = "(11) 98888-5678",
                    Endereco = "Avenida Brasil, 200",
                    DataNascimento = new DateTime(1988, 8, 22)
                };

                _context.Pacientes.AddRange(p1, p2);
            }

            _context.SaveChanges();
        }
    }
}