using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Entidades;
using TurboCita.Infraestructura.Interfaces;
using TurboCita.Infraestructura.Repositorios.Base.SQLServer;

namespace TurboCita.Infraestructura.Repositorios;
public class RepositorioCliente : SqlServerBase<Cliente>, ICliente
{
    public RepositorioCliente(string connectionString) : base(connectionString)
    {
    }

    public async Task<EntidadCliente> CrearCliente(EntidadCliente client)
    {
        string sql = sqlstatements.insert_client;

        try
        {
            ClientEntity insertionResult = await SingleInsert<ClientEntity>(sql, new
            {
                client.Name,
                client.IdentificationNumber,
                client.IdentificationType,
                PersonType = client.PersonType.Name,
                Country = client.Country.Name,
                LegalRepresentativeId = client.LegalRepresentative?.Id
            });

            return insertionResult;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar crear el cliente con numero de identificación: {client.IdentificationNumber}, detalle:{ex.Message}");
        }
    }

}
