using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyNlayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNlayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            await _personService.AddAsync(person);
            return Created(string.Empty,person);
        }

        [HttpPut]
        public IActionResult Update(Person person)
        {
            _personService.Update(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);
            return NoContent();
        }
    }
}
