using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productColor
    {
        public string idColor { get; set; }

        public string colorName { get; set; }

        public List<products> products { get; set; }
    }
}
