using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCita : SqlServerBase<Cliente>, ICita
{
    public RepositorioCita(IOptions<ConfiguracionesInfraestructura> configuraciones)
    : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public Task CrearCita(EntidadCita cita)
    {
        throw new NotImplementedException();
    }

    public Task EditarCita(EntidadCita cita)
    {
        throw new NotImplementedException();
    }

    public Task EliminarCita(int citaId)
    {
        throw new NotImplementedException();
    }
}
