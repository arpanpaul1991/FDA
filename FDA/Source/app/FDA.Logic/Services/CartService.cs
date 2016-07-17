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
    public class CartService
    {
        UnitOfWork context;

        public CartService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse ShowCart(CartGuidRequest request)
        {
            StatusResponse result = new StatusResponse();


            List<Cart> CartItems = context.CartRepository.Get(filter: t => t.GId == request.GId).ToList();

            int Subtotal=0;

            ShowCartResponse scr = new ShowCartResponse();
            scr.Items = new List<Cart>();

            if (CartItems.Count() > 0)
            {
                foreach(var CartItem in CartItems)
                {
                    scr.Items.Add(CartItem);

                    Subtotal += CartItem.Price * CartItem.TotalQuantity;
                }

                scr.SubTotal = Subtotal;

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Items List";
                result.Body = scr;
            }
            else
            {
                result.Status = 400;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart is Empty";
                result.Body = "";
            }

            
            return result;

        }

        public StatusResponse AddItem(CartAddItemRequest request)
        {
            StatusResponse result = new StatusResponse();

            Cart cartItem = new Cart();

            var CartExistItem = context.CartRepository.Get(filter: t => t.FoodName == request.FoodName && t.GId == request.GId);

            if(CartExistItem.Count() > 0)
            {
                CartExistItem.FirstOrDefault().TotalQuantity += request.TotalQuantity;


                context.CartRepository.Update(CartExistItem.FirstOrDefault());
                context.CartRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Item Updated Successfully";
            }
            else if (CartExistItem.Count() == 0 && request.TotalQuantity > 0)
            {
                cartItem.GId = request.GId;
                cartItem.MenuId = request.MenuId;
                cartItem.FoodName = request.FoodName;
                cartItem.TotalQuantity = request.TotalQuantity;
                cartItem.Price = request.Price;

                context.CartRepository.Insert(cartItem);
                context.CartRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Item Added Successfully";

            }
            else
            {
                result.Status = 400;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Invalid Quantity";
            }

            result.Body = "";

            return result;
        }

        public StatusResponse AddOneItem(CartIdRequest request)
        {
            StatusResponse result = new StatusResponse();

            Cart cartItem = new Cart();

            var CartExistItem = context.CartRepository.Get(filter: t => t.Id == request.CartId && t.GId == request.GId);

            CartExistItem.FirstOrDefault().TotalQuantity += 1;
            
            context.CartRepository.Update(CartExistItem.FirstOrDefault());
            context.CartRepository.Save();

            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "Cart Item Updated Successfully";
            
            result.Body = "";

            return result;
        }

        public StatusResponse RemoveOneItem(CartIdRequest request)
        {
            StatusResponse result = new StatusResponse();
            
            var CartExistItem = context.CartRepository.Get(filter: t => t.Id == request.CartId && t.GId == request.GId);

            if (CartExistItem.FirstOrDefault().TotalQuantity > 1)
            {
                CartExistItem.FirstOrDefault().TotalQuantity -= 1;


                context.CartRepository.Update(CartExistItem.FirstOrDefault());
                context.CartRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Item Updated Successfully";
            }
            else if(CartExistItem.FirstOrDefault().TotalQuantity == 1)
            {
                context.CartRepository.Delete(CartExistItem.FirstOrDefault().Id);
                context.CartRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Item Removed Successfully";

            }
            else
            {
                result.Status = 400;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Cart Item Dose not Exist";
            }

            result.Body = "";

            return result;
        }

        public StatusResponse RemoveItem(CartIdRequest request)
        {
            StatusResponse result = new StatusResponse();

            var CartExistItem = context.CartRepository.Get(filter: t => t.Id == request.CartId && t.GId == request.GId);

            context.CartRepository.Delete(CartExistItem.FirstOrDefault().Id);
            context.CartRepository.Save();

            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "Cart Item Removed Successfully";


            result.Body = "";

            return result;
        }
    }
}
