using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEditarCita : IRequest<Unit>
{
    public int CitaId { get; set; }
    public EditarCitaDTO Informacion { get; set; }
}
