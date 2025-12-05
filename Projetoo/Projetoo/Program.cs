// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

// ----------------------------------------------------------------------
// Variáveis Globais (Características comuns do Paradigma Procedural)
// O Procedural frequentemente usa variáveis globais ou estruturas de dados
// que são manipuladas por diferentes procedimentos.
// ----------------------------------------------------------------------
public static class ConfiguracaoGlobal
{
    public static int NUM_SETORES { get; set; }
    public static int EXTTINTORES_POR_SETOR { get; set; }
    public static int SENSORES_POR_SETOR { get; set; }

    public static List<string> RelatorioFinal = new List<string>();
}

public class SegurancaTotal
{
    // ----------------------------------------------------------------------
    // PROCEDIMENTO PRINCIPAL: Orquestra o Fluxo de Trabalho (Main Routine)
    // ----------------------------------------------------------------------
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("PROGRAMA PROCEDURAL");
        Console.WriteLine("=================================================\n");
        Console.ResetColor();
        Console.Write("Insira a quantidade de setores: ");
        int qntSetor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Insira a quantidade de extintores por setor: ");
        int extSetor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Insira a quantidade de sensores por setor: ");
        int senSetor = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        ConfiguracaoGlobal.NUM_SETORES = qntSetor;
        ConfiguracaoGlobal.EXTTINTORES_POR_SETOR = extSetor;
        ConfiguracaoGlobal.SENSORES_POR_SETOR = senSetor;

        Console.WriteLine($"Iniciando inspeção em {ConfiguracaoGlobal.NUM_SETORES} setores...");
        Console.ReadKey();

        // 1. O FLUXO DE CONTROLE (Loops) é o coração da automação procedural.
        // O código dita a sequência exata de passos.
        for (int i = 1; i <= ConfiguracaoGlobal.NUM_SETORES; i++)
        {
            Console.Clear();
            Console.Write($"Insira o nome do setor {i}: ");
            string nome = Console.ReadLine();
            string setorNome = $"Setor {nome}";
            Console.Clear();
            Console.WriteLine($"-> Processando {setorNome}...\n");

            // 1.1. Inspeção de Extintores
            for (int j = 1; j <= ConfiguracaoGlobal.EXTTINTORES_POR_SETOR; j++)
            {
                Console.WriteLine($"O extintor {j} do {setorNome} foi testado? s/n");
                string resposta = Console.ReadLine();
                bool statusOk = (resposta?.ToLower() == "s");
                // Chama o PROCEDIMENTO de relatório, que é REUTILIZADO 10 vezes por setor
                GerarRelatorioExtintor(setorNome, j, statusOk);
            }
            Console.WriteLine("-----------------------------------");
            // 1.2. Inspeção de Sensores
            for (int k = 1; k <= ConfiguracaoGlobal.SENSORES_POR_SETOR; k++)
            {
                Console.WriteLine($"O sensor {k} do {setorNome} foi testado? s/n");
                string resposta = Console.ReadLine();
                bool statusOk = (resposta?.ToLower() == "s");
                // Chama o PROCEDIMENTO de relatório, que é REUTILIZADO 5 vezes por setor
                GerarRelatorioSensor(setorNome, k, statusOk);
            }
            Console.Clear();
        }

        // 2. Apresentação do Resultado (Outro Procedimento Lógico)
        ApresentarResumoRelatorio();
    }

    // ----------------------------------------------------------------------
    // PROCEDIMENTO 1: Gera uma entrada de relatório para Extintores
    // Esta função é uma rotina reutilizável.
    // ----------------------------------------------------------------------
    public static void GerarRelatorioExtintor(string setor, int numero, bool statusOk)
    {
        // Simulação de dados de inspeção
        string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        string status = statusOk ? "APROVADO" : "REPROVADO";
        // Cria a linha do relatório e ADICIONA ao estado global (RelatorioFinal)
        string linha = $"{data} | {setor} | Extintor #{numero:D2} | Status: {status}";
        ConfiguracaoGlobal.RelatorioFinal.Add(linha);
    }

    // ----------------------------------------------------------------------
    // PROCEDIMENTO 2: Gera uma entrada de relatório para Sensores
    // Outra rotina, focada em outro tipo de equipamento.
    // ----------------------------------------------------------------------
    public static void GerarRelatorioSensor(string setor, int numero, bool statusOk)
    {
        // Simulação de dados de inspeção
        string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        string status = statusOk ? "APROVADO" : "REPROVADO";
        // Cria a linha do relatório e ADICIONA ao estado global
        string linha = $"{data} | {setor} | Sensor Fumaça #{numero:D2} | Status: {status}";
        ConfiguracaoGlobal.RelatorioFinal.Add(linha);
    }

    // ----------------------------------------------------------------------
    // PROCEDIMENTO 3: Analisa o estado global (RelatorioFinal) e imprime o resumo
    // ----------------------------------------------------------------------
    public static void ApresentarResumoRelatorio()
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=================================================");
        Console.WriteLine($"RELATÓRIO FINAL: {ConfiguracaoGlobal.RelatorioFinal.Count} ITENS INSPECIONADOS");
        Console.WriteLine("=================================================");
        Console.ResetColor();

        // Exibe apenas as falhas
        var falhas = ConfiguracaoGlobal.RelatorioFinal
            .Where(r => r.Contains("REPROVADO"))
            .ToList();

        if (falhas.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--- DETECTADAS {falhas.Count} FALHAS DE SEGURANÇA ---\n");
            Console.ResetColor();
            foreach (var falha in falhas)
            {
                Console.WriteLine(falha);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTODOS OS {ConfiguracaoGlobal.NUM_SETORES} EQUIPAMENTOS ESTÃO EM CONFORMIDADE (OK).");
            Console.ResetColor();
        }

        Console.WriteLine("\nO relatório completo foi gerado.");
    }
}

//Ao executar pela primeira vez, fazer cadastro dos setores, após fazer isso, exibir lista dos setores cadastrados, com opção de cadastrar novos ou remover, e opção de sair.