﻿using System.ComponentModel.DataAnnotations;

namespace FreeCC_MVC_web.Models
{
    public class category
    {
        [key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOdrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
