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

        protected IHttpActionResult Ok(GenericResponse genericResponce)
        {
            return Json<GenericResponse>(genericResponce);
        }

        protected IHttpActionResult Ok(string Message = "", string Code = "", bool Status = true, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Json<GenericResponse>(new GenericResponse()
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
            return Json<GenericResponse>(new GenericResponse<Tentity>()
            {
                Message = Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Response = tentity,
            });
        }

        protected IHttpActionResult BadRequest(GenericResponse genericResponce)
        {
            return Json<GenericResponse>(genericResponce);
        }

        protected IHttpActionResult BadRequest(string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return Json<GenericResponse>(new GenericResponse()
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
            return Json<GenericResponse>(new GenericResponse<Tentity>()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Response = tentity,
            });
        }

        protected IHttpActionResult Unauthorized(GenericResponse genericResponce)
        {
            return Json<GenericResponse>(genericResponce);
        }

        protected IHttpActionResult Unauthorized(string Code, string Message, bool Status = false, HttpStatusCode httpStatusCode = HttpStatusCode.Unauthorized)
        {
            return Json<GenericResponse>(new GenericResponse()
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
            return Json<GenericResponse>(new GenericResponse<Tentity>()
            {
                Message = Message == string.Empty ? ErrorMassages.DefaultError : Message,
                Code = Code,
                Source = Source,
                HttpStatusCode = httpStatusCode,
                Status = Status,
                Response = tentity,
            });
        }
    }
}
