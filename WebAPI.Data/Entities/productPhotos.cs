using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productPhotos
    {
        public string IdPhoto { get; set; }

        public string idProduct { get; set; }

        public string link { get; set; }

        public DateTime uploadedTime { get; set; }

        public products products { get; set; }


       
    }
}
