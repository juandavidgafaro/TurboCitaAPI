using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarCita : IRequestHandler<ComandoEditarCita, Unit>
{
    private readonly ICita _cita;

    public ManejadorEditarCita(ICita cita)
    {
        _cita = cita;
    }

    public async Task<Unit> Handle(ComandoEditarCita solicitud, CancellationToken token)
    {
        EntidadCita cita = new()
        {
            Id = solicitud.CitaId,
            FechaCita = solicitud.Informacion.FechaCita
        };

        await _cita.EditarCita(cita);

        return Unit.Value;
    }
}