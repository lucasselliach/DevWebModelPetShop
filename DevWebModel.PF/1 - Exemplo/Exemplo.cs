using System;

namespace DevWebModel.PF
{
    public class ExemploKissYagniDry
    {
        public string DiaDaSemanaCerto(int dia)
        {
            switch (dia)
            {
                case 1:
                    return "Segunda-Feira";
                case 2:
                    return "Terça-Feira";
                case 3:
                    return "Quarta-Feira";
                case 4:
                    return "Quinta-Feira";
                case 5:
                    return "Sexta-Feira";
                case 6:
                    return "Sabado";
                case 7:
                    return "Domingo";
                default:
                    throw new InvalidOperationException("O dia deve ser entre 1 e 7.");
            }
        }

        public string DiaDaSemanaErrado(int dia)
        {
            if ((dia < 1) || (dia > 7)) throw new InvalidOperationException("O dia deve ser entre 1 e 7.");
            string[] dias = {
                "Segunda-Feira",
                "Terça-Feira",
                "Quarta-Feira",
                "Quinta-Feira",
                "Sexta-Feira",
                "Sabado",
                "Domingo"
            };
            return dias[dia - 1];
        }
    }
}
