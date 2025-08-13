using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarEstadoCita : IRequestHandler<ComandoEditarFechaoCita, Unit>
{
    private readonly ICita _cita;

    public ManejadorEditarEstadoCita(ICita cita)
    {
        _cita = cita;
    }

    public async Task<Unit> Handle(ComandoEditarFechaoCita solicitud, CancellationToken token)
    {
        EntidadCita cita = new()
        {
            Id = solicitud.CitaId,
            Estado = solicitud.Informacion.Estado
        };

        await _cita.EditarEstadoCita(cita);

        return Unit.Value;
    }
}