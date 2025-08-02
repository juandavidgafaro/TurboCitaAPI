using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoCrearCliente : IRequest<int>
{
    public CrearClienteDTO Body { get; set; }
}