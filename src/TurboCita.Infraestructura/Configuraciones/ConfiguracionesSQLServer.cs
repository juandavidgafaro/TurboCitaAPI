namespace TurboCita.Infraestructura.Configuraciones;
public class ConfiguracionesSQLServer
{
    public required CadenaConexion CadenaConexion { get; set; }
}

public class CadenaConexion
{
    public required string TurboCitaServidorBD { get; set; }
}