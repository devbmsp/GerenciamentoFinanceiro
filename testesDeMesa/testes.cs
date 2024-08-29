using System;
using System.Diagnostics.CodeAnalysis;

namespace testes
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Você gostaria de calcula o valor do VP ou o VF ?");
            string valorResp = (Console.ReadLine());

            Console.WriteLine("Digite o valor base para calculo");
            float valor = float.Parse(Console.ReadLine());

            Console.WriteLine("Digite a taxa de juros (sem %): ");
            double tx = double.Parse(Console.ReadLine()) / 100;

            Console.WriteLine("Digite a quant. de meses: ");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Gostaria de Sacar o valor em algum mês? s/n ");
            string resgateResp = Console.ReadLine();

            testeMesa2 tm2 = new testeMesa2(valor, tx, m, resgateResp, valorResp);

        }

        public class testeMesa2
        {

            public float valor;
            public double taxaJuros;
            public int mes;
            public string rp;
            public int mesSaque;
            public int cont = 0;
            public string valorResp;
            public testeMesa2(float valor, double taxaJuros, int mes, string rp, string valorResp)
            {
                static void CalculoRendimentoSaque(float valor, float valorSolicitado, double taxa, int mesSolicitado, int meses, int contador)
                {
                    for (int i = 0; i < meses + 1; i++)
                    {
                        double f = valor * Math.Pow(1 + taxa, contador);
                        contador++;

                        if (mesSolicitado == i)
                        {
                            contador = 1;
                            valor = (float)f - valorSolicitado;
                            Console.WriteLine("Rendimento do mês " + i + " e Renda acumulada  = " + f.ToString("F2"));
                            Console.WriteLine("Após seu resgate de " + valorSolicitado + " o seu saldo ficou " + f.ToString("F2"));
                        }
                        else
                        {
                            Console.WriteLine("Rendimento do mês " + i + " e Renda acumulada  = " + f.ToString("F2"));
                        }

                        float rendaLiquida = (float)f - valor;
                        Console.WriteLine("Renda Liquida : " + rendaLiquida.ToString("F2"));

                    }
                }

                static void CalculoRendimento(float valor, double taxaJuros, int mes)
                {
                    for (int i = 0; i < mes + 1; i++)
                    {
                        double f = valor * Math.Pow(1 + taxaJuros, i);
                        Console.WriteLine("Rendimento do mês " + i + "= " + f.ToString("F2"));
                    }
                }

                static void CalculoValorPresente(float valor, double taxaJuros, int mes)
                {
                    double valorPresente = valor / Math.Pow(1 + taxaJuros, mes);
                    Console.WriteLine("Valor presente necessário  = " + valorPresente.ToString("F2"));
                }

                switch (valorResp)
                {
                    case "vf" or "VF":
                        if (rp == "n")
                        {
                            CalculoRendimento(valor, taxaJuros, mes);

                        }
                        else if (rp == "s")
                        {
                            Console.WriteLine("Digite o mês que deseja sacar :");
                            int mesSaque = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite o Valor que deseja Sacar : ");
                            float valorSaqueMes = float.Parse(Console.ReadLine());

                            CalculoRendimentoSaque(valor, valorSaqueMes, taxaJuros, mesSaque, mes, cont);
                        }
                        else
                        {
                            Console.WriteLine("Digite s = sim ou n = não");
                        }
                        return;

                    case "vp" or "VP":
                        CalculoValorPresente(valor, taxaJuros, mes);

                        return;

                }

            }
        }
