using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarFechaCita : IRequestHandler<ComandoEditarFechaCita, Unit>
{
    private readonly ICita _cita;

    public ManejadorEditarFechaCita(ICita cita)
    {
        _cita = cita;
    }

    public async Task<Unit> Handle(ComandoEditarFechaCita solicitud, CancellationToken token)
    {
        EntidadCita cita = new EntidadCita
        {
            Id = solicitud.CitaId,
            FechaCita = solicitud.Informacion.FechaCita,
        };

        await _cita.EditarFechaCita(cita);
        return Unit.Value;
    }
}