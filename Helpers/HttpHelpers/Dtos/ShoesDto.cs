using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class ShoesDto : FashionProductDto
    {
        [FromQuery(Name ="size")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 20, ErrorMessage = "Size must be a positive double number under 20.")]
        public decimal Size { get; set; }
    }
}
