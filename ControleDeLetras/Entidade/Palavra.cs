namespace ControleDeLetras.Entidade
{
    public class Palavra
    {
        public int Id { get; protected set; }
        public string Descricao { get; protected set; }

        public Palavra(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
