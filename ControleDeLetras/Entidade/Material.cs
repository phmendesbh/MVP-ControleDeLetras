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
        public int Tipo_Material_Id { get; set; }
        public string Tipo_Material_Descricao { get; set; }
        public int Quantidade { get; set; }
        public int Cor_Id { get; set; }
        public string Cor_Descricao { get; set; }
        public int Cor_ValorARGB { get; set; }
    }
}
