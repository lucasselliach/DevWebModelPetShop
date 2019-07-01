namespace DevWebModel.SOLID.LSP.Violacao
{
    public class Retangulo
    {
        public virtual double Altura { get; set; }
        public virtual double Largura { get; set; }
        public double Area => Altura * Largura;
    }

    public class Quadrado : Retangulo
    {
        public override double Altura
        {
            set => base.Altura = base.Largura = value;
        }

        public override double Largura
        {
            set => base.Altura = base.Largura = value;
        }
    }

    public class CalculoArea
    {
        private static double ObterAreaRetangulo(Retangulo retangulo)
        {
            return retangulo.Area;
        }

        public static void CalcularExemplo()
        {
            var retangulo = new Retangulo()
            {
                Altura = 10,
                Largura = 5
            };

            var retorno1 = ObterAreaRetangulo(retangulo);
            //retorno1 = 50. Está certo.

            var quadrado = new Quadrado()
            {
                Altura = 10,
                Largura = 5
            };

            var retorno2 = ObterAreaRetangulo(quadrado);
            //retorno2 = 25. Está certo para quadrado.
            //Mas como estamos procurando a area do retangulo no método ObterAreaRetangulo(quadrado) o certo seria
            //retorno2 = 50.
            //Assim podemos verificar que um quadrado não pode herda de retangulo. 
        }
    }
}
