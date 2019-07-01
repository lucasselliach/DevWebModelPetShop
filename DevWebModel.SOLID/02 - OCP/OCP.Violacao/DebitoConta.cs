namespace DevWebModel.SOLID.OCP.Violacao
{
    //Nessa violação estamos utilizando uma classe debitar com IF para verificar o tipo de debito em cada conta. 
    //O problema é que se der problema em um dos if, toda a classe vai parar de funcionar.

    public enum TipoConta
    {
        Corrente,
        Poupanca
    }

    public class DebitoConta
    {
        public void Debitar(decimal valor, string conta, TipoConta tipoConta)
        {
            if (tipoConta == TipoConta.Corrente)
            {
                // Debita Conta Corrente
            }

            if (tipoConta == TipoConta.Poupanca)
            {
                // Debita Conta Poupança
            }
        }
    }
}
