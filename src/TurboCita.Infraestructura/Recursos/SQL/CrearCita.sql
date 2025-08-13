INSERT INTO Cita (
    ClienteId,
    VehiculoId,
    Estado,
    FechaCita
)
VALUES (
    @clienteId,
    @vehiculoId,
    @estado,
    @fechaCita
);