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
    public class LoginService
    {
        UnitOfWork context;
        public LoginService()
        {
            context = new UnitOfWork();
        }
        public StatusResponse AutheticationService(LoginRequest request)
        {
            StatusResponse result = new StatusResponse();
            IEnumerable<CoreModel.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Email == request.Email && t.Password == request.Password);

            LoginResponse es = new LoginResponse();

            if (establishment.Count() > 0)
            {
                es.EID = establishment.FirstOrDefault().Id;
                es.ESName = establishment.FirstOrDefault().EstablishmentName;
                
                result.Status = 200;
                result.Body = es;
                result.StatusMessage = "Success";
                result.StatusMessage = "Login Success";
                
               
            }
            else
            {
                result.Status = 400;
                result.Body = "";
                result.StatusMessage = "Success";
                result.StatusMessage = "Incorrect UserName/Password";
            }


            return result;
        }
    }
}
