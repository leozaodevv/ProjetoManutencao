using System;

class Program
{
    // Procedimento que “verifica” um setor e retorna se está ok (true) ou não (false)
    static bool Verificar_Equipamento(string setor)
    {
        Console.WriteLine($"Verificação dos equipamentos do setor {setor}...");
        Console.Write($"Todos os extintores de incêndio e sensores de fumaça do setor {setor} foram testados? (s/n): ");
        string resposta = Console.ReadLine();
        bool statusOk = (resposta?.ToLower() == "s");
        Console.Clear();
        Console.WriteLine($"Verificação do setor {setor} concluída: {(statusOk ? "OK" : "Problemas encontrados")}");
        return statusOk;
    }

    static void Mostrar_Situacao(bool verificadoTI, bool statusTI, bool verificadoAdmin, bool statusAdmin)
    {
        Console.Clear();
        Console.WriteLine("--- Situação de todos os setores ---\n");

        if (!verificadoTI)
        {
            Console.WriteLine("TI: Não verificado");
        }
        else
        {
            Console.WriteLine($"TI: {(statusTI ? "OK" : "Problemas")}");
        }
            

        if (!verificadoAdmin)
        {
            Console.WriteLine("Administrativo: Não verificado");
        }

        else
        {
            Console.WriteLine($"Administrativo: {(statusAdmin ? "OK" : "Problemas")}");
        }
            
        Console.WriteLine("\n------------------------------------\n");
        Console.WriteLine("Aperte qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void Main()
    {
        bool verificadoTI = false;
        bool statusTI = false;

        bool verificadoAdmin = false;
        bool statusAdmin = false;

        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Verificar setor de TI");
            Console.WriteLine("2 - Verificar setor Administrativo");
            Console.WriteLine("3 - Ver situação de todos os setores");
            Console.WriteLine("4 - Sair");

            Console.Write("Digite sua opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    statusTI = Verificar_Equipamento("TI");
                    verificadoTI = true;
                    Console.WriteLine("\nAperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    statusAdmin = Verificar_Equipamento("Administrativo");
                    verificadoAdmin = true;
                    Console.WriteLine("\nAperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    Mostrar_Situacao(verificadoTI, statusTI, verificadoAdmin, statusAdmin);
                    break;
                case "4":
                    Console.Clear();
                    continuar = false;
                    Console.WriteLine("Encerrando o programa...");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.WriteLine("\nAperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
