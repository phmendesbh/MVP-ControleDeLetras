SELECT	material.id, 
		material.descricao, 
		material.tipo_material_id, 
		tipo_material.descricao, 
		material.cor_id, 
		cor.descricao, 
		cor.valorARGB,
		material.quantidade
FROM material
	INNER JOIN tipo_material ON tipo_material.id = material.tipo_material_id
	INNER JOIN cor ON cor.id = material.cor_id