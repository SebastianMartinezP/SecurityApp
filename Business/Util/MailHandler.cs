using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Util
{
    public static class MailHandler
    {
        public static SmtpClient? SmtpClient{ get; set; }
    }
}
