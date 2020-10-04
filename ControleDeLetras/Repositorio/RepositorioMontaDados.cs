using ControleDeLetras.Entidade;

namespace ControleDeLetras.Repositorio
{
    public class RepositorioMontaDados
    {
        public RepositorioMontaDados()
        {
            VerificaInsereCores();
            VerificaInsereTipo_Material();
            VerificaInsereTodasAsLetras();
        }

        private void VerificaInsereCores()
        {
            CorRepositorio CorRepositorio = new CorRepositorio();

            if (CorRepositorio.Obter().Count == 0)
            {
                CorRepositorio.Inserir(new Cor() {Descricao = "Ouro Velho", ValorARBG = -8372224});
                CorRepositorio.Inserir(new Cor() {Descricao = "Dourado", ValorARBG = -8355840});
                CorRepositorio.Inserir(new Cor() {Descricao = "Prata", ValorARBG = -4144960});
                CorRepositorio.Inserir(new Cor() {Descricao = "Grafite", ValorARBG = -8355712});
            }
        }

        private void VerificaInsereTipo_Material()
        {
            Tipo_MaterialRepositorio Tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();

            if (Tipo_MaterialRepositorio.Obter().Count == 0)
            {
                Tipo_MaterialRepositorio.Inserir(new Tipo_Material()
                {
                    Descricao = "Letra"
                });
            }
        }

        private void VerificaInsereTodasAsLetras()
        {
            MaterialRepositorio MaterialRepositorio = new MaterialRepositorio();

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (MaterialRepositorio.ObterTodasInformacoes().Count == 0)
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
