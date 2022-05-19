﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.UserPanel
{
    public class UserInformationDTO
    {
        public string Avatar { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BirthDate { get; set; }
    }
}
