using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DTO;
using Newtonsoft.Json;

namespace WebAPI
{
    //[Authorize]
    [Route("api/[controller]/{action?}")]
    public abstract class BaseController : ApiController
    {
        private const string Source = "FingerPrintWindowsService";
        // Max Code = 000043

        public BaseController()
        {
        }

        protected IHttpActionResult Ok(GenericResponce genericResponce)
        {
            return Json<GenericResponce>(genericResponce);
        }

        protected IHttpActionResult Ok(string Message = "", string Code = "", bool Status = true, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Json<GenericResponce>(new GenericResponce()
            {
                Message = Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
            });
        }

        protected IHttpActionResult Ok<Tentity>(Tentity tentity, string Message = "", string Code = "", bool Status = true, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Json<GenericResponce>(new GenericResponce<Tentity>()
            {
                Message = Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Responce = tentity,
            });
        }

        protected IHttpActionResult BadRequest(GenericResponce genericResponce)
        {
            return Json<GenericResponce>(genericResponce);
        }

        protected IHttpActionResult BadRequest(string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return Json<GenericResponce>(new GenericResponce()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
            });
        }

        protected IHttpActionResult BadRequest<Tentity>(Tentity tentity, string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return Json<GenericResponce>(new GenericResponce<Tentity>()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Responce = tentity,
            });
        }

        protected IHttpActionResult Unauthorized(GenericResponce genericResponce)
        {
            return Json<GenericResponce>(genericResponce);
        }

        protected IHttpActionResult Unauthorized(string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.Unauthorized)
        {
            return Json<GenericResponce>(new GenericResponce()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
            });
        }

        protected IHttpActionResult Unauthorized<Tentity>(Tentity tentity, string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.Unauthorized)
        {
            return Json<GenericResponce>(new GenericResponce<Tentity>()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Responce = tentity,
            });
        }
    }
}
