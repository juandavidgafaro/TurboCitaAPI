SELECT 
    CitaId AS Id,
    ClienteId,
    VehiculoId,
    Estado,
    FechaRegistro,
    FechaCita
FROM Cita
WHERE ClienteId = @ClienteId;