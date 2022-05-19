using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Common
{
    public class BreadCrumbDto
    {
        public string LevelOne { get; set; }

        public string LevelOneUrl { get; set; }

        public string LevelTwo { get; set; }

        public string LevelTwoUrl { get; set; }

        public string LevelThree { get; set; }

        public string LevelThreeUrl { get; set; }
    }
}
