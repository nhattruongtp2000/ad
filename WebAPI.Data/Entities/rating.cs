using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class rating
    {
        public string Id { get; set; }

        public string idUser { get; set; }
        
        public string idProduct { get; set; }
        
        public string comment { get; set; }
        
        public DateTime rateDate { get; set; }
        
        public int rate { get; set; }

        public users users { get; set; }

        public products products { get; set; }
    }
}
