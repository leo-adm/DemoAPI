﻿using System.ComponentModel.DataAnnotations;

namespace DemoAPI.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }
    }
}
