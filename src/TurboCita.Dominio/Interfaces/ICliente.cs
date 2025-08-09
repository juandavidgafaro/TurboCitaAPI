using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;
public interface ICliente
{
    Task CrearCliente(EntidadCliente cliente);
    Task<EntidadCliente> ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento);
}