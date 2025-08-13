using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;
public interface ICita
{
    Task CrearCita(EntidadCita cita);
    Task EditarEstadoCita(EntidadCita cita);
    Task EditarFechaCita(EntidadCita cita);
    Task EliminarCita(int citaId);
}
