using TurboCita.Dominio.Entidades;

namespace TurboCita.Dominio.Interfaces;

public interface IVehiculo
{
    Task CrearVehiculo(EntidadVehiculo vehiculo);
}