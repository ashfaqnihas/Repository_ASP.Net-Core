using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Shop.Domain.Contracts;
using T_Shop.Domain.Models;
using T_Shop.Infrastructure.DbContexts;

namespace Mobile_Appliction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController (ICategoryRepository CategoryRepository) {

            _CategoryRepository = CategoryRepository;
        }

        //get data

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _CategoryRepository.GetAllAsync();
            return Ok(categories);
        }

        // ceate data

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var enity =  await _CategoryRepository.CreateAsync(category);
            
            return Ok(enity);
        }

        // get data with id

     
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Details")]

        public async Task<IActionResult> Details(int id)
        {
          var category =  await _CategoryRepository.GetByIdAsync(c=>c.Id==id);

            if (category == null)
            {
                return NotFound("Category Not Found");
            } 
            return Ok(category);
        }

        //Update data

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Update([FromBody]Category category) 
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           await _CategoryRepository.UpdateAsync(category);
            return NoContent();
        
        }

        //Delete

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id) 
        {
         if(id == 0)
            {
                return BadRequest();
            }
         var category = await _CategoryRepository.GetByIdAsync (x =>x.Id==id);
            if (category == null)
            {
                return NotFound();
            }

           await _CategoryRepository.DeleteAsync(category);
            return Ok();
        }
        
    }
}
