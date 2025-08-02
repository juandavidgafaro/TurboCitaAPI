using Microsoft.AspNetCore.Mvc;

namespace TurboCita.Api.Aplicacion.Modelos;

public class ModeloEncabezadoSolicitud 
{
    [FromHeader(Name = "FrontUser")]
    public string Fuente { get; set; }
}