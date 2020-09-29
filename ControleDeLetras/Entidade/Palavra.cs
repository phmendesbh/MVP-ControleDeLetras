namespace ControleDeLetras.Entidade
{
    public class Palavra
    {
        public int Id { get; protected set; }
        public string Descricao { get; protected set; }

        public string DescricaoAntiga { get; set; }

        public Palavra(int? id, string descricao)
        {
            Id = id == null? int.MinValue: id.Value;
            Descricao = descricao;
        }
    }
}
