using MediatR;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEliminarCita : IRequest<Unit>
{
    public int CitaId { get; set; }
}
