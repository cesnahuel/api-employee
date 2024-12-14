using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Queries.GetEstadoCivil
{
    public class GetAllCivilStateQueryHandler : IRequestHandler<GetAllCivilStateQuery, List<CivilStateDto>>
    {
        private readonly ICivilStateRepository _civilStateRepository;
        public GetAllCivilStateQueryHandler(ICivilStateRepository civilStateRepository)
        {
            _civilStateRepository = civilStateRepository;
        }

        public async Task<List<CivilStateDto>> Handle(GetAllCivilStateQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.CivilStatus> civilState = await _civilStateRepository.FindAll();
            List<CivilStateDto> result = new List<CivilStateDto>();

            civilState.ForEach(tempCivilStatus => result.Add(new CivilStateDto(tempCivilStatus)));

            return result;
        }
    }
}
