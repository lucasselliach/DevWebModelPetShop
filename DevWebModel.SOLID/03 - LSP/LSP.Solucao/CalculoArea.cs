using System;

namespace DevWebModel.SOLID.LSP.Solucao
{
    public abstract class Paralelogramo
    {
        protected Paralelogramo(int altura, int largura)
        {
            Altura = altura;
            Largura = largura;
        }

        public double Altura { get; }
        public double Largura { get; }
        public double Area => Altura * Largura;
    }

    public class Retangulo : Paralelogramo
    {
        public Retangulo(int altura, int largura) : base(altura, largura)
        {
        }
    }

    public class Quadrado : Paralelogramo
    {
        public Quadrado(int altura, int largura) : base(altura, largura)
        {
            if (largura != altura) throw new ArgumentException("Os dois lados do quadrado precisam ser iguais");
        }
    }

    public class CalculoArea
    {
        private static double ObterAreaParalelogramo(Paralelogramo paralelogramo)
        {
            return paralelogramo.Area;
        }

        public static void CalcularExemplo()
        {
            var retangulo = new Retangulo(10,5);

            var retorno1 = ObterAreaParalelogramo(retangulo);
            //retorno1 = 50. Está certo.

            var quadrado1 = new Quadrado(10, 5);
            var retorno2 = ObterAreaParalelogramo(quadrado1);
            //retorno2 = ArgumentException(Os dois lados do quadrado precisam ser iguais).

            var quadrado2 = new Quadrado(5, 5);
            var retorno3 = ObterAreaParalelogramo(quadrado2);
            //retorno3 = 25. Está certo.
        }
    }
}
