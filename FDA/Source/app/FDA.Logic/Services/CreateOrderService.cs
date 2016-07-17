using FDA.Core.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Common;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class CreateOrderService
    {
        UnitOfWork context;

        public CreateOrderService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse CreateOrder(CreateOrderRequest Request)
        {
            StatusResponse result = new StatusResponse();

            Order order = new Order();
            OrderHistory orderHistory = new OrderHistory();

            FDA.Core.Models.OrderDetail orderdetail = new FDA.Core.Models.OrderDetail();
            OrderDetailHistory orderDetailHistory = new OrderDetailHistory();

            int id;

            //customer registration 
           FDA.Core.Models.Customer customer = context.CustomerRepository.Get(t => t.Phone == Request.PhoneNumber).FirstOrDefault();
            if (customer!=null)
            {
                id = customer.Id;

            }
            else
            {
                var model = new Customer();
                model.Phone = Request.PhoneNumber;
                model.Address = Request.Address;

                context.CustomerRepository.Insert(model);
                context.CustomerRepository.Save();
                id = model.Id;
            }

            //end 

            order.CustomerId = id;
            order.EstablishmentId = Request.EstablishmentId;
            order.CouponId = Request.CouponId;
            order.Address = Request.Address;
            order.DateTime = Request.DateTime;
            order.PhoneNumber = Request.PhoneNumber;
            order.Status = 1;

            context.OrderRepository.Insert(order);
            context.OrderRepository.Save();


            orderHistory.CustomerId = id;
            orderHistory.EstablishmentId = Request.EstablishmentId;
            orderHistory.CouponId = Request.CouponId;
            orderHistory.Address = Request.Address;
            orderHistory.CreatedDate = Request.DateTime;
            orderHistory.PhoneNumber = Request.PhoneNumber;
            orderHistory.Status = 1;
            orderHistory.OrderId = order.Id;
            orderHistory.ModifiedDate = DateTime.Now;

            context.OrderHistoryRepository.Insert(orderHistory);
            context.OrderHistoryRepository.Save();

            foreach (var item in Request.OrderDetail)
            {
                orderdetail.MenuId = item.MenuId;
                orderdetail.Price = item.Price;
                orderdetail.TotalQuantity = item.TotalQuantity;
                orderdetail.Order_Id = order.Id;

                context.OrderDetailRepository.Insert(orderdetail);
                context.OrderDetailRepository.Save();

                orderDetailHistory.MenuId = item.MenuId;
                orderDetailHistory.Price = item.Price;
                orderDetailHistory.TotalQuantity = item.TotalQuantity;
                orderDetailHistory.Order_Id = order.Id;

                context.OrderDetailHistoryRepository.Insert(orderDetailHistory);
                context.OrderDetailHistoryRepository.Save();
            }

            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "Ordered Successfully";
            result.Body = "";


            return result;
        }
    }
}
