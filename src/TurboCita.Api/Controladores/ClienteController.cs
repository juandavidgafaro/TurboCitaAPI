using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.Consultas;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Modelos;

namespace TurboCita.Api.Controladores;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CrearCliente([FromHeader] ModeloEncabezadoSolicitud datosCabecera, [FromBody] CrearClienteDTO datosCliente)
    {
        ComandoCrearCliente comandoCrearCliente = new()
        {
            Informacion = datosCliente
        };

        await _mediator.Send(comandoCrearCliente);

        return Ok();
    }

    [HttpGet("ConsultarClientePorIdentificacion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClienteDTO>> ObtenerClientePorIdentificacion([FromHeader] ModeloEncabezadoSolicitud datosCabecer, [FromBody] ConsultarClientePorIdentificacion datosConsulta)
    {
        ClienteDTO cliente = await _mediator.Send(datosConsulta);

        return Ok(cliente);
    }
}