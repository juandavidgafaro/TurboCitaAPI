using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorEditarEstadoCita
{
    private readonly Mock<ICita> _repositorioCitaSimulado;
    private readonly ManejadorEditarEstadoCita _manejador;

    public PruebasManejadorEditarEstadoCita()
    {
        _repositorioCitaSimulado = new Mock<ICita>();
        _manejador = new ManejadorEditarEstadoCita(_repositorioCitaSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeEditarElEstado_CuandoLosDatosSonValidos()
    {
        // Preparación
        // Asume que existe ComandoEditarEstadoCita con Informacion: EditarEstadoCitaDTO
        var solicitud = new ComandoEditarEstadoCita
        {
            CitaId = 55,
            Informacion = new EditarEstadoCitaDTO
            {
                Estado = "Confirmada"
            }
        };

        _repositorioCitaSimulado
            .Setup(r => r.EditarEstadoCita(It.IsAny<EntidadCita>()))
            .Returns(Task.CompletedTask);

        // Ejecución
        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        // Verificación
        Assert.Equal(Unit.Value, resultado);
        _repositorioCitaSimulado.Verify(r => r.EditarEstadoCita(It.Is<EntidadCita>(c =>
            c.Id == solicitud.CitaId &&
            c.Estado == solicitud.Informacion.Estado
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeLanzarExcepcion_CuandoLaInformacionEsNula()
    {
        var solicitud = new ComandoEditarEstadoCita
        {
            CitaId = 55,
            Informacion = null
        };

        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioCitaSimulado.VerifyNoOtherCalls();
    }
}