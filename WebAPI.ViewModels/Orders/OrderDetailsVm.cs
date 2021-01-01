using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Orders
{
    public class OrderDetailsVm
    {
        public string idOrderList { get; set; }
        public string idOder { set; get; }
        public int totalPrice { set; get; }
        public string idProduct { get; set; }
        public int quatity { get; set; }
    }
}
