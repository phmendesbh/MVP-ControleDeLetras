UPDATE material 
SET quantidade = quantidade + @quantidade 
WHERE id = @id