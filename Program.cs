using System.Text;
using desafio_hospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Lista para armazenar várias reservas
List<Reserva> reservas = new List<Reserva>();

bool menu = true;

while (menu)
{
    Console.Clear();
    Console.WriteLine("\t--- Hotel Mark1n ---");
    Console.WriteLine("Escolha uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar Suíte e Hóspedes");
    Console.WriteLine("2 - Exibir Reservas");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Cadastrar suíte e hóspedes
            Console.WriteLine("\n--- Cadastrar Suíte ---");
            Console.Write("Informe o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();

            Console.Write("Informe a capacidade da suíte: ");
            int capacidadeSuite;
            while (!int.TryParse(Console.ReadLine(), out capacidadeSuite))
            {
                Console.WriteLine("Por favor, insira um número válido para a capacidade.");
            }

            Console.Write("Informe o valor da diária: ");
            decimal valorDiaria;
            while (!decimal.TryParse(Console.ReadLine(), out valorDiaria))
            {
                Console.WriteLine("Por favor, insira um valor válido para a diária.");
            }

            Suite suite = new Suite(tipoSuite, capacidadeSuite, valorDiaria);

            Console.Write("\nQuantos dias o hóspede ficará na reserva? ");
            int diasReservados;
            while (!int.TryParse(Console.ReadLine(), out diasReservados))
            {
                Console.WriteLine("Por favor, insira um número válido para os dias reservados.");
            }

            // Cadastrar hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();
            Console.Write("Quantos hóspedes deseja cadastrar? ");
            int quantidadeHospedes;
            while (!int.TryParse(Console.ReadLine(), out quantidadeHospedes))
            {
                Console.WriteLine("Por favor, insira um número válido.");
            }

            if (quantidadeHospedes > suite.Capacidade)
            {
                Console.WriteLine($"A quantidade de hóspedes não pode exceder a capacidade da suíte ({suite.Capacidade} hóspedes).");
            }
            else
            {
                for (int i = 1; i <= quantidadeHospedes; i++)
                {
                    Console.Write($"Informe o nome do hóspede {i}: ");
                    string nomeHospede = Console.ReadLine();
                    hospedes.Add(new Pessoa(nomeHospede));
                }

                // Criar a reserva e adicionar à lista de reservas
                Reserva reserva = new Reserva(hospedes, suite, diasReservados);
                reservas.Add(reserva);

                Console.WriteLine("\nSuíte e hóspedes cadastrados com sucesso!");
            }
            break;

        case "2":
            // Exibir reservas e hóspedes de cada suíte
            if (reservas.Count > 0)
            {
                Console.WriteLine("\n--- Reservas ---");
                foreach (var reserva in reservas)
                {
                    Console.WriteLine($"\nSuíte: {reserva.Suite.TipoSuite}");
                    Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
                    Console.WriteLine($"Valor diária: {reserva.Suite.ValorDiaria}");
                    Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
                    Console.WriteLine("Hóspedes:");

                    foreach (var hospede in reserva.Hospedes)
                    {
                        Console.WriteLine($"- {hospede.Nome}");
                    }

                    Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria()}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
            }
            break;

        case "0":
            // Sair
            Console.WriteLine("Encerrando o programa...");
            menu = false;
            break;

        default:
            Console.WriteLine("Opção inválida! Por favor, escolha uma opção válida.");
            break;
    }

    // Pausa para o usuário visualizar a saída antes de limpar o console
    if (menu)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

Console.WriteLine("Programa encerrado.");
