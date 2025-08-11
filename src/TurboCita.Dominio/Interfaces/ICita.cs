using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;
public interface ICita
{
    Task CrearCita(EntidadCita cita);
    Task EditarCita(EntidadCita cita);
    Task EliminarCita(int citaId);
}
