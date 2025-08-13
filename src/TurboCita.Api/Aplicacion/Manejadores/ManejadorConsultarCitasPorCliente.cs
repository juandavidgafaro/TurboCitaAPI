using MediatR;
using TurboCita.Api.Aplicacion.Consultas;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorConsultarCitasPorCliente : IRequestHandler<ConsultarCitasPorCliente, IEnumerable<CitaDTO>>
{
    private readonly IRepositorioCita _repositorioCita;

    public ManejadorConsultarCitasPorCliente(IRepositorioCita repositorioCita)
    {
        _repositorioCita = repositorioCita;
    }

    public  async Task<IEnumerable<CitaDTO>> Handle(ConsultarCitasPorCliente solictud, CancellationToken token)
    {
        IEnumerable<Cita> citas = await _repositorioCita.ConsultarCitasPorCliente(solictud.clienteId);

        return citas.Select(c => new CitaDTO
        {
            Id = c.Id,
            VehiculoId = c.VehiculoId,
            ClienteId = c.ClienteId,
            FechaRegistro = c.FechaRegistro,
            FechaCita = c.FechaCita,
            Estado = c.Estado
        }).ToList();
    }
}
