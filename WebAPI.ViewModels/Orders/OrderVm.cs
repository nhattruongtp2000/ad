using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.ViewModels.Orders
{
    public class OrderVm
    {
        public string idOrderList { get; set; }
        public string idOrder { get; set; }
        public string idUser { get; set; }
        public string idProduct { get; set; }
    }
}
