using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorCrearCita : IRequestHandler<ComandoCrearCita, Unit>
{
    private readonly ICita _cita;

    public ManejadorCrearCita(ICita cita)
    {
        _cita = cita;
    }

    public async Task<Unit> Handle(ComandoCrearCita solicitud, CancellationToken token)
    {
        EntidadCita cita = new()
        {
            ClienteId = solicitud.Informacion.ClienteId,
            VehiculoId = solicitud.Informacion.VehiculoId,
            FechaRegistro = solicitud.Informacion.FechaRegistro,
            FechaCita = solicitud.Informacion.FechaCita
        };

        await _cita.CrearCita(cita);

        return Unit.Value;
    }
}
