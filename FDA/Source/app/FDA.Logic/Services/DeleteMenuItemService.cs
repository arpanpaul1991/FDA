using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class DeleteMenuItemService
    {
        UnitOfWork context;

        public DeleteMenuItemService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse DeleteMenu(DeleteMenuItemRequest request)
        {
            StatusResponse result = new StatusResponse();
            IEnumerable<FDA.Core.Models.MenuList> menulist = context.MenuListRepository.Get(filter: t => t.Id == request.Id);
            if (menulist.Count() > 0)
            {
                context.MenuListRepository.Delete(request.Id);
                context.MenuListRepository.Save();
                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Menu is removed Successfully";
                result.Body = "";
            }
            else
            {
                result.Status = 200;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Menu doesnt exist";
                result.Body = "";
            }
            return result;
        }
    }
}
