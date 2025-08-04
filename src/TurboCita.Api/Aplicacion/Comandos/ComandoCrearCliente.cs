using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoCrearCliente : IRequest<Unit>
{
    public CrearClienteDTO Informacion { get; set; }
}