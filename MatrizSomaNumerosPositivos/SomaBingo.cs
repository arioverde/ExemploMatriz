using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizSomaNumerosPositivos
{
    internal class SomaBingo
    {
        private int QuantidadeLinhas { get; set; }
        private int QuantidadeColunas { get; set; }

        // Esse método será um orquestrador de chamadas
        public void Executar()
        {
            ExibirCabecalho();
            ReceberQuantidadeLinhasColunasCartela();
            int[,] matrizNumeros = PerguntarUsuarioNumerosCartela();
            int soma = SomarNumerosPositivos(matrizNumeros);
            ExibirResultado(soma);
        }
        private void ExibirCabecalho()
        {
            Console.WriteLine("#################################################");
            Console.WriteLine("### Programa para soma de cartela de um bingo ###");
            Console.WriteLine("#################################################");
        }
        private void ReceberQuantidadeLinhasColunasCartela()
        {
            Console.WriteLine("Informe o número de linhas da cartela: ");
            string? linhasInformadas = Console.ReadLine();
            QuantidadeLinhas = Convert.ToInt32(linhasInformadas);

            Console.WriteLine("Informe o número de colunas da cartela: ");
            string? colunasInformadas = Console.ReadLine();
            QuantidadeColunas = Convert.ToInt32(colunasInformadas);
        }
        private int[,] PerguntarUsuarioNumerosCartela()
        {
            int[,] matrizNumeros = new int[QuantidadeLinhas, QuantidadeColunas];

            for (int contadorLinha = 0; contadorLinha < QuantidadeLinhas; contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < QuantidadeColunas; contadorColuna++)
                {
                    // receber como string para validar depois nos métodos...
                    int numeroInformado;
                    Console.WriteLine($"Informe o valor da linha {contadorLinha + 1}, coluna {contadorColuna + 1}");
                    numeroInformado = Convert.ToInt32(Console.ReadLine());
                    matrizNumeros[contadorLinha, contadorColuna] = numeroInformado;
                }
            }

            return matrizNumeros;
        }
        private int SomarNumerosPositivos(int[,] matrizNumeros)
        {
            int soma = 0;
            for (int contadorLinha = 0; contadorLinha < QuantidadeLinhas; contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < QuantidadeColunas; contadorColuna++)
                {
                    int valorLido = matrizNumeros[contadorLinha, contadorColuna];
                    if (valorLido < 0)
                        continue;

                    soma = soma + matrizNumeros[contadorLinha, contadorColuna];
                }
            }
            return soma;
        }
        private void ExibirResultado(int soma)
        {
            Console.WriteLine($"A soma é {soma}");
            Console.ReadKey();
        }
    }
}
