using Moq;
using TurboCita.Api.Aplicacion.Consultas;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Api.Aplicacion.Manejadores;
using TurboCita.Dominio.Entidades;
using TurboCita.Infraestructura.Interfaces;

namespace TurboCita.Pruebas.manejadores;
public class PruebasManejadorConsultarClientePorIdentificacion
{
    private readonly Mock<IRepositorioCliente> _repositorioClienteSimulado;
    private readonly ManejadorConsultarClientePorIdentificacion _manejador;

    public PruebasManejadorConsultarClientePorIdentificacion()
    {
        _repositorioClienteSimulado = new Mock<IRepositorioCliente>();
        _manejador = new ManejadorConsultarClientePorIdentificacion(_repositorioClienteSimulado.Object);
    }

    [Fact]
    public async Task Manejar_DebeRetornarClienteDTO_CuandoExiste()
    {
        var solicitud = new ConsultarClientePorIdentificacion("CC", 99999);
        var entidad = new EntidadCliente
        {
            Id = 1,
            Nombres = "Luis",
            Apellidos = "Rojas",
            TipoDocumento = "CC",
            NumeroDocumento = "99999",
            Direccion = "Dir",
            CorreoElectronico = "luis@correo.com",
            Celular = "3000000000"
        };

        _repositorioClienteSimulado
            .Setup(r => r.ConsultarClientePorIdentificacion(solicitud.tipoDocumento, solicitud.numeroDocumento))
            .ReturnsAsync(entidad);

        ClienteDTO dto = await _manejador.Handle(solicitud, CancellationToken.None);

        Assert.Equal(entidad.Id, dto.Id);
        Assert.Equal(entidad.Nombres, dto.Nombres);
        _repositorioClienteSimulado.Verify(r => r.ConsultarClientePorIdentificacion("CC", 99999), Times.Once);
    }

    [Fact]
    public async Task Manejar_DebeLanzarExcepcion_SiRepositorioRetornaNull()
    {
        var solicitud = new ConsultarClientePorIdentificacion("CC", 111);

        _repositorioClienteSimulado
            .Setup(r => r.ConsultarClientePorIdentificacion(solicitud.tipoDocumento, solicitud.numeroDocumento))
            .ReturnsAsync((EntidadCliente)null);

        await Assert.ThrowsAsync<NullReferenceException>(() =>
            _manejador.Handle(solicitud, CancellationToken.None));
    }
}