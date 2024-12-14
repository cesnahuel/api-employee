using GestionEmpleados.Application.Common.Models;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Commands.Create;
using GestionEmpleados.Application.Employee.Commands.Delete;
using GestionEmpleados.Application.Employee.Commands.Update;
using GestionEmpleados.Application.Employee.Queries.Get;
using GestionEmpleados.Application.Employee.Queries.GetByFilter;
using GestionEmpleados.Application.Employee.Queries.GetEstadoCivil;
using Microsoft.AspNetCore.Mvc;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestionEmpleados.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        /// <summary>
        /// Obtiene todos los empleados
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllEmployeeQuery(), cancellationToken));
        }

        /// <summary>
        /// Crea un nuevo empleado
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<EmployeeDto>>> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Modifica un empleado
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<EmployeeDto>>> Update(int id, UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Elimina un empleado
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteEmployeeCommand { Id = id }, cancellationToken)); 
        }

        /// <summary>
        /// Obtiene los empleados por medio de filtros
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[HttpGet("nombre={nombre}&rfc={rfc}&estadoId={estadoId}")]
        [HttpGet("Filter")]
        public async Task<ActionResult<List<EmployeeDto>>> GetByFilter(CancellationToken cancellationToken, [FromQuery]string nombre = "", [FromQuery] string rfc = "", [FromQuery] int  estadoId = 0)
        {
            return Ok(await Mediator.Send(new GetByFilterEmployeeQuery { Nombre = nombre, Rfc = rfc, EstadoId = estadoId }, cancellationToken));
        }

        /// <summary>
        /// Obtiene los generos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("EstadoCivil")]
        public async Task<ActionResult<List<CivilStateDto>>> GetEstadoCivil(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllCivilStateQuery(), cancellationToken));
        }
    }
}
