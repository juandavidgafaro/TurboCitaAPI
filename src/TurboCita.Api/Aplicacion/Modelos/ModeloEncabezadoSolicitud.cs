using Microsoft.AspNetCore.Mvc;

namespace TurboCita.Api.Aplicacion.Modelos;

public class ModeloEncabezadoSolicitud 
{
    [FromHeader(Name = "Fuente")]
    public string Fuente { get; set; }
}