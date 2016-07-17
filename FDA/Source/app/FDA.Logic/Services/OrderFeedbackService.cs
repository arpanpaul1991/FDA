using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class OrderFeedbackService
    {
        UnitOfWork context;
        public OrderFeedbackService()
        {
            context = new UnitOfWork();
        }
        public StatusResponse OrderFeedBack(EsIdRequest request)
        {
            StatusResponse result = new StatusResponse();

            IEnumerable<FDA.Core.Models.Order> orders = context.OrderRepository.Get(filter: x => x.EstablishmentId == request.EID && x.Status == 2);
            FeedbackResponse fr = new FeedbackResponse();
            fr.Feedbacks = new List<CustomerFeedbackResponse>();
            if (orders.Count() > 0)
            {
                foreach (var order in orders)
                {
                    CustomerFeedbackResponse cfr = new CustomerFeedbackResponse();
                    cfr.Email = context.CustomerRepository.GetById(order.CustomerId).Email;
                    cfr.Comment = order.Comment;
                    fr.Feedbacks.Add(cfr);
                }
            }
            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "Your Order Feedback";
            result.Body = fr;
            return result;
        }
    }
}
