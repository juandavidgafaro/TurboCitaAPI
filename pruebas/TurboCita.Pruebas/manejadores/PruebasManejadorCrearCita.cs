using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorCrearCita
{
    private readonly Mock<ICita> _repositorioCitaSimulado;
    private readonly ManejadorCrearCita _manejador;

    public PruebasManejadorCrearCita()
    {
        _repositorioCitaSimulado = new Mock<ICita>();
        _manejador = new ManejadorCrearCita(_repositorioCitaSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeCrearLaCita_CuandoLosDatosSonValidos()
    {
        // Preparación
        var solicitud = new ComandoCrearCita
        {
            Informacion = new CrearCitaDTO
            {
                ClienteId = 1,
                VehiculoId = 10,
                FechaRegistro = new DateTime(2025, 8, 12, 9, 0, 0),
                FechaCita = new DateTime(2025, 8, 20, 14, 0, 0)
            }
        };

        _repositorioCitaSimulado
            .Setup(repo => repo.CrearCita(It.IsAny<EntidadCita>()))
            .Returns(Task.CompletedTask);

        // Ejecución
        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        // Verificación
        Assert.Equal(Unit.Value, resultado);
        _repositorioCitaSimulado.Verify(repo => repo.CrearCita(It.Is<EntidadCita>(c =>
            c.ClienteId == solicitud.Informacion.ClienteId &&
            c.VehiculoId == solicitud.Informacion.VehiculoId &&
            c.FechaRegistro == solicitud.Informacion.FechaRegistro &&
            c.FechaCita == solicitud.Informacion.FechaCita
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeLanzarExcepcion_CuandoLaInformacionEsNula()
    {
        // Preparación
        var solicitud = new ComandoCrearCita
        {
            Informacion = null
        };

        // Ejecución y Verificación
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioCitaSimulado.VerifyNoOtherCalls();
    }
}
