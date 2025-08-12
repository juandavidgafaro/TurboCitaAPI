using TurboCita.Infraestructura.Entidades;

namespace TurboCita.Infraestructura.Interfaces;

public interface IRepositorioCliente
{
    Task<Cliente> ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento);
}
