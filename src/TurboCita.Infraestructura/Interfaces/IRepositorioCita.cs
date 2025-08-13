using TurboCita.Infraestructura.Entidades;

namespace TurboCita.Infraestructura.Interfaces;
public interface IRepositorioCita
{
    Task<IList<Cita>> ConsultarCitasPorCliente(int clienteId);
}
