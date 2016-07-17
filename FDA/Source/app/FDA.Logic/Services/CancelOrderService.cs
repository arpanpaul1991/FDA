using FDA.Core.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class CancelOrderService
    {
        UnitOfWork context;

        public CancelOrderService()
        {
            context = new UnitOfWork();
        }


        public StatusResponse CancelOrder(CancelOrderRequest request)
        {

            StatusResponse result = new StatusResponse();
            IEnumerable<FDA.Core.Models.Order> order = context.OrderRepository.Get(filter: t => t.Id == request.OrderId);
            if (order.Count() > 0)
            {
                var orderModel = context.OrderRepository.GetById(order.FirstOrDefault().Id);

                orderModel.Status = request.status;

                context.OrderRepository.Update(orderModel);
                context.OrderRepository.Save();


                OrderHistory orderHistory = new OrderHistory();

                orderHistory.CouponId = orderModel.CouponId;
                orderHistory.OrderId = orderModel.Id;
                orderHistory.CustomerId = orderModel.CustomerId;
                orderHistory.Address = orderModel.Address;
                orderHistory.Status = request.status;
                orderHistory.CreatedDate = orderModel.DateTime;
                orderHistory.EstablishmentId = orderModel.EstablishmentId;
                orderHistory.Comment = orderModel.Comment;
                orderHistory.Rating = orderModel.Rating;
                orderHistory.PhoneNumber = orderModel.PhoneNumber;
                orderHistory.ModifiedDate = DateTime.Now;

                context.OrderHistoryRepository.Insert(orderHistory);
                context.OrderHistoryRepository.Save();


                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage= "Order Canceled Successfully";
                result.Body = "";
                
            }
            else
            {
                result.Status = 404;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Order does not Exist";
                result.Body = "";
                
            }
            return result;
        }
    }
}
