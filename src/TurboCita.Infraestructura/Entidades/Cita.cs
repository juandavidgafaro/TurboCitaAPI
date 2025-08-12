using TurboCita.Dominio.Entidades;

namespace TurboCita.Infraestructura.Entidades;
public class Cita
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VehiculoId { get; set; }
    public string Estado { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime FechaCita { get; set; } = DateTime.Now;

    public static implicit operator EntidadCita(Cita cita)
    {
        EntidadCita entidadCita = default;

        if (cita != default)
        {
            entidadCita = new(

            );
        }

        return entidadCita;
    }
}
