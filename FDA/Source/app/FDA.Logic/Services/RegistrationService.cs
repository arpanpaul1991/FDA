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
    public class RegistrationService
    {
        UnitOfWork context;
        public RegistrationService()
        {
            context = new UnitOfWork();
        }

        public StatusResponse Registration(RegistrationRequest Request)
        {
            StatusResponse result = new StatusResponse();
            Establishment newuser = new Establishment();
            IEnumerable<FDA.Core.Models.Establishment> est= context.EstablishmentRepository.Get(filter: x => x.Email == Request.Email);
            if (est.Count() == 0)
            {
                newuser.Email = Request.Email;
                newuser.EstablishmentName = Request.EstablishmentName;
                newuser.OwnerName = Request.OwnerName;
                newuser.ContactName = Request.ContactName;
                newuser.CompleteAddress = Request.CompleteAddress;
                newuser.Password = Request.Password;
                newuser.Permission = 2;
                newuser.Phone = Request.Phone;
                newuser.Pincode = Request.Pincode;
                newuser.Status = 1;
                newuser.Street = Request.Street;

                context.EstablishmentRepository.Insert(newuser);
                context.EstablishmentRepository.Save();

                MailHelper mh = new MailHelper();
                mh.SendEmail(Request.Email, "FDA", "Welcome to FDA. You Successfully Registered");

                LoginResponse lr = new LoginResponse();
                IEnumerable<FDA.Core.Models.Establishment> est1 = context.EstablishmentRepository.Get(filter: x => x.Email == newuser.Email);
                lr.EID = est1.FirstOrDefault().Id;
                lr.ESName = est1.FirstOrDefault().EstablishmentName;

                result.Status = 200;
                result.StatusMessage = "Success";
                result.ResponseMessage = "Congratulations ,Seller acount has been Created";
                result.Body =  lr;
            }
            else
            {
                result.Status = 200;
                result.StatusMessage = "Failed";
                result.ResponseMessage = "Seller Already Exist";
                result.Body = "";
            }
            return result;
        }
    }
}
