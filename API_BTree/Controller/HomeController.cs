using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using API_BTree.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_BTree.Controller
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Árbol B en Disco" };
        }
        /// <summary>
        /// Realizar recorrido del árbol según sea indicado por el usuario
        /// </summary>
        /// <param name="traversal"></param>
        /// <response code="200">Recorrido mostrado correctamente</response>
        /// <response code="400">Árbol no cuenta con valores insertados o iniciado</response>
        /// <returns></returns>
        [HttpGet, Route("{traversal}")]
        public ActionResult<List<string>> Recorrido(string traversal)
        {
            //Recorridos
            return Ok();
        }
        /// <summary>
        /// Indica el grado del árbol a utilizar
        /// </summary>
        /// <param name="grado"></param>
        /// <response code="200">Grado del árbol ingresado correctamente.</response>
        /// <response code="500">El válir ingresado no es válido.</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Orden([FromBody] int grado)
        {
            int value = 0;
            if (int.TryParse(grado.ToString(), out value))
            {
                if (value > 2)
                {
                    Data.grado = grado;
                    return Ok("El grado ha sido guardado correctamente.");
                }
                else
                {
                    throw new ArgumentException($"El grado {grado} debe ser mayor a 2.");
                }
            }
            else
            {
                throw new ArgumentException($"El valor {grado} debe ser numérico y mayor a 2.");
            }
        }
        /// <summary>
        /// Ingresa múltiples valores al árbol
        /// </summary>
        /// <param name="file"></param>
        /// <response code="200">Valores del archivo ingresados correctamente.</response>
        /// <response code="500">El grado no se ha ingresado o el archivo no tiene estructura Json.</response>>
        /// <returns></returns>
        [HttpPost, Route("populate")]
        public string InsertarVarios([FromForm] IFormFile file)
        {
            if (true && Data.grado > 2)
            {
                //Ingresar valores de Json
                return "Valores insertados correctamente.";
            }
            else { throw new ArgumentException($"El grado {Data.grado} del árbol es incorrecto o el archivo no cuenta con estructura Json."); }
        }
        /// <summary>
        /// Elimina por completo el árbol guardado actualmente
        /// </summary>
        /// <response code="200">Árbol eliminado</response>
        /// <response code="404">Árbol no contiene información</response>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Eliminar()
        {
            if (Data.Instance.arbol_Temp.Count > 0)
            {
                return Ok("Todo el árbol ha sido eliminado.");
            }
            else
            {
                return NotFound("El árbol no cuenta con valores para eliminar.");
            }
        }
        /// <summary>
        /// Eliminar un valór del árbol
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Valor ingresado ha sido eliminado exitosamente</response>
        /// <response code="404">Árbol no contiene información o el valor no ha sido encontrado</response>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public ActionResult Eliminar_ID(int id)
        {
            if (true)
            {
                //Ingresar valores de Json
                return Ok("Valor eliminado correctamente.");
            }
            else { throw new ArgumentException($"El grado {Data.grado} del árbol es incorrecto o el valor no se encuentra en el árbol."); }
        }
    }
}
