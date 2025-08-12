using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;
public interface ICliente
{
    Task CrearCliente(EntidadCliente cliente);
    Task EditarCliente(EntidadCliente cliente);
    Task EliminarCliente(int clienteId);
}