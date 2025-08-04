using TurboCita.Dominio.Entidades;

namespace TurboCita.Infraestructura.Interfaces;

public interface IRepositorioCliente
{
    Task<EntidadCliente> CrearCliente(EntidadCliente client);
}
