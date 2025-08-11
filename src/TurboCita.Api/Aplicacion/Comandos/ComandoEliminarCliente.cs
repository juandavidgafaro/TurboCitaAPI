using MediatR;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEliminarCliente : IRequest<Unit>
{
    public int ClienteId { get; set; }
}
