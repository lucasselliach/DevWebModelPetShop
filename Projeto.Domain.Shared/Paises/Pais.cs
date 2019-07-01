using System;

namespace Projeto.Domain.Shared.Paises
{
    public class Pais
    {
        public Guid Codigo { get; }
        public string Nome { get; }
        public string Idioma { get; }

        public Pais(string nome, string idioma)
        {
            Codigo = Guid.NewGuid();
            Nome = nome;
            Idioma = idioma;
        }
    }
}
