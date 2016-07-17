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
    public class UserService
    {
        UnitOfWork context;
        public UserService()
        {
            context = new UnitOfWork();
        }
        public StatusResponse ChangePasswordService(ChangePasswordRequest request)
        {
            StatusResponse result = new StatusResponse();

            IEnumerable<CoreModel.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Id == request.EID && t.Password == request.OldPassword);


            if (establishment.Count() > 0)
            {
                var model = context.EstablishmentRepository.GetById(establishment.FirstOrDefault().Id);

                string Email = establishment.FirstOrDefault().Email.ToString();
                string Name = establishment.FirstOrDefault().EstablishmentName.ToString();
                int Permission = establishment.FirstOrDefault().Permission;
                string Phone = establishment.FirstOrDefault().Phone.ToString();
                string Pincode = establishment.FirstOrDefault().Pincode.ToString();
                int Status = establishment.FirstOrDefault().Status;
                string Street = establishment.FirstOrDefault().Street.ToString();

                model.Password = request.NewPassword;
                model.Email = Email;
                model.EstablishmentName= Name;
                model.Permission = Permission;
                model.Phone = Phone;
                model.Pincode = Pincode;
                model.Status = Status;
                model.Street = Street;

                context.EstablishmentRepository.Update(model);
                context.EstablishmentRepository.Save();

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Password Changed Successfully";
                result.Body = "";

            }
            else
            {
                result.Status = 404;
                result.Body = "";
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Incorrect UserName Password";
            }


            return result;
        }
        public StatusResponse ForgotPasswordService(ForgotPasswordRequest request)
        {

            StatusResponse result = new StatusResponse();
            IEnumerable<CoreModel.Establishment> establishment = context.EstablishmentRepository.Get(filter: t => t.Email == request.Email);

            if (establishment.Count() > 0)
            {
                MailHelper mh = new MailHelper();
                string password = context.EstablishmentRepository.Get(filter: t => t.Email == request.Email).FirstOrDefault().Password.ToString();
                mh.SendEmail(request.Email, "FDA", "Your Password is: " + password);

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Password has sent to your Email";
                result.Body = "";
                
            }
            else
            {
                result.Status = 400;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Incorrect Email";
                result.Body = "";
                
            }

            return result;
        }
    }
}
