using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DTO
{
    public class GenericResponce
    {
        public GenericResponce()
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

        public bool MustChangePassword { get; set; }

    }

    public class GenericResponce<TEntity> : GenericResponce
    {
        public TEntity Responce { get; set; }
    }
}
