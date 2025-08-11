using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEditarCliente : IRequest<Unit>
{
    public int ClienteId { get; set; }
    public EditarClienteDTO Informacion { get; set; }
}
