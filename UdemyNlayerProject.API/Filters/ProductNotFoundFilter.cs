using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using UdemyNlayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNlayerProject.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto
                {
                    Status = 404,
                };
                errorDto.Errors.Add($"Id değeri {id} olan ürün veritabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }

    }
}
