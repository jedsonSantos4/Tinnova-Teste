using System;

namespace TESTE___A_3
{
    public class Porcentagens
    {

        public string Valiado(int total, int contabilizados)
        {
            return $"Essa é a porcentagem de votos validos: {CalcPorce(total, contabilizados)}%";
        }
        public string Brancos(int total, int contabilizados)
        {
            return $"Essa é a porcentagem de votos em branco: {CalcPorce(total, contabilizados)}%";
        }
        public string Nulos(int total, int contabilizados)
        {

            return $"Essa é a porcentagem de votos em nulos: {CalcPorce(total, contabilizados)}%";
        }



        private double CalcPorce(int total, int contabilizados)
        {

            return (contabilizados * 100) / total;

        }


        public void BubbleSort()
        {
            int[] v = { 5, 3, 2, 4, 7, 1, 0, 6 };

            int temp = 0;

            for (int write = 0; write < v.Length; write++)
            {
                for (int sort = 0; sort < v.Length - 1; sort++)
                {
                    if (v[sort] > v[sort + 1])
                    {
                        temp = v[sort + 1];
                        v[sort + 1] = v[sort];
                        v[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
        }
    }
}
