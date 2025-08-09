using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Modelos;

namespace TurboCita.Api.Controladores;

[ApiController]
[Route("[controller]")]
public class VehiculoControlleer : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiculoControlleer(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CrearCliente([FromHeader] ModeloEncabezadoSolicitud datosCabecera, [FromBody] CrearVehiculoDTO datosVehiculo)
    {
        ComandoCrearVehiculo comandoCrearVehiculo = new()
        {
            Informacion = datosVehiculo
        };

        await _mediator.Send(comandoCrearVehiculo);

        return Ok();
    }
}