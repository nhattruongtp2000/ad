using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.ViewModels.Orders
{
    public class OrderCreateRequest
    {
        public int ProductId { set; get; }

        public string UserName { get; set; }

        public string ShipName { set; get; }

        public string ShipAddress { set; get; }

        public string ShipEmail { set; get; }

        public string ShipPhoneNumber { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public string LanguageId { set; get; }

    }
}
