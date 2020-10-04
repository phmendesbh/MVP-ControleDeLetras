using System.Runtime.InteropServices;

namespace ControleDeLetras.Repositorio.Queries
{
    public class Material_Queries
    {
		public string SELECT_JOIN_TIPO_MATERIAL = @"SELECT	material.id, 
															material.descricao, 
															material.tipo_material_id, 
															tipo_material.descricao, 
															material.quantidade, 
															material.cor_id, 
															cor.descricao, 
															cor.valorARGB
													FROM material
													INNER JOIN tipo_material ON tipo_material.id = material.tipo_material_id
													INNER JOIN cor ON cor.id = material.cor_id";

	}
}
