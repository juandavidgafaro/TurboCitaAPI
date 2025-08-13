using Microsoft.Extensions.Options;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCita : SqlServerBase<Cliente>, ICita, IRepositorioCita
{
    public RepositorioCita(IOptions<ConfiguracionesInfraestructura> configuraciones)
    : base(configuraciones.Value.ConfiguracionesSQLServer.CadenaConexion.TurboCitaServidorBD)
    {
    }

    public Task<IList<Cita>> ConsultarCitasPorCliente(int clienteId)
    {
        throw new NotImplementedException();
    }

    public Task CrearCita(EntidadCita cita)
    {
        throw new NotImplementedException();
    }

    public Task EditarEstadoCita(EntidadCita cita)
    {
        throw new NotImplementedException();
    }

    public Task EditarFechaCita(EntidadCita cita)
    {
        throw new NotImplementedException();
    }

    public Task EliminarCita(int citaId)
    {
        throw new NotImplementedException();
    }
}
