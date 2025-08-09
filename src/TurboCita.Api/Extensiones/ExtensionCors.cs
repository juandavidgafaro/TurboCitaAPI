namespace TurboCita.Api.Extensiones;
public static class ExtensionCors
{
    public static IServiceCollection AgregarExtensionCors(this IServiceCollection servicios)
    {
        servicios.AddCors(options =>
        {
            options.AddPolicy("mycors",
            builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            }
            );
        }
        );
        return servicios;
    }
}