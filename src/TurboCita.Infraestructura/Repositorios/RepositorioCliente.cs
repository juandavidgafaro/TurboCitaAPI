using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;
using TurboCita.Infraestructura.Recursos;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCliente : SqlServerBase<Cliente>, ICliente, IRepositorioCliente
{
    public RepositorioCliente(IOptions<ConfiguracionesInfraestructura> configuraciones) 
        : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public async Task<Cliente> ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento)
    {
        string sql = ProcesosSQL.ObtenerClientePorIdentificacion;

        try
        {
            Cliente client = await EjecutarProcesoAsincrono(sql, new { tipoDocumento, numeroDocumento });

            return client;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar obtener el cliente con tipo de documento: {tipoDocumento} y numero {numeroDocumento}, detalle:{ex.Message}");
        }
    }

    public async Task CrearCliente(EntidadCliente cliente)
    {
        string sql = ProcesosSQL.CrearCliente;

        try
        {
            await InsercionUnitaria(sql, new
            {
                cliente.Nombres,
                cliente.Apellidos,
                cliente.TipoDocumento,
                cliente.NumeroDocumento,
                cliente.Direccion,
                cliente.CorreoElectronico,
                cliente.Celular
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar crear el cliente con numero de identificación: {cliente.NumeroDocumento}, detalle:{ex.Message}");
        }
    }

    public async Task EditarCliente(EntidadCliente cliente)
    {
        string sql = ProcesosSQL.EditarCliente;

        try
        {
            Cliente client = await EjecutarProcesoAsincrono(sql, 
                new
                {
                    clienteId = cliente.Id,
                    direccion = cliente.Direccion,
                    correoElectronico = cliente.CorreoElectronico,
                    celular = cliente.Celular
                }
            );

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar editar el cliente con id: {cliente.Id}, detalle:{ex.Message}");
        }
    }

    public async Task EliminarCliente(int clienteId)
    {
        string sql = ProcesosSQL.EliminarCliente;

        try
        {
            Cliente client = await EjecutarProcesoAsincrono(sql, new { clienteId });

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar eliminar el cliente con id: {clienteId}, detalle:{ex.Message}");
        }
    }
}
