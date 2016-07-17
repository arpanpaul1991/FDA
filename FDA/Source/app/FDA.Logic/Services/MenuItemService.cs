using FDA.Core.DBContext;
using FDA.Core.Models;
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
    public class MenuItemService
    {
        UnitOfWork context;
        public MenuItemService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse AddMenuItem(AddMenuItemRequest request)
        {

            StatusResponse result = new StatusResponse();
            MenuList menuList = new MenuList();

            menuList.EID = request.EID;
            menuList.FoodName = request.FoodName;
            menuList.Price = request.Price;
            menuList.Quantity = request.Quantity;
            menuList.CategoryId = request.CategoryId;
            menuList.Status = 1;

            context.MenuListRepository.Insert(menuList);
            context.MenuListRepository.Save();

            result.Status = 200;
            result.Body = "";
            result.StatusMessage = "Success";
            result.ResponseMessage = "Successfully Added Menu Item";
        
            return result;
        }

        public StatusResponse ShowMenuItemsService(EsIdRequest esId)
        {

            StatusResponse result = new StatusResponse();
            EstabishmentMenu ebmenu = new EstabishmentMenu();
            ebmenu.EID = esId.EID;
            List<FDA.Core.Models.Category> categories = context.CategoryRepository.Get().ToList();
            ebmenu.categoryList = new List<Models.Category>();
            foreach (var item in categories)
            {
                Models.Category objCategory = new Models.Category();
                objCategory.Id = item.Id;
                objCategory.CategoryType = item.CategoryName;
                objCategory.menuList = new List<MenuItem_Category>();
                List<FDA.Core.Models.MenuList> menu = context.MenuListRepository.Get(filter: t => t.CategoryId == item.Id && t.EID == esId.EID ).ToList();
                foreach (var i in menu)
                {
                    MenuItem_Category m = new MenuItem_Category();
                    m.MenuId = i.Id;
                    m.CategoryId = i.CategoryId;
                    m.FoodName = i.FoodName;
                    m.Price = i.Price;
                    m.Quantity = i.Quantity;
                    m.Status = i.Status;
                    m.EID = i.EID;
                    m.TotalQuantity = 1;
                    objCategory.menuList.Add(m);
                }
                ebmenu.categoryList.Add(objCategory);
            }

            result.Status = 200;
            result.Body = ebmenu;
            result.StatusMessage = "Success";
            result.ResponseMessage = "List of Menulist";

            return result;


        }

        public StatusResponse UpdateMenuItemService(EditMenuItemRequest request)
        {
            StatusResponse result = new StatusResponse();
            EditMenuItemRequest edit = new EditMenuItemRequest();
            List<FDA.Core.Models.MenuList> menu  = context.MenuListRepository.Get(filter: t => t.Id == request.MenuId && t.EID == request.EstablishmentID).ToList();
            if (menu.Count > 0 && request.EstablishmentID!=0)
            {
                var model = context.MenuListRepository.GetById(menu.FirstOrDefault().Id);
                model.EID = request.EstablishmentID;
                model.Id= request.MenuId;
                model.Price = request.Price;
                model.FoodName = request.FoodName;
                model.Quantity = request.Quantity;
                model.Status = request.Status;
                model.CategoryId = request.CategoryId;
                context.MenuListRepository.Update(model);
                context.MenuListRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Seller Updated Successfully";
                result.Body = "";
                

            }
            else
            {
                if(request.EstablishmentID == 0 && request.MenuId==0)
                {
                    result.Status = 404;
                    result.StatusMessage = "Failed";
                    result.ResponseMessage = "Enter Seller ID and Menu ID to Modify MenuItems";
                    result.Body = "";
                }
                else if(request.EstablishmentID == 0)
                {
                    result.Status = 404;
                    result.StatusMessage = "Failed";
                    result.ResponseMessage = "Enter Seller ID to Modify MenuItems";
                    result.Body = "";
                }
                else if( request.MenuId == 0)
                {
                    result.Status = 404;
                    result.StatusMessage = "Failed";
                    result.ResponseMessage = "Enter Menu ID to modify MenuItems";
                    result.Body = "";
                }
                else
                { 
                result.Status = 404;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Not able to Update Menulist Please check the format";
                result.Body = "";
                }
            }

            return result;
        }

    }
}
