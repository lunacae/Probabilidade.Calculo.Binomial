using Probabilidade.Calculo.Binomial.Models;

namespace Probabilidade.Calculo.Binomial.Services
{
    public interface ICalculoBinomialService
    {
        double GetAcumulada(int n, int x, double p);
        double GetBinomial(int n, int x, double p);
        BinomialRetorno GetResultado(int n, int x, double p);
    }
}