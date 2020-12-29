using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.ViewModels.System.Users
{
    public class UserUpdateRequest
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string firstName { get; set; }

        [Display(Name = "Họ")]
        public string lastName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime birthday { get; set; }

        [Display(Name = "Hòm thư")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
