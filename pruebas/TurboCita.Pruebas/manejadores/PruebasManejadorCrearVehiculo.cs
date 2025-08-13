using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorCrearVehiculo
{
    private readonly Mock<IVehiculo> _repositorioVehiculoSimulado;
    private readonly ManejadorCrearVehiculo _manejador;

    public PruebasManejadorCrearVehiculo()
    {
        _repositorioVehiculoSimulado = new Mock<IVehiculo>();
        _manejador = new ManejadorCrearVehiculo(_repositorioVehiculoSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeCrearVehiculo_CuandoDatosValidos()
    {
        var solicitud = new ComandoCrearVehiculo
        {
            Informacion = new CrearVehiculoDTO
            {
                ClienteId = 5,
                TipoVehiculo = "Carro",
                Placa = "ABC123"
            }
        };

        _repositorioVehiculoSimulado
            .Setup(r => r.CrearVehiculo(It.IsAny<EntidadVehiculo>()))
            .Returns(Task.CompletedTask);

        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(Unit.Value, resultado);
        _repositorioVehiculoSimulado.Verify(r => r.CrearVehiculo(It.Is<EntidadVehiculo>(v =>
            v.ClienteId == solicitud.Informacion.ClienteId &&
            v.Placa == solicitud.Informacion.Placa
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeFallar_SiInformacionEsNula()
    {
        var solicitud = new ComandoCrearVehiculo
        {
            Informacion = null
        };

        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioVehiculoSimulado.VerifyNoOtherCalls();
    }
}