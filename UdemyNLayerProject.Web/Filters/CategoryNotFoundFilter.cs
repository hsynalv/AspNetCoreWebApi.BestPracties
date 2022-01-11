using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using UdemyNlayerProject.Web.DTOs;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.ApiServices;

namespace UdemyNlayerProject.Web.Filters
{
    public class CategoryNotFoundFilter : ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryService;

        public CategoryNotFoundFilter(CategoryApiService categoryService)
        {
            _categoryService = categoryService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Errors.Add($"Id değeri {id} olan kategori veritabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }

    }
}
