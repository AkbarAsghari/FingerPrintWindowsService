using FingerPrintService.Middlewares;
using System;
using System.Web.Http;
using WebAPI;

namespace FingerPrintService.Controllers
{
    public class FingerController : BaseController
    {

        public FingerController()
        {
            GeneralFingerPrint.Instance();
        }
        [Route("finger/get")]
        [HttpGet]
        public IHttpActionResult GetFingerImage()
        {
            try
            {
                return Ok(GeneralFingerPrint.ScanFinger());
            }
            catch (Exception ex)
            {
                return BadRequest("-1", ex.Message);
            }
        }

        [Route("finger/devices")]
        [HttpGet]
        public IHttpActionResult GetDevices()
        {
            try
            {
                return Ok(GeneralFingerPrint.IsPlug());
            }
            catch (Exception ex)
            {
                return BadRequest("-1", ex.Message);
            }
        }

    }
}
