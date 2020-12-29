using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Sales
{
    public class OrderDetailVm
    {

        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

    }
}
