using Moq;
using TurboCita.Api.Aplicacion.Consultas;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorConsultarCitasPorCliente
{
    private readonly Mock<IRepositorioCita> _repositorioCitaSimulado;
    private readonly ManejadorConsultarCitasPorCliente _manejador;

    public PruebasManejadorConsultarCitasPorCliente()
    {
        _repositorioCitaSimulado = new Mock<IRepositorioCita>();
        _manejador = new ManejadorConsultarCitasPorCliente(_repositorioCitaSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeRetornarListadoDeCitas_CuandoExisten()
    {
        var solicitud = new ConsultarCitasPorCliente(7);
        var citas = new List<Cita>
        {
            new Cita { Id = 1, ClienteId = 7, VehiculoId = 20, FechaRegistro = DateTime.UtcNow.AddDays(-2), FechaCita = DateTime.UtcNow.AddDays(5), Estado = "Pendiente" },
            new Cita { Id = 2, ClienteId = 7, VehiculoId = 21, FechaRegistro = DateTime.UtcNow.AddDays(-1), FechaCita = DateTime.UtcNow.AddDays(10), Estado = "Pendiente" }
        };

        _repositorioCitaSimulado
            .Setup(r => r.ConsultarCitasPorCliente(solicitud.clienteId))
            .ReturnsAsync(citas);

        IEnumerable<CitaDTO> resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(2, resultado.Count());
        Assert.All(resultado, c => Assert.Equal(7, c.ClienteId));
        _repositorioCitaSimulado.Verify(r => r.ConsultarCitasPorCliente(7), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeRetornarListaVacia_CuandoNoHayCitas()
    {
        var solicitud = new ConsultarCitasPorCliente(50);

        _repositorioCitaSimulado
            .Setup(r => r.ConsultarCitasPorCliente(solicitud.clienteId))
            .ReturnsAsync(new List<Cita>());

        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Empty(resultado);
    }
}