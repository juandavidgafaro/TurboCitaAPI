using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoCrearCita : IRequest<Unit>
{
    public CrearCitaDTO Informacion { get; set; }
}