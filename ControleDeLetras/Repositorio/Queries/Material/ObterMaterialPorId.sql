SELECT id, 
	descricao, 
	tipo_material_id, 
	cor_id, 
	quantidade 
FROM material 
WHERE id = @id