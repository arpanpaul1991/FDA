using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel = FDA.Core.Models;

namespace FDA.Logic.Services
{
    public class SellerService
    {
        UnitOfWork context;
        public SellerService()
        {
            context = new UnitOfWork();
        }
        public StatusResponse SellerListService()
        {

            StatusResponse result = new StatusResponse();
            IEnumerable<FDA.Core.Models.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Status == 1 && t.Permission == 1);
            List<FDA.Logic.Models.EstablishmentListRequest> e = new List<FDA.Logic.Models.EstablishmentListRequest>();
           // e = List<FDA.Logic.Models.EstablishmentListRequest>(establishment);
            //foreach (var item in establishment)
            //{
            //    e.Add(new FDA.Logic.Models.EstablishmentListRequest()
            //        {
            //            Email = item.Email,
            //            Name = item.EstablishmentName,
            //            Phone = item.Phone,
            //            Pincode = item.Pincode,
            //            Street = item.Street,
            //            EID=item.Id
            //        });
            //}
            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "List of Seller";
            result.Body = establishment.ToList();

            return result;
        }
        public StatusResponse SellerListServiceByEmail(SellerListRequest request)
        {
            StatusResponse result = new StatusResponse();
            IEnumerable<CoreModel.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Id == request.EID);
            // var model = context.EstablishmentRepository.GetById(establishment.FirstOrDefault().Id);
            //result.Status = "Success";
            //result.Body = model.ToString();
            //result.Status = "Details of Seller";
            return result;
        }
    }
}
