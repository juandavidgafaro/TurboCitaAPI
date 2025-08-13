INSERT INTO Cita (
    ClienteId,
    VehiculoId,
    Estado,
    FechaCita
)
VALUES (
    @ClienteId,
    @VehiculoId,
    @Estado,
    @FechaCita
);