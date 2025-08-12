SELECT ClienteId AS Id, *
FROM Cliente
WHERE TipoDocumento = @tipoDocumento
  AND NumeroDocumento = @numeroDocumento;