using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productTypes
    {
        public string idType { get; set; }

        public string typeName { get; set; }

        public List<products> products { get; set; }
    }
}
