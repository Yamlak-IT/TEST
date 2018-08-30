using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TEST.Models
{
    public class Product
    {
        public int id { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Mandatory Attribute")]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Mandatory Attribute")]
        public decimal Price { get; set; }        
        public string ImageURL { get; set; }
    }    
}