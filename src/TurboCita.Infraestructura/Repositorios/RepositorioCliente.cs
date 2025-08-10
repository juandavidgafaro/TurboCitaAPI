using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Recursos;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCliente : SqlServerBase<Cliente>, ICliente
{
    public RepositorioCliente(IOptions<ConfiguracionesInfraestructura> configuraciones) 
        : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public Task<EntidadCliente> ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento)
    {
        throw new NotImplementedException();
    }

    public async Task CrearCliente(EntidadCliente cliente)
    {
        string sql = ProcesosSQL.CrearCliente;

        try
        {
            await InserccionUnitaria(sql, new
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

}
