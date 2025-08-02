namespace TurboCita.Api.Aplicacion.DTOs;

public class CrearClienteDTO
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
    public string Direccion { get; set; }
    public string Sexo { get; set; }
    public string CorreoElectronico { get; set; }
    public string Celular { get; set; }
}
