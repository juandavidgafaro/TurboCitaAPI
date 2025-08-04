using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;
public interface ICliente
{
    Task CrearCliente(EntidadCliente client);
    Task<EntidadCliente> ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento);
}