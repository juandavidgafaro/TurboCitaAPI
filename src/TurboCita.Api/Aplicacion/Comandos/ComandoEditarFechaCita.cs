using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEditarFechaCita : IRequest<Unit>
{
    public int CitaId { get; set; }
    public EditarFechaCitaDTO Informacion { get; set; }
}
