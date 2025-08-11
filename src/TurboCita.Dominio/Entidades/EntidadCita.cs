namespace TurboCita.Dominio.Entidades;
public class EntidadCita
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VehiculoId { get; set; }
    public string Estado { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime FechaCita { get; set; } = DateTime.Now;
}
