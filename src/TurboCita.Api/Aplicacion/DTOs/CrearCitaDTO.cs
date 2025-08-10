namespace TurboCita.Api.Aplicacion.DTOs;

public class CrearCitaDTO
{
    public int ClienteId { get; set; }
    public int VehiculoId { get; set; }
    public string FechaRegistro { get; set; }
    public string FechaCita { get; set; }
}
