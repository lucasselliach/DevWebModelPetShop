namespace DevWebModel.SOLID.OCP.Solucao
{
    //Nessa solução estamos usando herança para o principio OCP.
    //A ABSTRAÇÃO é uma alternativa pois assim tornamos o DebitoConta o mais reutilizavel o possivel.
    //Assim está separado as classe filhos, como por exemplo a DebitoContaCorrente tem as resposabilidades separadas da 
    //debitoEmContaPoupança, e se uma não funcionar, não afetará a outra. 
    //Porém o problema de utilizar essa solução é a quebra o SRP, já que se essa classe mudar, vai mudar todas as classes filhas,
    //ou seja, estamos corropendo as classe filhas usando herança.
    //Porém foi uma forma simples de exemplificar como utiliza OCP.
    //A forma mais correta seria usando injeção de depedencia. Que não será abordada aqui.

    public abstract class DebitoConta
    {
        public abstract void Debitar(decimal valor, string conta);
    }

    public class DebitoContaPoupanca : DebitoConta
    {
        public override void Debitar(decimal valor, string conta)
        {
            // Debita Conta Poupança
        }
    }

    public class DebitoContaCorrente : DebitoConta
    {
        public override void Debitar(decimal valor, string conta)
        {
            // Debita Conta Corrente
        }
    }
}
