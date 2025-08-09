INSERT INTO Cliente (
    Nombres,
    Apellidos,
    TipoDocumento,
    NumeroDocumento,
    Direccion,
    CorreoElectronico,
    Celular
)
VALUES (
    @Nombres,
    @Apellidos,
    @TipoDocumento,
    @NumeroDocumento,
    @Direccion,
    @CorreoElectronico,
    @Celular
);
