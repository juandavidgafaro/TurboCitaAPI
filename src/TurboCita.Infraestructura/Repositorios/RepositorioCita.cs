using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;
using TurboCita.Infraestructura.Recursos;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCita : SqlServerBase<Cita>, ICita, IRepositorioCita
{
    public RepositorioCita(IOptions<ConfiguracionesInfraestructura> configuraciones)
    : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public async Task<IEnumerable<Cita>> ConsultarCitasPorCliente(int clienteId)
    {
        string sql = ProcesosSQL.ObtenerCitasPorClienteId;

        try
        {
            IEnumerable<Cita> citas = await EjecutarProcesoAsincrono<Cita>(sql, clienteId);

            return citas;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar consultar las citas para el cliente con id: {clienteId}, detalle:{ex.Message}");
        }
    }

    public async Task CrearCita(EntidadCita cita)
    {
        string sql = ProcesosSQL.CrearCita;

        try
        {
            await InsercionUnitaria(sql, new
            {
                clienteId = cita.ClienteId,
                vehiculoId = cita.VehiculoId,
                estado = cita.Estado,
                fechaCita = cita.FechaCita
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar crear la cita para el cliente con id: {cita.ClienteId}, detalle:{ex.Message}");
        }
    }

    public async Task EditarEstadoCita(EntidadCita cita)
    {
        string sql = ProcesosSQL.EditarEstadoCita;

        try
        {
           await EjecutarProcesoAsincrono(sql,
                new
                {
                    estado = cita.Estado,
                    citaId = cita.Id
                }
            );

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar editar el estado de la cita con id: {cita.Id}, detalle:{ex.Message}");
        }
    }

    public async Task EditarFechaCita(EntidadCita cita)
    {
        string sql = ProcesosSQL.EditarFechaCita;

        try
        {
            await EjecutarProcesoAsincrono(sql,
                 new
                 {
                     fechaCita = cita.Estado,
                     citaId = cita.Id
                 }
             );

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar editar la fechaCita de la cita con id: {cita.Id}, detalle:{ex.Message}");
        }
    }

    public async Task EliminarCita(int citaId)
    {
        string sql = ProcesosSQL.EliminarCita;

        try
        {
            await EjecutarProcesoAsincrono(sql,
                 new
                 {
                     citaId
                 }
             );

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar eliminar la cita con id: {citaId}, detalle:{ex.Message}");
        }
    }
}
