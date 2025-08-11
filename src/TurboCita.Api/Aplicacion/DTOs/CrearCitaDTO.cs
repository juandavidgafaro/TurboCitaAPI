namespace TurboCita.Api.Aplicacion.DTOs;

public class CrearCitaDTO
{
    public int ClienteId { get; set; }
    public int VehiculoId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaCita { get; set; }
}
