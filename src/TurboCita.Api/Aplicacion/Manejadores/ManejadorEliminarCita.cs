using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEliminarCita : IRequestHandler<ComandoEliminarCita, Unit>
{
    private readonly ICita _cita;

    public ManejadorEliminarCita(ICita cita)
    {
        _cita = cita;
    }

    public async Task<Unit> Handle(ComandoEliminarCita solicitud, CancellationToken token)
    {
        await _cita.EliminarCita(solicitud.CitaId);

        return Unit.Value;
    }
}