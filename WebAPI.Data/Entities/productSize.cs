using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productSize
    {
        public string idSize { get; set; }

        public string sizeName { get; set; }

        public List<products> products { get; set; }
    }
}
