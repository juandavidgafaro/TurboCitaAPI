namespace TurboCita.Api.Aplicacion.DTOs;
public class ClienteDTO
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
    public string Direccion { get; set; }
    public string CorreoElectronico { get; set; }
    public string Celular { get; set; }
}
