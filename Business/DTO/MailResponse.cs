using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    [Serializable]
    public class MailResponse
    {
        public MailResponse()
        {

        }
        public bool? IsSuccessful { get; set; }
        public string? Result { get; set; }
    }
}
