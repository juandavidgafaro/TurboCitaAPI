using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorCrearCliente
{
    private readonly Mock<ICliente> _repositorioClienteSimulado;
    private readonly ManejadorCrearCliente _manejador;

    public PruebasManejadorCrearCliente()
    {
        _repositorioClienteSimulado = new Mock<ICliente>();
        _manejador = new ManejadorCrearCliente(_repositorioClienteSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeCrearElCliente_CuandoLosDatosSonValidos()
    {
        var solicitud = new ComandoCrearCliente
        {
            Informacion = new CrearClienteDTO
            {
                Nombres = "Ana",
                Apellidos = "Pérez",
                TipoDocumento = "CC",
                NumeroDocumento = "12345",
                Direccion = "Calle 1",
                CorreoElectronico = "ana@correo.com",
                Celular = "3001112233"
            }
        };

        _repositorioClienteSimulado
            .Setup(r => r.CrearCliente(It.IsAny<EntidadCliente>()))
            .Returns(Task.CompletedTask);

        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(Unit.Value, resultado);
        _repositorioClienteSimulado.Verify(r => r.CrearCliente(It.Is<EntidadCliente>(c =>
            c.Nombres == solicitud.Informacion.Nombres &&
            c.NumeroDocumento == solicitud.Informacion.NumeroDocumento &&
            c.CorreoElectronico == solicitud.Informacion.CorreoElectronico
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeFallar_SiInformacionEsNula()
    {
        var solicitud = new ComandoCrearCliente
        {
            Informacion = null
        };

        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioClienteSimulado.VerifyNoOtherCalls();
    }
}