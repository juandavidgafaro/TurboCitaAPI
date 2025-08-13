UPDATE Cliente
SET 
    Direccion = @direccion,
    CorreoElectronico = @correoElectronico,
    Celular = @celular
WHERE ClienteId = @clienteId;