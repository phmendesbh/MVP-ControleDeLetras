CREATE TABLE IF NOT EXISTS material
	(id INTEGER PRIMARY KEY, 
	descricao VARCHAR(30), 
	tipo_material_id INTEGER, 
	cor_id INTEGER, 
	quantidade INTEGER, 

	FOREIGN KEY(tipo_material_id) 
	REFERENCES tipo_material(id), 
	FOREIGN KEY(cor_id) REFERENCES cor(id))