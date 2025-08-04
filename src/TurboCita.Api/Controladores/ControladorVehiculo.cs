using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Modelos;

namespace TurboCita.Api.Controladores;

[ApiController]
[Route("[controller]")]
public class ControladorVehiculo : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ControladorVehiculo> _logger;

    public ControladorVehiculo(ILogger<ControladorVehiculo> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CrearCliente([FromHeader] ModeloEncabezadoSolicitud header, [FromBody] CrearClienteDTO boby)
    {
        ComandoCrearCliente createClientCommand = new()
        {
            Informacion = boby
        };

        int clienteId = await _mediator.Send(createClientCommand);

        return Ok(clienteId);
    }
}