using MediatR;
using Moq;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorEditarCliente
{
    private readonly Mock<ICliente> _repositorioClienteSimulado;
    private readonly ManejadorEditarCliente _manejador;

    public PruebasManejadorEditarCliente()
    {
        _repositorioClienteSimulado = new Mock<ICliente>();
        _manejador = new ManejadorEditarCliente(_repositorioClienteSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeEditarElCliente_CuandoLosDatosSonValidos()
    {
        var solicitud = new ComandoEditarCliente
        {
            ClienteId = 10,
            Informacion = new EditarClienteDTO
            {
                Direccion = "Nueva Dir",
                CorreoElectronico = "nuevo@correo.com",
                Celular = "3019998877"
            }
        };

        _repositorioClienteSimulado
            .Setup(r => r.EditarCliente(It.IsAny<EntidadCliente>()))
            .Returns(Task.CompletedTask);

        var resultado = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(Unit.Value, resultado);
        _repositorioClienteSimulado.Verify(r => r.EditarCliente(It.Is<EntidadCliente>(c =>
            c.Id == solicitud.ClienteId &&
            c.Direccion == solicitud.Informacion.Direccion &&
            c.CorreoElectronico == solicitud.Informacion.CorreoElectronico
        )), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeFallar_SiInformacionEsNula()
    {
        var solicitud = new ComandoEditarCliente
        {
            ClienteId = 10,
            Informacion = null
        };

        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));

        _repositorioClienteSimulado.VerifyNoOtherCalls();
    }
}