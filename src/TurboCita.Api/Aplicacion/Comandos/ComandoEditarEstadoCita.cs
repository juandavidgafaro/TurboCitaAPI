using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEditarFechaoCita : IRequest<Unit>
{
    public int CitaId { get; set; }
    public EditarEstadoCitaDTO Informacion { get; set; }
}
