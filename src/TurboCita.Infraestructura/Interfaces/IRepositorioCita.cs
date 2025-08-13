using TurboCita.Infraestructura.Entidades;

namespace TurboCita.Infraestructura.Interfaces;
public interface IRepositorioCita
{
    Task<IEnumerable<Cita>> ConsultarCitasPorCliente(int clienteId);
}
