using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeLetras.Util
{
    public class Enumeradores
    {
        public enum Operacao
        {
            Negativo = -1,
            Zero = 0,
            Positivo = 1
        }

        public enum Acao
        {
            Default,
            Novo,
            Alterar,
            Apagar,
            Salvar,
            Cancelar
        }
    }

    public class Utils
    {
        public IDictionary<string, int> CalculaQtdeLetras(List<string> lstPalavras)
        {
            IDictionary<string, int> letrasQtde = new Dictionary<string, int>();

            lstPalavras.ForEach(palavra =>
            {
                var letras = palavra.ToUpper().ToCharArray();
                foreach (var letra in letras)
                {
                    if (letrasQtde.ContainsKey(letra.ToString()))
                    {
                        letrasQtde[letra.ToString()] = letrasQtde[letra.ToString()] + 1;
                    }
                    else
                    {
                        letrasQtde.Add(letra.ToString(), 1);
                    }
                }
            });

            return new SortedDictionary<string, int>(letrasQtde);
        }
    }
}