using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyNlayerProject.Web.DTOs;
using UdemyNlayerProject.Web.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.ApiServices;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();


            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
