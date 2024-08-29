using System;
using System.Diagnostics.CodeAnalysis;

namespace testesDeMesa
{
    class MainClass
    {
        static void Main(string[] args)
        {
            testeMesa1 tm = new testeMesa1();

            Console.WriteLine("Valor de a: " + tm.a + " | Valor de b: " + tm.b + " | Valor de c: " + tm.c + " | Valor de c: " +
                tm.cx + "(serve para calculo do v[3])" + " | Valor de v: " + tm.v);

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
    }
    class testeMesa2
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


    public class testeMesa1
    {
        //1
        public int a;
        public int b;
        public int c;
        public int cx;
        public int v;
        //2
        public int a2;
        public int[] v2 = new int[6];
        //3
        public int a3;
        public int b3;
        public int[] v3 = new int[20];


        public testeMesa1()
        {

            this.a = 10;
            this.b = 20;
            this.c = (a + b) / 2;
            this.cx = this.c - 40;
            this.v = a + b + this.cx;


            this.a2 = 2;
            for (int i = a2; i < 6; i++)
            {
                v2[i] = 10 * i;
                Console.WriteLine("a2 = " + i + " v2[a2] = " + v2[i]);
            }


            this.a3 = 7;
            this.b3 = a3 - 6;
            while (b3 < a3)
            {
                v3[b3] = b3 + a3;
                Console.WriteLine("b3 = " + b3 + " v3[b3] = " + v3[b3]);
                b3 += 2;
            }
        }
    }
}



