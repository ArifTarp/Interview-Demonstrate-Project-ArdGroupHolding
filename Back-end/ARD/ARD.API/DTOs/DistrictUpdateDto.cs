﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.DTOs
{
    public class DistrictUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }
    }
}