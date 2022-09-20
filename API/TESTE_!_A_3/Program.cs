using System;

namespace TESTE___A_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total de eleitores = 1000");
            Console.WriteLine("Válidos = 800");
            Console.WriteLine("votos brancos = 150");
            Console.WriteLine("nulos = 50");
            Console.WriteLine("Calcular porcentagens");
            Console.ReadLine();
            var porcentagens = new Porcentagens();
            Console.WriteLine(porcentagens.Valiado(1000, 800));
            Console.ReadLine();
            Console.WriteLine(porcentagens.Brancos(1000, 150));
            Console.ReadLine();
            Console.WriteLine(porcentagens.Nulos(1000, 50));
            Console.ReadLine();
            BubbleSort();
            Console.ReadLine();
            Console.WriteLine("Calcular Fatorial");
            Console.ReadLine();
            Fatorial();
            Console.WriteLine("Somar números naturais de 3 e 5");
            Console.ReadLine();
            SomarNumeroNaturais();
            Console.ReadLine();
        }

        public static void BubbleSort()
        {
            Console.WriteLine("Ordenação Bubble Sort ");
            Console.WriteLine("=>valor analisado ** { 5, 3, 2, 4, 7, 1, 0, 6 }** ");
            int[] v = { 5, 3, 2, 4, 7, 1, 0, 6 };

            int temp = 0;

            for (int i = 0; i < v.Length; i++)
            {
                for (int ordena = 0; ordena < v.Length - 1; ordena++)
                {
                    if (v[ordena] > v[ordena + 1])
                    {
                        temp = v[ordena + 1];
                        v[ordena + 1] = v[ordena];
                        v[ordena] = temp;
                    }
                }
            }
            Console.ReadLine();
            Console.WriteLine("Retrono :");
            Console.Write("{");
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.Write("}");

        }

        private static void Fatorial()
        {
            Console.WriteLine("Informe o numero");

            Func<double, double> fat = null;

            fat = x => x <= 1 ? 1 : x * fat(x - 1);

            var numero = double.Parse(ValidarInput(Console.ReadLine()));

            Console.WriteLine(fat(numero));
        }
        private static void SomarNumeroNaturais()
        {
            Console.WriteLine("Informe o numero");

            var numero = double.Parse(ValidarInput(Console.ReadLine()));
            var result = 0;
            for (int i = 0; i < numero; i++)
            {
                if ((i % 3) == 0 || (i % 5) == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine(result);
        }


        private static string ValidarInput(string input)
        {

            long number = 0;
            var validType = long.TryParse(input, out number);

            if (string.IsNullOrEmpty(input) || !validType)
            {
                Console.WriteLine("Valor invalido! Por favor digite apenas numeros: ex 5 ");
                input = Console.ReadLine();
                input = ValidarInput(input);
            }
            return input;
        }
    }
}
