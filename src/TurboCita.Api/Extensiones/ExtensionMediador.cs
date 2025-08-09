using System.Reflection;

namespace TurboCita.Api.Extensiones;
public static class ExtensionMediador
{
    public static IServiceCollection AgregarExtensionMediador(this IServiceCollection servicios)
    {
        servicios.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return servicios;
    }
}
