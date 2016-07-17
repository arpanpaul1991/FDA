using FDA.Core.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Common;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel = FDA.Core.Models;

namespace FDA.Logic.Services
{
    public class EstabslimentOrderService
    {
        UnitOfWork context;
        public EstabslimentOrderService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse EstablishmentOrderListService(EsIdRequest request)
        {
            StatusResponse result = new StatusResponse();

            OrdesByEstablishment ordesByEstablishment = new OrdesByEstablishment();
            ordesByEstablishment.EstablishOrders = new List<FDA.Logic.Models.ShowOrderResponse>();

            IEnumerable<CoreModel.Order> orderDetails = context.OrderRepository.Get(filter: t => t.EstablishmentId == request.EID);


            if (orderDetails.Count() > 0)
            {
                foreach (var items in orderDetails)
                {

                    ShowOrderResponse showOrder = new ShowOrderResponse();
                    showOrder.OrderDetail = new List<FDA.Logic.Models.ShowOrderDetailsResponse>();

                    IEnumerable<FDA.Core.Models.OrderDetail> OrderByUser = context.OrderDetailRepository.Get(filter: t => t.Order_Id == items.Id);


                    showOrder.Id = items.Id;
                    showOrder.PhoneNumber = items.PhoneNumber;
                    showOrder.Address = items.Address;
                    showOrder.DateTime = items.DateTime;
                    showOrder.CouponId = items.CouponId;
                    showOrder.Comment = items.Comment;
                    showOrder.Status = items.Status;


                    foreach (var itemOders in OrderByUser)
                    {
                        ShowOrderDetailsResponse ods = new ShowOrderDetailsResponse();
                        ods.FoodName = context.MenuListRepository.Get(filter: t => t.Id == itemOders.MenuId).FirstOrDefault().FoodName.ToString();
                        if (ods.FoodName == null)
                        {
                            continue;
                        }
                        ods.MenuId = itemOders.MenuId;
                        ods.Price = itemOders.Price;
                        ods.TotalQuantity = itemOders.TotalQuantity;

                        showOrder.OrderDetail.Add(ods);
                    }

                    ordesByEstablishment.EstablishOrders.Add(showOrder);

                }


                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "List of Orders";

            }
            else
            {
                result.Status = 404;
                result.StatusMessage = "Success";
                result.ResponseMessage = "No Order Found";
            }

            result.Body = ordesByEstablishment;
            return result;

        }
    }
}
