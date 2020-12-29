using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.ViewModels.Sales
{
    public class CheckoutRequest
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        
        public DateTime OrderDate { set; get; }

        public Status Status { set; get; }

        public string LanguageId { set; get; }

        public string OrderDetails { set; get; }
    }
}
