using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Utilities.Exceptions
{
    public class WebAPIException :Exception
    {
        public WebAPIException() 
        {

        }

        public WebAPIException(string message)
            : base(message)
        {
        }

        public WebAPIException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
