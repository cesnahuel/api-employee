using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Common.Models
{
    /// <summary>
    /// Clase que devuelve los codigos y mensajes de error que suceden en la applicacion, estos errores se manejan por el protocolo http
    /// </summary>
    [Serializable]
    public class ServiceError
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ServiceError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }
        public ServiceError() { }

        public string Message { get; }

        public int Code { get; }
        public static ServiceError DefaultError => new ServiceError("Ocurrió una excepción.", 400);
        public static ServiceError Validation => new ServiceError("Se produjeron uno o más errores de validación.", 404);
        public static ServiceError NotFound => new ServiceError("El recurso especificado no fue encontrado.", 404);

        public static ServiceError CustomMessage(string errorMessage)
        {
            return new ServiceError(errorMessage, 400);
        }


    }
}
