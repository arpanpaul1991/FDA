using FDA.Core.UnitOfWork;
using FDA.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Services
{
    public class CategoryListService
    {
        
        UnitOfWork context;
        public CategoryListService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse CategoryList()
        {
            StatusResponse result = new StatusResponse();
            IEnumerable<FDA.Core.Models.Category> category = context.CategoryRepository.Get();
            result.Status = 200;
            result.StatusMessage = "Success";
            result.ResponseMessage = "List of Category";
            result.Body = category.ToList();
            return result;
        }
    }
}
