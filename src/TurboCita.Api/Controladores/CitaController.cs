using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Modelos;

namespace TurboCita.Api.Controladores;

[ApiController]
[Route("[controller]")]
public class CitaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CrearCita([FromHeader] ModeloEncabezadoSolicitud datosCabecera, [FromBody] CrearCitaDTO datosCita)
    {
        ComandoCrearCita comandoCrearCita = new()
        {
            Informacion = datosCita
        };

        await _mediator.Send(comandoCrearCita);

        return Ok();
    }

    [HttpPatch("{citaId}/Editar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ActualizarCita(int citaId, [FromHeader] ModeloEncabezadoSolicitud datosCabecera, [FromBody] EditarCitaDTO datosCita)
    {
        ComandoEditarCita comandoEditarCita = new ComandoEditarCita()
        {
            CitaId = citaId,
            Informacion = datosCita
        };

        await _mediator.Send(comandoEditarCita);

        return Ok();
    }

    [HttpDelete("{citaId}/Eliminar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ActualizarCita(int citaId, [FromHeader] ModeloEncabezadoSolicitud datosCabecera)
    {
        ComandoEditarCita comandoEditarCita = new ComandoEditarCita()
        {
            CitaId = citaId,
            Informacion = datosCita
        };

        await _mediator.Send(comandoEditarCita);

        return Ok();
    }
}