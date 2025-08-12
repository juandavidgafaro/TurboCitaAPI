using TurboCita.Dominio.Entidades;

namespace TurboCita.Infraestructura.Entidades;
public class Cliente
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
    public string Direccion { get; set; }
    public string CorreoElectronico { get; set; }
    public string Celular { get; set; }


    public static implicit operator EntidadCliente(Cliente cliente)
    {
        EntidadCliente entidadCliente = default;

        if (cliente != default)
        {
            entidadCliente = new()
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                TipoDocumento = cliente.TipoDocumento,
                NumeroDocumento = cliente.NumeroDocumento,
                Direccion = cliente.Direccion,
                CorreoElectronico = cliente.CorreoElectronico,
                Celular = cliente.Celular
            };
        }

        return entidadCliente;
    }
}
