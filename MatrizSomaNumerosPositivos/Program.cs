using System;

namespace MatrizSomaNumerosPositivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#################################################");
            Console.WriteLine("### Programa para soma de cartela de um bingo ###");
            Console.WriteLine("#################################################");

            int quantidadeLinhas, quantidadeColunas;

            Console.WriteLine("Informe o número de linhas da cartela: ");
            string? linhasInformadas = Console.ReadLine();
            quantidadeLinhas = Convert.ToInt32(linhasInformadas);

            Console.WriteLine("Informe o número de colunas da cartela: ");
            string? colunasInformadas = Console.ReadLine();
            quantidadeColunas = Convert.ToInt32(colunasInformadas);

            int[,] matrizNumeros = new int[quantidadeLinhas, quantidadeColunas];

            for (int contadorLinha = 0; contadorLinha < quantidadeLinhas; contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < quantidadeColunas; contadorColuna++)
                {
                    // receber como string para validar depois nos métodos...
                    int numeroInformado;
                    Console.WriteLine($"Informe o valor da linha {contadorLinha + 1}, coluna {contadorColuna +1}");
                    numeroInformado = Convert.ToInt32(Console.ReadLine());
                    matrizNumeros[contadorLinha, contadorColuna] = numeroInformado;
                }
            }

            int soma = 0;

            for (int contadorLinha = 0; contadorLinha < quantidadeLinhas; contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < quantidadeColunas; contadorColuna++)
                {
                    int valorLido = matrizNumeros[contadorLinha, contadorColuna];
                    if (valorLido < 0)
                        continue;

                    soma = soma + matrizNumeros[contadorLinha, contadorColuna];
                }
            }

            Console.WriteLine($"A soma é {soma}");
            Console.ReadKey();

        }
    }
}