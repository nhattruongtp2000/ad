using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.ViewModels.Orders
{
    public class OrderVm
    {
        public string idOrderList { get; set; }
        public string idUser { get; set; }
        public int status { set; get; }
        public DateTime date { get; set; }
        public string idVoucher { get; set; }
        public int totalPrice { set; get; }

    }
}
