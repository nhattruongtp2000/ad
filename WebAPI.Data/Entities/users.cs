using WebAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class users : IdentityUser<string>
    {
        public string idUser { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime birthday { get; set; }

        public string note { get; set; }

        public string province { get; set; }

        public string interestedIn { get; set; }
        public string address { get; set; }
        public DateTime lastLogin { get; set; }
        public string avatar { get; set; }

        public List<odersList> odersLists { get; set; }

        public List<rating> ratings { get; set; }



    }
}
