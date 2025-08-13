using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorEliminarCita
{
    private readonly Mock<ICita> _repositorioCitaSimulado;
    private readonly ManejadorEliminarCita _manejador;

    public PruebasManejadorEliminarCita()
    {
        _repositorioCitaSimulado = new Mock<ICita>();
        _manejador = new ManejadorEliminarCita(_repositorioCitaSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeEliminarLaCita_CuandoElIdEsValido()
    {
        // Preparación
        var solicitud = new ComandoEliminarCita
        {
            CitaId = 99
        };

        _repositorioCitaSimulado
            .Setup(r => r.EliminarCita(solicitud.CitaId))
            .Returns(Task.CompletedTask);

        // Ejecución
        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        // Verificación
        Assert.Equal(Unit.Value, resultado);
        _repositorioCitaSimulado.Verify(r => r.EliminarCita(99), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebePermitirEliminarConIdCero_SiNoExisteValidacion()
    {
        var solicitud = new ComandoEliminarCita
        {
            CitaId = 0
        };

        _repositorioCitaSimulado
            .Setup(r => r.EliminarCita(0))
            .Returns(Task.CompletedTask);

        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(Unit.Value, resultado);
        _repositorioCitaSimulado.Verify(r => r.EliminarCita(0), Times.Once);
    }
}