using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Venta.Application.Core
{
    public class ServiceResult
    {
        public ServiceResult() {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
