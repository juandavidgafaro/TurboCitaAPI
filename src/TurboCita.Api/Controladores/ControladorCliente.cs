using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Modelos;

namespace TurboCita.Api.Controladores;

[ApiController]
[Route("[controller]")]
public class ControladorCliente : ControllerBase
{
    private readonly IMediator _mediator;

    public ControladorCliente(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CrearCliente([FromHeader] ModeloEncabezadoSolicitud datosCabecera, [FromBody] CrearClienteDTO cuerpo)
    {
        ComandoCrearCliente comandoCrearCliente = new()
        {
            Informacion = cuerpo
        };

        await _mediator.Send(comandoCrearCliente);

        return Ok();
    }

    [HttpGet("ConsultarClientePorIdentificacion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> ObtenerClientePorIdentificacion([FromHeader] ModeloEncabezadoSolicitud datosCabecer, [FromBody] CrearClienteDTO cuerpo)
    {
        ComandoCrearCliente comandoCrearCliente = new()
        {
            Informacion = cuerpo
        };

        await _mediator.Send(comandoCrearCliente);

        return Ok();
    }
}