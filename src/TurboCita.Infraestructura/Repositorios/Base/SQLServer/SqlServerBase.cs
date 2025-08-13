using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TurboCita.Infraestructura.Repositorios.Base.SQLServer;

public class SqlServerBase<T> where T : class
{
    public required string _cadenaConexion;
    public SqlServerBase(string connectionString)
    {
        _cadenaConexion = connectionString;
    }

    public async Task<int> InsercionUnitaria(string sql, object parametros)
    {
        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            var idInsertado = await conexion.ExecuteScalarAsync<int>(sql, parametros);
            return idInsertado;
        }
    }

    public async Task<T> InsertarUno<T>(string sql, object parametros)
    {
        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            var entidadInsertada = await conexion.QuerySingleAsync<T>(sql, parametros);
            return entidadInsertada;
        }
    }

    public async Task<int> ActualizarUno(string sql, object parametros)
    {
        int filasAfectadas;
        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            conexion.Open();
            filasAfectadas = await conexion.ExecuteAsync(sql, parametros, commandTimeout: 120);
            conexion.Close();
        }
        return filasAfectadas;
    }

    public async Task<int> ActualizarUno(string sql)
    {
        int filasAfectadas;
        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            conexion.Open();
            filasAfectadas = await conexion.ExecuteAsync(sql, commandTimeout: 120);
            conexion.Close();
        }
        return filasAfectadas;
    }

    public async Task<IEnumerable<TResultado>> EjecutarProcesoAsincrono<TResultado>(string sql, object parametros)
    {
        IEnumerable<TResultado> resultado = Enumerable.Empty<TResultado>();
        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            try
            {
                conexion.Open();
                resultado = await conexion.QueryAsync<TResultado>(
                    sql,
                    parametros,
                    commandType: CommandType.Text,
                    commandTimeout: 120
                );
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return resultado;
    }

    public async Task<T> EjecutarUnoAsync(string sql, object parametrosSql)
    {
        T respuestaSql = default;

        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            conexion.Open();
            respuestaSql = (await conexion.QueryAsync<T>(sql, param: parametrosSql, commandTimeout: 120)).FirstOrDefault();
            conexion.Close();
        }
        return respuestaSql;
    }

    public async Task<T> EjecutarProcesoAsincrono(string sql, object parametrosSql)
    {
        T entidad = default(T);

        using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
        {
            entidad = (await conexion.QueryAsync<T>(sql, param: parametrosSql, commandTimeout: 120)).FirstOrDefault();
        }
        return entidad;
    }

}
