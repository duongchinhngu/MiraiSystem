using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    abstract public class FashionProductDto : ProductDto
    {
        [FromQuery(Name = "colorway")]
        [Required(ErrorMessage = "Colorway is required")]
        [StringLength(124, ErrorMessage = "Colorway can't be longer than 124 characters")]
        public string Colorway { get; set; }

        [FromQuery(Name = "material")]
        [Required(ErrorMessage = "Material is required")]
        [StringLength(124, ErrorMessage = "Material can't be longer than 124 characters")]
        public string Material { get; set; }

        [FromQuery(Name = "gender")]
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10, ErrorMessage = "Gender can't be longer than 10 characters")]
        public string Gender { get; set; }

        [FromQuery(Name = "released-date")]

        public DateTime ReleasedDate { get; set; }

        [FromQuery(Name = "condition")]
        [Required(ErrorMessage = "Condition is required")]
        [StringLength(50, ErrorMessage = "Condition can't be longer than 50 characters")]
        public string Condition { get; set; }

    }
}
