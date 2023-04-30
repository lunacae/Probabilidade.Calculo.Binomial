using Probabilidade.Calculo.Binomial.Models;

namespace Probabilidade.Calculo.Binomial.Services
{
    public class CalculoBinomialService : ICalculoBinomialService
    {
        //Função recursiva para calcular fatorial de um número N
        private int GetFatorial(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            else
                return n * GetFatorial(n - 1);
        }

        //Calcula uma combinação de dois números (Cn,x)
        private double GetCombinacao(int n, int x)
        {
            int dividendo = GetFatorial(n);
            int divisor = GetFatorial(x) * GetFatorial(n - x);
            return dividendo / divisor;
        }

        //Calcula a fórmula de binomial e retorna o valor
        /*
        n = Número total de observações
        x = Número de sucessos
        p = Probabilidade de sucesso
        */
        public double GetBinomial(int n, int x, double p)
        {
            double combinacao = GetCombinacao(n, x);
            return combinacao * Math.Pow(p, x) * Math.Pow(1 - p, n - x);
        }

        //Calcula o acumulado da fórmula de binomial
        public double GetAcumulada(int n, int x, double p)
        {
            double acumula = 0;
            for (int i = 0; i <= x; i++)
                acumula += GetBinomial(n, i, p);

            return acumula;
        }

        public BinomialRetorno GetResultado(int n, int x, double p)
        {
            BinomialRetorno resultado = new();
            resultado.BinomialIndividual = GetBinomial(n, x, p);
            resultado.BinomialAcumulada = GetAcumulada(n, x, p);
            return resultado;
        }

    }
}
