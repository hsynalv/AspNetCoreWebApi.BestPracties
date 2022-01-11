using System.Collections.Generic;

namespace UdemyNlayerProject.Web.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
