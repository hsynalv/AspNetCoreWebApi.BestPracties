﻿using System.ComponentModel.DataAnnotations;

namespace UdemyNlayerProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alanı boş olamaz!")]
        public string Name { get; set; }
    }
}