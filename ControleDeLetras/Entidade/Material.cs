namespace ControleDeLetras.Entidade
{
    public class Material
    {
        public Material()
        {
            Id = int.MinValue;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
