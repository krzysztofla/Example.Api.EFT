using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.EFT.Abstractions.Exceptions
{
    public class EftCoreException : Exception
    {
        public string Code { get; set; }
        public EftCoreException(string? message, string code) : base(message)
        {
            Code = code;
        }
    }
}
