DELETE FROM Vehiculo
WHERE ClienteId = @clienteId;

DELETE FROM Cliente
WHERE ClienteId = @clienteId;