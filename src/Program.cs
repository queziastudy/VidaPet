using System;
using System.Globalization;

namespace VidaPet
{
    class VidaPet
    {
        static void Main(string[] args) {

            int opcao;

            string nomeVet = "";
            string crmv = "";

            string nomeAnimal = "";
            string especie = "";
            double idade;
            string nomeTutor = "";
            string telefoneTutor = "";
            do {
                ExibirMenu();
                opcao = ObterOpcao();

                switch (opcao) {
                    case 1:
                        CadastrarVeterinario(out nomeVet, out crmv);

                        Console.WriteLine($"O(a) Veterinário(a) {nomeVet}, CRMV {crmv} foi cadastrado(a) com sucesso!");
                        break;
                    case 2:
                        CadastrarAnimal(out nomeAnimal, out especie, out idade, out nomeTutor, out telefoneTutor);

                        Console.WriteLine("--- Animal cadastrado com sucesso ---");
                        Console.WriteLine($"Nome: {nomeAnimal}\nEspécie: {especie}\nIdade: {idade}\nTutor(a): {nomeTutor}\nContato: {telefoneTutor}");

                        break;
                    case 3:
                        string nomeAnimalAtendimento;
                        string crmvVeterinarioAtendendo;
                        DateTime dataHoraAtendimento;

                        if (string.IsNullOrEmpty(crmv)) {
                            Console.WriteLine("--- Nenhum veterinário cadastrado. ---");
                            break;
                        }

                        if (string.IsNullOrEmpty(nomeAnimal))
                        {
                            Console.WriteLine("--- Nenhum animal cadastrado. ---");
                            break;
                        }

                        AgendarConsulta(nomeAnimal, crmv, out nomeAnimalAtendimento, out crmvVeterinarioAtendendo, out dataHoraAtendimento);

                        Console.WriteLine();
                        Console.WriteLine("--- Consulta agendada com sucesso! ---");
                        Console.WriteLine($"Animal: {nomeAnimalAtendimento}\nCRMV do Veterinário: {crmvVeterinarioAtendendo}\nData e hora: {dataHoraAtendimento:dd/MM/yyyy HH:mm}");

                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("=== Consultar Agenda Diária ===");
                        break;

                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("=== Registrar Consulta Realizada ===");
                        break;

                    case 0:
                        Console.WriteLine();
                        Console.WriteLine("Saindo...");
                        break;

                    default: 
                        Console.WriteLine(">>> Opção inválida. Tente Novamente. <<<");
                        break;
                }
            }
            while (opcao != 0);
        }

        public static void ExibirMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========= Menu Inicial - VidaPet =========");
            Console.WriteLine("1 - Cadastro de Veterinário");
            Console.WriteLine("2 - Cadastro de Animal");
            Console.WriteLine("3 - Agendamento de Consulta");
            Console.WriteLine("4 - Consulta de Agenda Diária");
            Console.WriteLine("5 - Registro de Consulta Realizada");
            Console.WriteLine("0 - Sair");
        }

        public static int ObterOpcao() {

            int opcao;
            bool entradaValida;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção do menu: ");
                string entrada = Console.ReadLine();

                entradaValida = int.TryParse(entrada, out opcao);

                if (!entradaValida) {
                    Console.WriteLine("Erro: Entrada Inválida. Tente novamente!");
                }
            } while (!entradaValida);


            return opcao;
        }

        static void CadastrarVeterinario(out string nomeVet, out string crmvVet) {
            Console.WriteLine();
            Console.WriteLine("=== Cadastrar Veterinário ===");

            do
            {
                Console.WriteLine("Digite o NOME do veterinário ");
                nomeVet = Console.ReadLine();
            } while (string.IsNullOrEmpty(nomeVet));

            do
            {
                Console.WriteLine("Digite o CRMV do veterinário ");
                crmvVet = Console.ReadLine();
            } while (string.IsNullOrEmpty(crmvVet));
        }
        
        static void CadastrarAnimal(out string nomeAnimal, out string especieAnimal, out double idadeAnimal, out string nomeTutor, out string telefoneTutor)
        {
            Console.WriteLine();
            Console.WriteLine("=== Cadastrar Animal ===");

            do {
                Console.WriteLine("Digite o NOME do animal");
                nomeAnimal = Console.ReadLine();
            } while (string.IsNullOrEmpty(nomeAnimal));

            do {
                Console.WriteLine("Digite a ESPÉCIE do animal");
                especieAnimal = Console.ReadLine();
            } while (string.IsNullOrEmpty(especieAnimal));

            do {
                Console.WriteLine("Digite a IDADE do animal");
            } while (!double.TryParse(Console.ReadLine(), out idadeAnimal));

            do {
                Console.WriteLine("Digite o NOME do TUTOR");
                nomeTutor = Console.ReadLine();
            } while (string.IsNullOrEmpty(nomeTutor));

            do {
                Console.WriteLine("Digite o TELEFONE do TUTOR");
                telefoneTutor = Console.ReadLine();
            } while (string.IsNullOrEmpty(telefoneTutor) || (telefoneTutor.Length < 11 || telefoneTutor.Length > 14));
        }
    
        static void AgendarConsulta(string nomeAnimalCadastrado, string crmvVeterinarioCadastrado, out string nomeAnimalConsulta, out string crmvVeterinarioConsulta, out DateTime dataHoraConsulta) {
            nomeAnimalConsulta = "";
            crmvVeterinarioConsulta = "";

            Console.WriteLine();
            Console.WriteLine("=== Agendar Consulta ===");

            bool dataValida;

            do {
                Console.WriteLine("Digite o NOME do ANIMAL a ser atendido: ");
                nomeAnimalConsulta = Console.ReadLine();

                if (string.IsNullOrEmpty(nomeAnimalConsulta)) {
                    Console.WriteLine("O nome do animal não pode estar vazio.");
                } else if (nomeAnimalConsulta != nomeAnimalCadastrado) {
                    Console.WriteLine("Erro: Não foi encontrado um animal com esse nome.");
                }

            } while (string.IsNullOrEmpty(nomeAnimalConsulta) || nomeAnimalConsulta != nomeAnimalCadastrado);

            do {
                Console.WriteLine("Digite o CRMV do VETERINÁRIO a realizar o atendimento: ");
                crmvVeterinarioConsulta = Console.ReadLine();

                if (string.IsNullOrEmpty(crmvVeterinarioConsulta)) {
                    Console.WriteLine("Erro: O CRMV não pode estar vazio.");
                } else if (crmvVeterinarioConsulta != crmvVeterinarioCadastrado) {
                    Console.WriteLine("Erro: Não foi encontrado um veterinário com esse CRMV.");
                }
            } while (string.IsNullOrEmpty(crmvVeterinarioConsulta) || crmvVeterinarioConsulta != crmvVeterinarioCadastrado);

            do {
                Console.WriteLine("Digite a DATA e HORA da consulta (dd/MM/yyyy HH:mm): ");

                string dataHoraDigitados = Console.ReadLine();

                dataValida = DateTime.TryParseExact(dataHoraDigitados, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out dataHoraConsulta);

                if (!dataValida)
                {
                    Console.WriteLine("Data ou hora inválida! Tente novamente.");
                }
            } while (!dataValida);

        }
    }
}