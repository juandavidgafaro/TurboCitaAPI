using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Recursos;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioVehiculo : SqlServerBase<Vehiculo>, IVehiculo
{
    public RepositorioVehiculo(IOptions<ConfiguracionesInfraestructura> configuraciones)
    : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public async Task CrearVehiculo(EntidadVehiculo vehiculo)
    {
        string sql = ProcesosSQL.CrearVehiculo;

        try
        {
            await InsercionUnitaria(sql, new
            {
                vehiculo.ClienteId,
                vehiculo.TipoVehiculo,
                vehiculo.Placa
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al intentar crear el vehiculo con placa: {vehiculo.Placa}, detalle:{ex.Message}");
        }
    }
}
