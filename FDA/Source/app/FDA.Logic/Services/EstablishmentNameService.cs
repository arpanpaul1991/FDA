using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class EstablishmentNameService
    {
        UnitOfWork context;
        public EstablishmentNameService()
        {
            context = new UnitOfWork();
        }
        public StatusResponse EstablishmentNameListService(EsIdRequest request)
        {
            StatusResponse response = new StatusResponse();
            IEnumerable<FDA.Core.Models.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Id == request.EID);
            response.Status = 200;
            response.StatusMessage = "Establishment Location Found";
            response.Body = "";
            response.ResponseMessage = establishment.FirstOrDefault().CompleteAddress;
            return response;
        }

    }
}
