using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class ApproveEstablishmentService
    {
        UnitOfWork context;

        public ApproveEstablishmentService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse ApproveEstablishment(EstablishmentPermissionrequest request)
        {
            StatusResponse result = new StatusResponse();
            IEnumerable<FDA.Core.Models.Establishment> establishment = context.EstablishmentRepository.Get(filter: (t => t.Id == request.EID && t.Permission == 2));

            if (establishment.Count() > 0)
            {
                var approveEsablishment = context.EstablishmentRepository.GetById(establishment.FirstOrDefault().Id);
                approveEsablishment.Permission = request.Permission;
                context.EstablishmentRepository.Update(approveEsablishment);
                context.EstablishmentRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Establishment is approved";
                result.Body = "";
            }
            else
            {
                result.Status = 404;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Establishment is not approved";
                result.Body = "";
            }

            return result;

        }
    }
}
