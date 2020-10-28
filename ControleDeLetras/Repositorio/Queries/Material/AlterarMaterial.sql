UPDATE material 
SET descricao = @descricao, 
	tipo_material_id = @tipo_material_id, 
	cor_id = @cor_id, 
	quantidade = @quantidade 
WHERE id = @id