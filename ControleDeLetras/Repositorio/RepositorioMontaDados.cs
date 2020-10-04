using ControleDeLetras.Entidade;

namespace ControleDeLetras.Repositorio
{
    public class RepositorioMontaDados
    {
        public RepositorioMontaDados()
        {
            VerificaInsereTodasAsLetras();
        }

        private void VerificaInsereTodasAsLetras()
        {
            MaterialRepositorio MaterialRepositorio = new MaterialRepositorio();
            Tipo_MaterialRepositorio Tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();

            if (Tipo_MaterialRepositorio.Obter().Count == 0)
            {
                Tipo_MaterialRepositorio.Inserir(new Tipo_Material()
                {
                    Descricao = "Letra",
                });
            }

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (MaterialRepositorio.Obter().Count == 0)
            {

                foreach (var letra in letras.ToCharArray())
                {
                    MaterialRepositorio.Inserir(new Material()
                    {
                        Descricao = letra.ToString(),
                        Tipo_Material_Id = 1,
                        Quantidade = 0
                    });
                }
            }
        }
    }
}
