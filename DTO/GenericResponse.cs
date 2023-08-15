using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DTO
{
    public class GenericResponse
    {
        public GenericResponse()
        {
            Message = string.Empty;
            Code = string.Empty;
            Source = string.Empty;
        }
        public bool Status { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }

        public string Source { get; set; }
    }

    public class GenericResponse<TEntity> : GenericResponse
    {
        public TEntity Response { get; set; }
    }
}
