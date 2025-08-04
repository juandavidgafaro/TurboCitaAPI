using TurboCita.Dominio.Entidades;

namespace TurboCita.Infraestructura.Entidades;
public class Cliente
{
    public Cliente()
    {
        
    }


    public static implicit operator EntidadCliente(Cliente entity)
    {
        EntidadCliente cliente = default;

        if (entity != default)
        {
            cliente = new(
  
            );
        }

        return cliente;
    }
}
