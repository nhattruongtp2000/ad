using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class role : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
