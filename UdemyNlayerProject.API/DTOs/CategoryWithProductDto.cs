using System.Collections.Generic;

namespace UdemyNlayerProject.API.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
