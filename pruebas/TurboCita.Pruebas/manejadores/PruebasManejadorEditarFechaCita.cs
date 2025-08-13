using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorEditarFechaCita
{
    private readonly Mock<ICita> _repositorioCitaSimulado;
    private readonly ManejadorEditarFechaCita _manejador;

    public PruebasManejadorEditarFechaCita()
    {
        _repositorioCitaSimulado = new Mock<ICita>();
        _manejador = new ManejadorEditarFechaCita(_repositorioCitaSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeEditarLaFecha_CuandoLosDatosSonValidos()
    {
        // Preparación
        var nuevaFecha = new DateTime(2025, 9, 5, 10, 30, 0);
        var solicitud = new ComandoEditarFechaCita
        {
            CitaId = 77,
            Informacion = new EditarFechaCitaDTO
            {
                FechaCita = nuevaFecha
            }
        };

        _repositorioCitaSimulado
            .Setup(r => r.EditarFechaCita(It.IsAny<EntidadCita>()))
            .Returns(Task.CompletedTask);

        // Ejecución
        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        // Verificación
        Assert.Equal(Unit.Value, resultado);
        _repositorioCitaSimulado.Verify(r => r.EditarFechaCita(It.Is<EntidadCita>(c =>
            c.Id == solicitud.CitaId &&
            c.FechaCita == nuevaFecha
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeLanzarExcepcion_CuandoLaInformacionEsNula()
    {
        // Preparación
        var solicitud = new ComandoEditarFechaCita
        {
            CitaId = 10,
            Informacion = null
        };

        // Nota: El handler actual no valida null, produciría NullReferenceException.
        // Si agregas validación deberías cambiar a Assert.ThrowsAsync<ArgumentNullException>.
        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioCitaSimulado.VerifyNoOtherCalls();
    }
}