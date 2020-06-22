using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Services
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string EmailFrom { get; }
        string Password { get; }
    }
}
